using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.BaseEntity;
using System.Threading.Tasks;
using Domain.Models.Users;
using Domain.Models.HotelGalleries;
using Domain.Models.Rooms;

namespace Domain.Models.Hotels
{
    public class Hotel : BaseEntity<int>
    {
        //نام هتل
        public string Name { get; set; }
        //ایمیل هتل
        public string Email { get; set; }
        //تلفن هتل
        public string Phone { get; set; }
        //توضیحات هتل 
        public string Description { get; set; }
        //ستاره های هتل
        public int Star  { get; set; }
        //وضعیت فعال بودن هتل
        public bool State { get; set; }
        //ادرس هتل
        public string Address { get; set; }
        //شهر ها که باید بعدا داینامیک شه 
        public string City { get; set; }
        //ارتباط کاربر با هتل
        public ICollection<User>? Users { get; set; }
        public ICollection<HotelGallery>? HotelGalleries { get; set; }
        public ICollection<Room>? Rooms { get; set; }

    }
}
