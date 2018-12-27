using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

using AuthorityManagementCent.Model;
using Microsoft.EntityFrameworkCore;
using AuthorityManagementCent.Managers;
using AuthorityManagementCent.Stores;
using AuthorityManagementCent.Stores.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;



namespace AuthorityManagementCent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
        }

        public IConfiguration Configuration { get; }
        public MapperConfiguration _mapperConfiguration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //配置Token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = "zqy.com", //发放者
                       ValidAudience = "pc.com", // 来源
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecurityKey"]))
                   };
               });


            //AutoMapper
            services.AddSingleton<IMapper>(mp=> _mapperConfiguration.CreateMapper());

            //数据库连接,注意：一定要加 sslmode=none 
            var connection = Configuration.GetConnectionString("MysqlConnection");
            services.AddDbContext<ModelContext>(options => options.UseMySQL(connection));

            //依赖注入类
            Plugin.AddScopeds(services);

            //注册Swagger文件
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "权限管理系统",
                    Description = "用户登陆请求Token/用户管理/组织管理/权限管理/角色管理",
                    TermsOfService = "None",                    
                });

                //给Swagger界面新增添加权限界面
                var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };
                options.AddSecurityRequirement(security);
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Authorization format : Bearer { token }",
                    //JWt默认的参数名称
                    Name="Authorzation",
                    //jwt默认存放Authorization信息的位置（携带在请求头中）
                    In="header",
                    Type="apiKey"
                });
                options.DocInclusionPredicate((docName, description) => true);
                options.IgnoreObsoleteActions();      
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);                
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //启动权限验证
            app.UseAuthentication();
            //启动Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            //启动前台跨域访问
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
