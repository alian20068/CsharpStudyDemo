using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace AuthenticationDemo.Authentication
{
    /// <summary>
    /// 验证结果上下文
    /// </summary>
    public class BearerValidatedContext : ResultContext<BearerOptions>
    {
        public BearerValidatedContext(HttpContext context, AuthenticationScheme scheme, BearerOptions options)
            : base(context, scheme, options)
        {

        }
    }
}
