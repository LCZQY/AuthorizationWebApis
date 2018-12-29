using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AuthorityManagementCent.Dto.Common;

namespace AuthorityManagementCent.Filters
{
    //
    public class JwtTokenAuthorize : TypeFilterAttribute
    {
        public JwtTokenAuthorize() : base(typeof(LeavCheckPermissionImpl))
        {

        }

        private class LeavCheckPermissionImpl : IAsyncActionFilter
        {

            /// <summary>
            /// 在执行该方法之前执行// 解析Token 此处只是该静态类赋值并不是调用的过滤器中的方法给接口实体赋值，后期需要优化 ??
            /// </summary>
            /// <param name="context"></param>
            /// <param name="next"></param>
            /// <returns></returns>
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var identity = context.HttpContext.User;
                //获取到当前用户名
                string uses = identity.Identity.Name;
                if (uses == null)
                {
                    //如何直接在这个管道中跳出呢？ 
                    context.Result = new ContentResult()
                    {
                        Content = "请登陆",
                        StatusCode = 403,
                    };
                    return;
                }
                else
                {
                    try
                    {
                        DataBaseUser.TokenModel = new TokenModel
                        {
                            Id = identity.FindFirstValue(ClaimTypes.Sid),
                            UserName = uses,
                            RoleName = identity.FindFirstValue(ClaimTypes.Role),
                            TrueName = identity.FindFirstValue(ClaimTypes.GivenName),
                            OrganizationId = identity.FindFirstValue("Organization")
                        };
                        await next();
                    }
                    catch (Exception el)
                    {
                        var mes = el.Message;
                    }
                }
            }

        }
    }
    //    public Task Invoke(HttpContext httpContext)
    //    {
    //        //检测是否包含'Authorization'请求头
    //        if (!httpContext.Request.Headers.ContainsKey("Authorization"))
    //        {
    //            return _next(httpContext);
    //        }

    //        var tokenHeader = httpContext.Request.Headers["Authorization"].ToString();
    //        TokenModel tm = JwtHelpers.SerializeJWT(tokenHeader);//序列化token，获取授权

    //        //授权 注意这个可以添加多个角色声明，请注意这是一个 list
    //        var claimList = new List<Claim>();
    //        var claim = new Claim[] {
    //            new Claim(ClaimTypes.Role, tm.RoleName),
    //            new Claim(ClaimTypes.Name, tm.UserName),
    //        };
    //        claimList.AddRange(claim);
    //        var identity = new ClaimsIdentity(claimList);
    //        var principal = new ClaimsPrincipal(identity);
    //        httpContext.User = principal;
    //        return _next(httpContext);
    //    }
    //}

    //public Task Invoke(HttpContext httpContext)
    //{

    //    //检测是否包含'Authorization'请求头，如果不包含返回context进行下一个中间件，用于访问不需要认证的API
    //    if (!httpContext.Request.Headers.ContainsKey("Authorization"))
    //    {
    //        return _next(httpContext);
    //    }
    //    else
    //    {
    //        var tokenHeader = httpContext.Request.Headers["Authorization"];
    //        try
    //        {
    //           // var claimsIdentity = User.Identity as ClaimsIdentity;
    //            tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();
    //            var result = Config.StoreSignedUser.list.Where(m => m.userToken == tokenHeader).FirstOrDefault();

    //            if (result == null)
    //                return httpContext.Response.WriteAsync("非法请求");
    //            else
    //            {
    //                ClaimsIdentity identity = new ClaimsIdentity(result.userClaims);
    //                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
    //                httpContext.User = principal;//构建authorize认证
    //                return _next(httpContext);
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            return httpContext.Response.WriteAsync("token值长度不够");
    //        }

    //    }
    //}

}


