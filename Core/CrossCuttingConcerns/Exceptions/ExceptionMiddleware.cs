using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next) {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
               await _next(httpContext);    
            }
            catch (Exception exception)
            {
                await handleExceptionAsync(httpContext, exception);
                
            }
        }
        private Task handleExceptionAsync(HttpContext httpContext,Exception exception)
        {
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            if(exception is BusinessException businessException) {
               return createBusinessProblemDetailsResponse(httpContext, businessException); 
            
            }
            if(exception is NotFoundException notFoundException)
            {
                return createNotFoundProblemDetailsResponse(httpContext,notFoundException);
            }
            if(exception is ValidationException validationException)
            {
                return createValidationProblemDetailsResponse(httpContext, validationException);
            }
            return createInternalProblemDetailResponse(httpContext,exception);
        }

        private Task createValidationProblemDetailsResponse(HttpContext httpContext, ValidationException validationException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            ValidationProblemDetails validationProblemDetails =
             new(
                 type: "https://doc.rentacar.com/validation-error",
                 title: "Validation Error",
                 instance: httpContext.Request.Path,
                 detail: "Please refer to the errors property for additional details.",
                 errors: validationException
                     .Errors.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                     .ToDictionary(
                         failureGroup => failureGroup.Key,
                         failureGroup => failureGroup.ToArray()
                     )
             )
             {
                 Status = StatusCodes.Status400BadRequest
             };

            return httpContext.Response.WriteAsync(validationProblemDetails.ToString());

        }

        private Task createNotFoundProblemDetailsResponse(HttpContext httpContext, NotFoundException notFoundException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            NotFoundProblemDetails notFoundProblemDetails = new NotFoundProblemDetails()
            {
                Title = "NotFound Exception",
                Status = StatusCodes.Status404NotFound,
                Detail = notFoundException.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(notFoundProblemDetails.ToString());
        }

        private Task createInternalProblemDetailResponse(HttpContext httpContext, Exception exception)
        {

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
           ProblemDetails problemDetails = new()
            {
                Title = "Internal Server Exception",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }

        private Task createBusinessProblemDetailsResponse(HttpContext httpContext,BusinessException businessException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            BusinessProblemDetails businessProblemDetails = new BusinessProblemDetails()
            {
                Title="Business Exception",
                Status=StatusCodes.Status400BadRequest,
                Detail=businessException.Message,
                Instance=httpContext.Request.Path
            };
           return httpContext.Response.WriteAsync(businessProblemDetails.ToString());           
        }
    }
}
