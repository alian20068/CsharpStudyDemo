using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationDemo.Security.Session
{
    /// <summary>
    /// 会话信息实现类
    /// </summary>
    public class ClaimsSession : IClaimsSession
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;
        public ClaimsSession(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 根据特性类型读取证件里的特征值
        /// </summary>
        /// <param name="claimType">特征类型</param>
        /// <returns></returns>
        protected virtual string ReadClaim(string claimType)
        {
            //如果类型不是 证件持有者
            if (!(_HttpContextAccessor.HttpContext.User is ClaimsPrincipal claimsPrincipal))
            {
                return null;
            }

            //如果类型不是 证件
            if (!(claimsPrincipal.Identity is ClaimsIdentity claimsIdentity))
            {
                return null;
            }

            //获取证件里的指定特征
            var claim = claimsIdentity.Claims.FirstOrDefault(p => p.Type == claimType);
            //如果不存在此特征或特征值无效
            if (claim == null || string.IsNullOrWhiteSpace(claim.Value))
            {
                return null;
            }

            //返回特征值
            return claim.Value;
        }
        /// <summary>
        /// 根据特性类型读取证件里的特征值
        /// </summary>
        /// <typeparam name="T">特征值的类型</typeparam>
        /// <param name="claimType">特征类型</param>
        /// <returns></returns>
        protected virtual Nullable<T> ReadClaim<T>(string claimType)
            where T : struct
        {
            var value = ReadClaim(claimType);
            if (value == null)
                return null;

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public string AccessToken => ReadClaim(ClaimTypes.AccessToken);

        public long? UserId => ReadClaim<long>(ClaimTypes.UserId);

        public string UserName => ReadClaim(ClaimTypes.UserName);

        public string RealName => ReadClaim(ClaimTypes.RealName);

        public string MobilePhone => ReadClaim(ClaimTypes.MobilePhone);

        public string Email => ReadClaim(ClaimTypes.Email);
    }
}
