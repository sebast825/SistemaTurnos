using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Common;
using System.ComponentModel.DataAnnotations;

namespace SistemaTurnos.Filter
{
    public class ExceptionHandlerFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception is UnauthorizedAccessException)
            {
                context.Result = new UnauthorizedObjectResult(ErrorMessages.NoAccess);
            }

            else if (context.Exception is Exception)
            {
                context.Result = new ObjectResult("Error de base de datos")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            else if (context.Exception is ValidationException)
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }


        
    }
}
