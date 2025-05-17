using Application.Common.MediatR;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rooms.Command
{
    public class UpdateRoomCommand : BaseCommandRequest , IRequest<bool>
    {
        public int id { get; set; }
        //نام اتاق
        public string Name { get; set; }
        //چند نوع از این اتاق داریم
        public int? Qty { get; set; }
        //تخت اتاق
        public int? MainCapaciary { get; set; }
        //تخت اضافی
        public int? ExtraCapaciary { get; set; }
        //عکس هتل
        public IFormFile? path { get; set; }
        //ویو هتل
        public int? View { get; set; }
    }
}
