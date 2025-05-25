using Application.Common.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoomPrices.Command
{
    public class CreateRoomPriceCommand : BaseCommandRequest, IRequest<bool>
    {
        public string form { get; set; }
        public string to { get; set; }
        public long Price { get; set; }
        public long BedPrice { get; set; }
        public List<int> Rooms { get; set; }
    }
}
