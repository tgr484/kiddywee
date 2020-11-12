using Kiddywee.DAL.Data;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Kiddywee.Core
{
    public class CustomFilter : Attribute, IExceptionFilter, IActionFilter
    {
        readonly ApplicationDbContext _applicationDbContext;
        readonly IHttpContextAccessor _httpContextAccessor;
        public CustomFilter(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var appUserAction = AppUserAction.Create(
                context.HttpContext.Request.Path,
                null,
                context.HttpContext.Request.Method,
                _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                context.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                );
            if (context.HttpContext.Request.HasFormContentType)
            {                
                appUserAction.Value = Newtonsoft.Json.JsonConvert.SerializeObject(context.HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString()));
            }
            _applicationDbContext.AppUserActions.Add(appUserAction);
            _applicationDbContext.SaveChanges();
        }

        public void OnException(ExceptionContext context)
        {
            var appError = AppError.Create(
                context.HttpContext.Request.Path,
                context.Exception.StackTrace,
                context.Exception.Message,
                context.Exception.InnerException?.Message,
                context.HttpContext.Request.Method,
                _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
                context.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                );
            _applicationDbContext.AppErrors.Add(appError);
            _applicationDbContext.SaveChanges();
        }
    }
}
