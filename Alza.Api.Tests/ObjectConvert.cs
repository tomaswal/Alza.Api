using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Tests
{
    internal class ObjectConvert
    {
        internal static T GetOkObject<T>(Microsoft.AspNetCore.Mvc.ActionResult result) where T : class
        {
            var rawResult = ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).Value;
            return (T)rawResult;
        }
    }
}
