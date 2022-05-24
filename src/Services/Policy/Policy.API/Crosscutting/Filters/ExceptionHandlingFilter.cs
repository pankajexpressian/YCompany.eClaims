using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System;
using System.Text.Encodings;
using System.Text.Unicode;
using System.Text;
using Newtonsoft.Json;

namespace Policy.API.Crosscutting.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var apiResponse = new ApiResponse();

            var exception = context.Exception;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            apiResponse.MetaData = new ApiResponseMetaData()
            {
                Message = exception.Message,
                Staus = ApiResponseConstants.ErrorStatus,
                StausCode = ApiResponseConstants.ErrorStatusCode,
            };
            var serialzed = JsonConvert.SerializeObject(apiResponse);
            context.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(serialzed));
            context.ExceptionHandled = true;
        }
    }

    public class ExceptionHandlingFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var apiResponse = new ApiResponse();

            var exception = context.Exception;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            apiResponse.MetaData = new ApiResponseMetaData()
            {
                Message = exception.Message,
                Staus = ApiResponseConstants.ErrorStatus,
                StausCode = ApiResponseConstants.ErrorStatusCode,
            };
            var serialzed = JsonConvert.SerializeObject(apiResponse);
            context.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(serialzed));
            context.ExceptionHandled = true;
        }
    }
}
