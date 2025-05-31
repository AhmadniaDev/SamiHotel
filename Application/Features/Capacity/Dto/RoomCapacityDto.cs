using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Capacity.Dto
{
    public class RoomCapacityDto
    {
        public List<RoomCapacityName> Rooms { get; set; }
        public List<DateTime> Days { get; set; }
    }

    public class RoomCapacityName
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public List<RoomCapacityList> RoomCapacitys { get; set; }
    }

    public class RoomCapacityList
    {
        public DateTime DateVal { get; set; }
        public int Qty { get; set; }
       
    }
}
