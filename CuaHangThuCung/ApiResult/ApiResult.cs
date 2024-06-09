using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shares.ApiResult
{
    public class ApiResult
    {
        public int StatusCode { get; set; }
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
        public ApiResult(bool isSucceeded, string message, int statusCode)
        {
            Message = message;
            IsSucceeded = isSucceeded;
            StatusCode = statusCode;
        }
    }
}
