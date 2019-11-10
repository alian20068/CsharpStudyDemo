using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
