using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Common;

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
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            // Puedes agregar más tipos de excepciones según sea necesario

            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
