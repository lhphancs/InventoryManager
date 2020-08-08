using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Inventory.Api.Infrastructure
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidOperationException)
            {
                ApiError apiError = new ApiError(HttpStatusCode.BadRequest, context.Exception.Message);
                context.Result = new JsonResult(apiError);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            else
            {
                ApiError apiError = new ApiError(HttpStatusCode.InternalServerError, context.Exception.Message);
                context.Result = new JsonResult(apiError);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
           
            base.OnException(context);
        }

        public class ApiError
        {
            public ApiError(HttpStatusCode code, string message)
            {
                Code = code;
                Message = message;
            }

            public HttpStatusCode Code { get; private set; }
            public string Message { get; private set; }
        }
    }
}
