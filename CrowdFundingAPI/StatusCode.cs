using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingAPI
{
    public enum StatusCode
    {
        OK = 200,
        NotFound = 404,
        BadRequest = 400,
        InternalServerError = 500
    }
}
