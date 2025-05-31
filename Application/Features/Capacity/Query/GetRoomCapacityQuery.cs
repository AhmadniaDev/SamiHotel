using Application.Common.MediatR;
using Application.Features.Capacity.Dto;
using Application.Features.RoomPrices.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Capacity.Query
{
    public class GetRoomCapacityQuery : BaseCommandRequest, IRequest<RoomCapacityDto>
    {
        public DateTime startDate { get; set; }
        public List<int>? rooms { get; set; }
    }
}
