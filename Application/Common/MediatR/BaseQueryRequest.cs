using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.MediatR
{
    public class BaseQueryRequest
    {
        public string Search { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public bool DisablePaging { get; set; } = false;
    }
}
