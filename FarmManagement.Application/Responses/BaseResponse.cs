using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmManagement.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
            StatusCode = 200;
        }
        public BaseResponse(string message)
        {
            Success = true;
            StatusCode = 200;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }
        public BaseResponse(int statusCode,string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? ValidationErrors { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Resource not found",
                500 => "Server error",
                200 => "Success",
                _ => null
            };
        }
    }
}
