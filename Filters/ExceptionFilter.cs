using System.Net;
using LivrariaPlus.Api.Communication.Exceptions;
using LivrariaPlus.Api.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LivrariaPlus.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is LivrariaPlusException)
            {
                HandleProjectException(context);
            }
            else
            {
                HandleUnknownException(context);
            }
        }

        private static void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException exception)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ErrorResponseJson(exception.ErrorMessages));
            }
        }

        private static void HandleUnknownException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ErrorResponseJson(["Internal server error. Try again later."]));
        }
    }
}