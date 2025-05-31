using Application.Common.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Capacity.Command
{
    public class UpdateRoomCapacityCommand : BaseCommandRequest, IRequest<bool>
    {
        public List<CapacityList>? CapacityListss { get; set; }
    }
    public class CapacityList
    {
        public DateTime DateVal { get; set; }
        public int Qty { get; set; }
       
        public int RoomId { get; set; }
    }
}
