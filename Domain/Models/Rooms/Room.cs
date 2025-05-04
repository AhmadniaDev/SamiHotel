using Domain.BaseEntity;
using Domain.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Rooms
{
    public class Room : BaseEntity<int>
    {
        //نام اتاق
        public string Name { get; set; }
        //چند نوع از این اتاق داریم
        public int? Qty { get; set; }
        //تخت اتاق
        public int? MainCapaciary { get; set; }
        //تخت اضافی
        public int? ExtraCapaciary { get; set; }
        //عکس هتل
        public string path { get; set; }
        //ویو هتل
        public int? View { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
