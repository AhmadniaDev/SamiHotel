using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class User : IdentityUser<int>
    {
        //نام کاربر
        public string? FirstName { get; set; }
        //نام خانوادگی کاربر
        public string? LastName { get; set; }
        // ارتباط بین هتل کاربر
        public int? HotelId { get; set; }
        //ارتباط کاربر با هتل
        public Hotels.Hotel Hotel { get; set; }
    }
}
