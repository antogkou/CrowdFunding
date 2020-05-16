using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace FundRaiserMVC.Models
{
    public class MVSJwtTokens
    {
        public const string Issuer = "MVS";
        public const string Audience = "ApiUser";
        public const string Key = "1234567890123456";

        public const string AuthSchemes =
            "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}
