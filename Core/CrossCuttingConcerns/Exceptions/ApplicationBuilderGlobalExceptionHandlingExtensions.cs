using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public static class ApplicationBuilderGlobalExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseGlobalExtensionHandling(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
