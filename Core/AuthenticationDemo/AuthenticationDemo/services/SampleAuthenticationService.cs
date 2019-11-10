using AuthenticationDemo.Authentication;
using AuthenticationDemo.Security.Session;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationDemo.services
{
    /// <summary>
    /// 验证服务的简单实现
    /// </summary>
    public class SampleAuthenticationService : IAuthenticationService
    {
        class User
        {
            internal int Id;
            internal string UserName;
            internal string Password;
            internal User(int id, string userName, string password)
            {
                Id = id;
                UserName = userName;
                Password = password;
            }
        }

        private readonly static List<Identity> _LstIdentity = new List<Identity>();
        private readonly IClaimsSession _Session;
        private readonly List<User> _LstUser = new List<User> {
            new User(1,"admin","12345"),
            new User(2,"user","123"),
            new User(3,"tester","123"),
        };

        public SampleAuthenticationService(IClaimsSession session)
        {
            this._Session = session;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>成功则返回身份证明</returns>
        public IIdentity Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var user = _LstUser.FirstOrDefault(p => p.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase) && p.Password == password);
            if (user == null)
                return null;

            var token = SimpleToken.NewToken(3600);
            var identity = new Identity(user.Id, user.UserName, token);
            _LstIdentity.Add(identity);

            return identity;
        }

        /// <summary>
        /// 注销登录，即使未登录也不报错
        /// </summary>
        public void Logout()
        {
            var identity = _LstIdentity.FirstOrDefault(p => p.UserId == _Session.UserId && p.AccessToken == _Session.AccessToken);
            if (identity != null)
                identity.Invalid = true;
        }

        /// <summary>
        /// 刷新令牌，如果未登录则报错
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public IToken RefreshToken(string refreshToken)
        {
            var identity = _LstIdentity.FirstOrDefault(p => p.AccessToken == _Session.AccessToken && p.RefreshToken == refreshToken && !p.Invalid);
            if (identity == null)
                throw new Exception("令牌刷新失败！请确认提供的令牌是否有效。");

            var token = SimpleToken.NewToken(identity.ExpireIn);
            identity.Merge(token);

            return token;
        }

        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns>成功则返回身份证明</returns>
        public IIdentity ValidateToken(string accessToken)
        {
            var identity = _LstIdentity.FirstOrDefault(p => p.AccessToken == _Session.AccessToken && !p.Invalid);

            return identity;
        }

    }
}
