using System;

namespace AuthenticationDemo.Authentication
{
    /// <summary>
    /// 登录令牌的简化实现
    /// </summary>
    public class SimpleToken : IToken
    {
        /// <summary>
        /// 无参构造函数（用于json序列化/反序列化）
        /// </summary>
        public SimpleToken()
        {
            this.IssueTime = DateTime.Now;
        }
        /// <summary>
        /// 创建一个新的令牌
        /// </summary>
        /// <param name="accessToken">访问令牌</param>
        /// <param name="refreshToken">刷新令牌</param>
        /// <param name="expiresIn">令牌有效时间（秒）</param>
        public SimpleToken(string accessToken, string refreshToken, int expiresIn)
            : this()
        {
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
            this.ExpiresIn = expiresIn;
            this.IssueTime = DateTime.Now;
        }

        /// <summary>
        /// 访问令牌
        /// </summary>
        public virtual string AccessToken { get; set; }

        /// <summary>
        /// 令牌类型（默认Bearer）
        /// </summary>
        public virtual string TokenType { get; set; } = "bearer";

        /// <summary>
        /// 令牌有效时长（秒）
        /// </summary>
        public virtual int ExpiresIn { get; set; }

        /// <summary>
        /// 令牌颁发时间
        /// </summary>
        public virtual DateTime IssueTime { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        public virtual string RefreshToken { get; set; }

        /// <summary>
        /// 令牌失效时间
        /// </summary>
        public virtual DateTime ExpireTime => this.IssueTime.AddSeconds(ExpiresIn);

        /// <summary>
        /// 新令牌
        /// </summary>
        /// <param name="expiresIn">令牌有效时长（秒）</param>
        /// <returns></returns>
        public static SimpleToken NewToken(int expiresIn)
        {
            var accessToken = Guid.NewGuid().ToString("N");
            var refreshToken = Guid.NewGuid().ToString("N");

            var token = new SimpleToken(accessToken, refreshToken, expiresIn);
            return token;
        }
    }
}
