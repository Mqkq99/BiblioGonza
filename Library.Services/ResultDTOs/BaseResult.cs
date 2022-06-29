using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.ResultDTOs
{
    public class BaseResult
    {
        public ResultStatus Status { get; set; }

        public bool Success => Status == ResultStatus.Ok;

        public IEnumerable<string> Errors { get; init; } = new List<string>();
    }
}
