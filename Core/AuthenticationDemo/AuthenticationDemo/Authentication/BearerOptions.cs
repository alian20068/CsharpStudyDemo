using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationDemo.Authentication
{
    /// <summary>
    /// 身份验证选项类
    /// </summary>
    public class BearerOptions : AuthenticationSchemeOptions
    {
        public BearerOptions()
        {
            ClaimsIssuer = "My Self!!!";
        }

        public bool RequireHttpsMetaData { get; internal set; }
    }
}
