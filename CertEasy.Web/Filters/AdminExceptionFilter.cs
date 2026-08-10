using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;

namespace CertEasy.Web.Filters
{
    public class AdminExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<AdminExceptionFilter> _logger;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public AdminExceptionFilter(ILogger<AdminExceptionFilter> logger, IModelMetadataProvider modelMetadataProvider)
        {
            _logger = logger;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.RouteData.Values["controller"]?.ToString() == "Admin")
            {
                _logger.LogError(context.Exception, "Unhandled exception in Admin area at {Path}", context.HttpContext.Request.Path);

                var result = new ViewResult { ViewName = "Error" }; // Use relative name to allow fallback search
                result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
                result.ViewData["ErrorMessage"] = "An unexpected error occurred in the administrative area. " + context.Exception.Message;
                
                context.Result = result;
                context.ExceptionHandled = true;
            }
        }
    }
}