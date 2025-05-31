using Domain.BaseEntity;
using Domain.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Capacity
{
    public class RoomCapacityHistory : BaseEntity<int>
    {
        public int RoomId { get; set; }
 
        public int Qty { get; set; }
        public bool State { get; set; }
        public DateTime from { get; set; }
        public DateTime? to { get; set; }
        public Room Room { get; set; }


        public RoomCapacityHistory() { }

        public RoomCapacityHistory(int roomId,int qty, DateTime From, DateTime? To ,bool state)
        {
            RoomId = roomId;
            Qty = qty;
            from = From;
            to = To;
            State = state;
        }
    }
}
