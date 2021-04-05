using JWT.Builder;
using JWT.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.MyFilters
{
    public class ActionFilters : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Guid userId;
            var jwt = context.HttpContext.Request.Headers["JWT"];
            try
            {
                var json = new JwtBuilder()
                    .WithSecret("THIS OK ABCD OL TEST AND AERIFY ABC AAKENS, REPLACE IT WITH YOUN PLK SECRET, IT CAN BE ANY STRING")
                    .MustVerifySignature()
                    .Decode(jwt);

                var tokenDetails = JsonConvert.DeserializeObject<dynamic>(json);
            }
            catch (TokenExpiredException)
            {
                throw new Exception("Token is expired");
            }
            catch (SignatureVerificationException)
            {
                throw new Exception("Token signature invalid");
            }
            catch (Exception ex)
            {
                throw new Exception("Token has been tempered with");
            }
            var result = await next();
            // execute any code after the action executes
        }
    }
}
