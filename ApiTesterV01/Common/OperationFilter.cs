using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace ApiTesterV01.Common
{
    public class ReApplyOptionalRouteParameterOperationFilter : IOperationFilter
    {
        const string captureName = "routeParameter";
        public void Apply(OpenApiOperation operation,OperationFilterContext context)
        {
            try
            {
                var httpMethodAttributes = context.MethodInfo
                  .GetCustomAttributes(true)
                  .OfType<Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute>();


                var httpMethodWithOptional = httpMethodAttributes?.FirstOrDefault(m => m.Template != null && m.Template.Contains("?"));
                if (httpMethodWithOptional == null)
                    return;
                string regex = $"{{(?<{captureName}>\\w+)\\?}}";
                var matches = Regex.Matches(httpMethodWithOptional.Template, regex);
                foreach (Match match in matches)
                {
                    var name = match.Groups[captureName].Value;
                    var parameter = operation.Parameters.FirstOrDefault(p => p.In == ParameterLocation.Path && p.Name == name);
                    if (parameter != null)
                    {
                        parameter.AllowEmptyValue = true;
                        parameter.Description = "You Can send empty value";
                        parameter.Required = false;
                        parameter.Schema.Nullable = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}

