﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NetCore.Test.Token.Model;

namespace NetCore.Test.AuthHelper
{
    public class TokenAuth
    {
        ///
        /// http委托
        ///
        private readonly RequestDelegate _next;
        ///
        /// 构造函数
        ///
        ///
        public TokenAuth(RequestDelegate next)
        {
            _next = next;
        }
        ///
        /// 验证授权
        ///
        ///
        /// 
        public Task Invoke(HttpContext httpContext)
        {
            //获取请求头部
            var headers = httpContext.Request.Headers;
            //检测是否包含'Authorization'请求头，如果不包含返回context进行下一个中间件，用于访问不需要认证的API
            if (!headers.ContainsKey("Authorization"))
            {
                return _next(httpContext);
            }
            var tokenStr = headers["Authorization"];
            try
            {
                string jwtStr = tokenStr.ToString().Substring("Bearer ".Length).Trim();
                //验证缓存中是否存在该jwt字符串
                if (!RayPIMemoryCache.Exists(jwtStr))
                {
                    return httpContext.Response.WriteAsync("非法请求");
                }
                TokenModel tm = ((TokenModel)RayPIMemoryCache.Get(jwtStr));
                //提取tokenModel中的Sub属性进行authorize认证
                List<Claim> lc = new List<Claim>();
                Claim c = new Claim(tm.Sub + "Type", tm.Sub);
                lc.Add(c);
                ClaimsIdentity identity = new ClaimsIdentity(lc);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                httpContext.User = principal;
                return _next(httpContext);
            }
            catch (Exception)
            {
                return httpContext.Response.WriteAsync("token验证异常");
            }
        }
    }
}
