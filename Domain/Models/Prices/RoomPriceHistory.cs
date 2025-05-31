using Domain.BaseEntity;
using Domain.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Prices
{
    public class RoomPriceHistory : BaseEntity<int> 
    {
        public int RoomId { get; set; }
        public long Price { get; set; }
        public long BedPrice { get; set; }
        public DateTime from { get; set; }
        public DateTime? to { get; set; }
        public Room Room { get; set; }


        public RoomPriceHistory() { }
        
        public RoomPriceHistory(int roomId, long price, long bedPrice, DateTime From, DateTime? To)
        {
            RoomId = roomId;
            Price = price;
            BedPrice = bedPrice;
            from = From;
            to = To;
        }
    }
}
