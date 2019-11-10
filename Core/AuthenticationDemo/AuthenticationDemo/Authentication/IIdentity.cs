using System;
using System.Collections.Generic;

namespace AuthenticationDemo.Authentication
{
    /// <summary>
    /// 身份证明接口
    /// </summary>
    public interface IIdentity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <remarks>接口中使用string类型，实现类使用long或Guid都可以，转换为string来实现接口即可</remarks>
        string UserIdentity { get; }

        /// <summary>
        /// 用户名
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// 角色
        /// </summary>
        string Role { get; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// 颁发时间
        /// </summary>
        DateTime IssueTime { get; }

        /// <summary>
        /// 令牌有效时长（秒）
        /// </summary>
        int ExpireIn { get; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        string RefreshToken { get; }

        /// <summary>
        /// 是否失效
        /// </summary>
        bool Invalid { get; }

        /// <summary>
        /// 其他 Claims，供扩展使用
        /// </summary>
        Dictionary<string ,string> AdditionalClaims { get; set; }
    }
}
