﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationDemo.Security
{
    /// <summary>
    /// 定义特征类型。此类允许继承以方便追加自定义类型。
    /// </summary>
    public class ClaimTypes
    {
        /// <summary>
        /// 访问令牌
        /// </summary>
        public const string AccessToken = "http://www.csci.com.hk/identity/claims/AccessToken";

        /// <summary>
        /// 用户ID
        /// </summary>
        public const string UserId = System.Security.Claims.ClaimTypes.NameIdentifier;

        /// <summary>
        /// 用户名(账号)
        /// </summary>
        public const string UserName = System.Security.Claims.ClaimTypes.Name;

        /// <summary>
        /// 真实姓名
        /// </summary>
        public const string RealName = "http://www.csci.com.hk/identity/claims/RealName";

        /// <summary>
        /// 手机号码
        /// </summary>
        public const string MobilePhone = System.Security.Claims.ClaimTypes.MobilePhone;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public const string Email = System.Security.Claims.ClaimTypes.Email;
    }
}
