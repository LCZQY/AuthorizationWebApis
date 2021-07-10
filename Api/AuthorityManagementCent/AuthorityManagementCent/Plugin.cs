using AuthorityManagementCent.Managers;
using AuthorityManagementCent.Stores;
using AuthorityManagementCent.Stores.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AuthorityManagementCent
{
    public static class Plugin
    {
        public static void AddScopeds(IServiceCollection services)
        {
            //Token管理
            services.AddScoped<ITokenStore, TokenStore>();
            services.AddScoped<TokenManager>();

            //用户管理
            services.AddScoped<IUserStore, UserStore>();
            services.AddScoped<UserManager>();

            //组织管理
            services.AddScoped<IOranizationStore, OranizationStore>();
            services.AddScoped<OranizationManager>();

            //权限管理
            services.AddScoped<IJurisdictionStore, JurisdictionStore>();
            services.AddScoped<JurisdictionManager>();

            //角色管理
            services.AddScoped<IRolesStore, RolesStore>();
            services.AddScoped<RolesManager>();
        }
    }
}
