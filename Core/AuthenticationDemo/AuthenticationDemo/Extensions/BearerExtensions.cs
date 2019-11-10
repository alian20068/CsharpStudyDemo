using AuthenticationDemo.Authentication;
using Microsoft.AspNetCore.Authentication;
using System;

namespace AuthenticationDemo.Extensions
{
    public static class BearerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="authenticationScheme"></param>
        /// <param name="displayName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static AuthenticationBuilder AddBearer(this AuthenticationBuilder builder,
            string authenticationScheme, string displayName, Action<BearerOptions> options)
        {
            return builder.AddScheme<BearerOptions, BearerHandler>(authenticationScheme, displayName, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="authenticationScheme"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static AuthenticationBuilder AddBearer(this AuthenticationBuilder builder,
            string authenticationScheme, Action<BearerOptions> options)
            => builder.AddBearer(authenticationScheme, null, options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static AuthenticationBuilder AddBearer(this AuthenticationBuilder builder,
            Action<BearerOptions> options)
            => builder.AddBearer(BearerDefaults.AuthenticationScheme, options);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static AuthenticationBuilder AddBearer(this AuthenticationBuilder builder)
            => builder.AddBearer(BearerDefaults.AuthenticationScheme, _ => { });
    }
}
