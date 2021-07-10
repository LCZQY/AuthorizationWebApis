using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Stores.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace AuthorityManagementCent.Filters
{
    /// <summary>
    /// 基本权限验证
    /// </summary>
    public class JwtTokenAuthorize : TypeFilterAttribute
    {

        public JwtTokenAuthorize() : base(typeof(LeavCheckPermissionImpl))
        {

        }

        private class LeavCheckPermissionImpl : IAsyncActionFilter
        {
            /// <summary>
            /// 在执行该方法之前执行
            /// 解析Token 此处只是该静态类赋值并不是调用的过滤器中的方法给接口实体赋值，后期需要优化 ??
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

                    var result = new ResponseMessage()
                    {
                        Code = ResponseCodeDefines.ArgumentError,
                        Message = "请登陆，或重新登陆."
                    };
                    context.Result = new ObjectResult(result);
                    return;
                }
                else
                {
                    try
                    {
                        ///未完成的需求：1 
                        // 找到该用户对应的角色 >>> 判断该角色拥有的权限 >> 根据权限项判断菜单项的显示和隐藏或是否可用 >> 如果没有则立即返回 

                        ///未完成的需求：2
                        ///用户组织角色权限的取消 ？？                         
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


    /// <summary>
    /// 是否用户管理员
    /// </summary>
    public class UserAuthorize : TypeFilterAttribute
    {
        public UserAuthorize() : base(typeof(UserCheckPermissionImpl))
        {

        }

        private class UserCheckPermissionImpl : IAsyncActionFilter
        {

            private IRolesStore _IRolesStore { get; }
            public UserCheckPermissionImpl(IRolesStore IRolesStore)
            {
                this._IRolesStore = IRolesStore;
            }

            /// <summary>
            /// 在执行该方法之前执行
            /// 解析Token 此处只是该静态类赋值并不是调用的过滤器中的方法给接口实体赋值，后期需要优化 ??
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
                    var result = new ResponseMessage()
                    {
                        Code = ResponseCodeDefines.ArgumentError,
                        Message = "请登陆，或重新登陆."
                    };
                    context.Result = new ObjectResult(result);
                    return;
                }
                else
                {
                    try
                    {
                        string useId = identity.FindFirstValue(ClaimTypes.Sid);

                        //用户角色
                        var UserRole = from b in _IRolesStore.GetUserRoleAsync().Where(p => p.UserId == useId)
                                       join c in _IRolesStore.GetRolePermissionsAsync()
                                       on b.RoleId equals c.RoledId into b1
                                       from c1 in b1.DefaultIfEmpty()
                                       select c1;
                        var permisitem = await UserRole.Select(p => p.PermissionsId).Distinct().ToListAsync();

                        if (!permisitem.Contains("User_Query"))
                        {
                            var result = new ResponseMessage()
                            {
                                Code = ResponseCodeDefines.NotAllow,
                                Message = "您没有查看用户管理的权限，请联系管理员"
                            };
                            context.Result = new ObjectResult(result);
                            return;
                        }

                        if (!permisitem.Contains("Organization_Query"))
                        {
                            var result = new ResponseMessage()
                            {
                                Code = ResponseCodeDefines.NotAllow,
                                Message = "您没有查看组织管理的权限，请联系管理员"
                            };
                            context.Result = new ObjectResult(result);
                            return;
                        }

                        if (!permisitem.Contains("Permissionitem_Query"))
                        {
                            var result = new ResponseMessage()
                            {
                                Code = ResponseCodeDefines.NotAllow,
                                Message = "您没有查看权限管理的权限，请联系管理员"
                            };
                            context.Result = new ObjectResult(result);
                            return;
                        }
                        if (!permisitem.Contains("Role_Query"))
                        {
                            var result = new ResponseMessage()
                            {
                                Code = ResponseCodeDefines.NotAllow,
                                Message = "您没有查看角色管理的权限，请联系管理员"
                            };
                            context.Result = new ObjectResult(result);
                            return;
                        }

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




