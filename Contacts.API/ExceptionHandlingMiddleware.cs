using System.Net;

namespace Contacts.API
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Dictionary<Type, HttpStatusCode> _exceptionToStatusCodeMap;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;

            _exceptionToStatusCodeMap = new Dictionary<Type, HttpStatusCode>
        {
            { typeof(ArgumentNullException), HttpStatusCode.BadRequest },
            { typeof(KeyNotFoundException), HttpStatusCode.NotFound },
        };
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (_exceptionToStatusCodeMap.TryGetValue(ex.GetType(), out var statusCode))
                {
                    context.Response.StatusCode = (int)statusCode;
                    await context.Response.WriteAsync(ex.Message); 
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync("An unexpected error occurred.");
                }
            }
        }
    }
}
