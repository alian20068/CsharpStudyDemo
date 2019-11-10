namespace AuthenticationDemo.Authentication
{
    /// <summary>
    /// 验证服务接口
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>成功则返回身份证明</returns>
        IIdentity Login(string userName, string password);

        /// <summary>
        /// 注销登录，即使未登录也不报错
        /// </summary>
        void Logout();

        /// <summary>
        /// 刷新令牌，如果未登录则报错
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        IToken RefreshToken(string refreshToken);

        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns>成功则返回身份证明</returns>
        IIdentity ValidateToken(string accessToken);
    }
}
