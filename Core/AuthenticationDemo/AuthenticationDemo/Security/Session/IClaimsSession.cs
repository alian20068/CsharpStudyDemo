using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationDemo.Security.Session
{
    /// <summary>
    /// 会话信息接口
    /// </summary>
    interface IClaimsSession
    {
        /// <summary>
        /// 访问令牌
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// 用户ID
        /// </summary>
        long? UserId { get; }

        /// <summary>
        /// 用户名(账号)
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        string RealName { get; }

        /// <summary>
        /// 手机号码
        /// </summary>
        string MobilePhone { get; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        string Email { get; }
    }
}
