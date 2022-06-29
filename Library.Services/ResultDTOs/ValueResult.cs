using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ResultDTOs
{
    public class ValueResult<T> : BaseResult
    {
        private ValueResult(ResultStatus status)
        {
            Status = status;
        }

        private ValueResult(T result)
        {
            Result = result;
            Status = ResultStatus.Ok;
        }

        public T Result { get; set; }

        public static ValueResult<T> Ok(T result)
        {
            return new ValueResult<T>(result);
        }

        public static ValueResult<T> NotFound(params string[] errors)
        {
            return new ValueResult<T>(ResultStatus.NotFound) { Errors = errors };
        }

        public static ValueResult<T> Error(params string[] errors)
        {
            return new ValueResult<T>(ResultStatus.Error) { Errors = errors };
        }
    }
}
