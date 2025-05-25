using Application.Common.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RoomPrices.Command
{
    public class UpdateRoomPriceCommand : BaseCommandRequest, IRequest<bool>
    {
        public List<priceList> priceListss { get; set; }
    }
    public class priceList
    {
        public DateTime DateVal { get; set; }
        public long Price { get; set; }
        public long BedPrice { get; set; }
        public int RoomId { get; set; }
    }

}
