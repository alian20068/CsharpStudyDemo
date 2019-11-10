using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AuthenticationDemo.Authentication
{
    /// <summary>
    /// 自己实现的身份验证处理器
    /// </summary>
    public class BearerHandler : AuthenticationHandler<BearerOptions>
    {
        private const string KEY_AUTHORIZATION = "authorization";
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAuthenticationService authService;

        public BearerHandler(IHttpContextAccessor httpContextAccessor,
            IAuthenticationService authService,
            IOptionsMonitor<BearerOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.authService = authService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            /*
            if (Thread.CurrentPrincipal != null)
            {
                //这个地方特别留意：如果不将现有的Thread.CurrentPrincipal设为null，当令牌为空或过期时，将会取到错误的Session。
                Thread.CurrentPrincipal = null;
            }*/
            //从请求头获取token
            string accessToken = Request.Headers[KEY_AUTHORIZATION];
            //如果没有，则从请求参数中获取
            if (string.IsNullOrEmpty(accessToken))
            {
                accessToken = Request.Query[KEY_AUTHORIZATION];
            }
            //如果没有，返回无结果
            if (string.IsNullOrEmpty(accessToken))
            {
                if (Request.Method != "OPTIONS")
                    Logger.LogInformation("请求头authorization为空，目标路径：" + Request.Path);
                return AuthenticateResult.NoResult();
            }
            this.Logger.LogDebug("accessToken:" + accessToken);

            IIdentity identity;
            try
            {
                identity = authService.ValidateToken(accessToken);//验证令牌是否有效
                System.Diagnostics.Debug.Assert(identity?.AccessToken == accessToken);
            }
            catch (Exception ex)
            {
                this.Logger.LogDebug(accessToken + " validate failed: " + ex.Message);
                return AuthenticateResult.Fail(ex.Message);
            }
            if (identity == null) //如果验证失败(例如令牌无效或是过期)，不要返回错误，返回无结果就行了。
            {
                //因为有可能发生这样的场景：前端在访问登录接口时附上了过期的令牌，但应该放行，只要不给httpContextAccessor.HttpContext.User赋值就行了，因为后面还会有权限校验。
                return AuthenticateResult.NoResult();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, identity.UserName),
                new Claim(ClaimTypes.NameIdentifier, identity.UserIdentity.ToString()),
                new Claim(Security.ClaimTypes.AccessToken, identity.AccessToken)
            };
            if (identity.Role != null)
            {
                new Claim(ClaimTypes.Role, identity.Role);
            }
            if (identity.AdditionalClaims != null)
            {
                foreach (var item in identity.AdditionalClaims)
                {
                    if (item.Value != null)
                        claims.Add(new Claim(item.Key, item.Value));
                }
            }
            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Bearer"));
            var validatedContext = new BearerValidatedContext(Context, Scheme, Options)
            {
                Principal = principal,
                //SecurityToken = validatedToken
            };
            //验证成功
            validatedContext.Success();
            /* 为了提高并发能力，通常会在控制器类中使用异步方法。调用异步方法时，会获取一个新线程来执行，待方法返回时,
               再重新从线程池中恢复一个线程作为当前线程，所以不适合通过Thread.CurrentPrincipal保存用户信息。
               使用注入的IHttpContextAccessor实例来获取本次HTTP请求上下文，在不同的线程中都会获取该类的同一实例。
            Thread.CurrentPrincipal = principal;
            */
            httpContextAccessor.HttpContext.User = principal;
            var result = validatedContext.Result;
            this.Logger.LogDebug(accessToken + " is valid! user name: " + identity.UserName);
            return result;
            //foreach (var validator in Options.SecurityTokenValidators)
        }
    }
}
