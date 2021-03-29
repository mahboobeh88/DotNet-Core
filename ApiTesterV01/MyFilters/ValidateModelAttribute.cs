
using ApiTesterV01.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ApiTesterV01.MyFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Response = context.Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, context.ModelState);
            }
        }
    }



}
