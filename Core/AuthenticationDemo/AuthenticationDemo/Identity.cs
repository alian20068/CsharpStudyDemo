using AuthenticationDemo.Authentication;
using System;
using System.Collections.Generic;

namespace AuthenticationDemo
{
    /// <summary>
    /// 身份证明实现类
    /// </summary>
    public class Identity : IIdentity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public virtual long UserId { get; set; }

        #region 基本属性
        [Newtonsoft.Json.JsonIgnore]
        public virtual string UserIdentity => UserId.ToString();

        /// <summary>
        /// 用户账号
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual string Role { get; set; }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public virtual string AccessToken { get; set; }

        /// <summary>
        /// 颁发时间
        /// </summary>
        public virtual DateTime IssueTime { get; internal set; }

        /// <summary>
        /// 令牌有效时长（秒）
        /// </summary>
        public virtual int ExpireIn { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        public virtual string RefreshToken { get; set; }

        /// <summary>
        /// 是否已失效
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public bool Invalid { get; set; }

        /// <summary>
        /// 其他 Claims，供扩展使用
        /// </summary>
        public Dictionary<string, string> AdditionalClaims { get; set; } = new Dictionary<string, string>();
        #endregion


        #region 构造函数
        public Identity()
        {

        }
        public Identity(long userId, string userName, IToken token)
        {
            UserId = userId;
            UserName = userName;
            Merge(token);
        }
        #endregion

        /// <summary>
        /// 合并Token令牌到当前身份证
        /// </summary>
        /// <param name="token"></param>
        public void Merge(IToken token)
        {
            this.AccessToken = token.AccessToken;
            this.RefreshToken = token.RefreshToken;
            this.ExpireIn = token.ExpiresIn;
            this.IssueTime = token.IssueTime;
        }
    }
}
