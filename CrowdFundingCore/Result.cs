using CrowdFundingCore.Models;
using System;

namespace CrowdFundingCore
{
    public class Result<T>
    {
        public StatusCode ErrorCode { get; set; }

        public string ErrorText { get; set; }

        public T Data { get; set; }

        public bool Success => ErrorCode == StatusCode.OK;


        public Result()
        { }

        public static Result<T> CreateSuccess(T data)
        {
            return new Result<T>()
            {
                ErrorCode = StatusCode.OK,
                Data = data
            };
        }

        public Result<U> ToResult<U>()
        {
            var res = new Result<U>()
            {
                ErrorCode = ErrorCode,
                ErrorText = ErrorText
            };

            return res;
        }

        public Result(StatusCode errorCode, string errorText)
        {
            ErrorCode = errorCode;
            ErrorText = errorText;
        }

        internal static Result<MyUsers> CreateSuccess()
        {
            throw new NotImplementedException();
        }
    }
}
