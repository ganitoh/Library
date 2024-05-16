using FluentValidation;
using Library.Application.Common.Exceptions;
using Library.Persistance.Exception;
using System.Net;

namespace Library.WebAPI.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next,
            ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async void InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex.Message);
                await BadRequestClientHandler(ex,context);
            }
            catch (PasswordUncorrectException ex)
            {
                _logger.LogInformation(ex.Message);
                await BadRequestClientHandler(ex, context);
            }
            catch (ValidationException ex)
            {
                _logger.LogInformation(ex.Message);
                await BadRequestClientHandler(ex, context);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                await ServerErrorClientHandler(ex, context);
            }
        }

        private async Task ServerErrorClientHandler(Exception ex, HttpContext context)
        {
            var response = new
            {
                code = HttpStatusCode.InternalServerError,
                message = ex.Message,
            };

            context.Response.StatusCode = (int)response.code;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(response);
        }

        private async Task BadRequestClientHandler(Exception ex, HttpContext context)
        {
            var response = new
            {
                code = HttpStatusCode.BadRequest,
                message = ex.Message,
            };

            context.Response.StatusCode = (int)response.code;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
