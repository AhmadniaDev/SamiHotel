using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.MediatR
{
    public class BaseCommandRequest : IPresetModel
    {
        [BindNever]
        public int? UserId { get; set; }
        [BindNever]
        public bool IsAdmin { get; set; }

    }
}
