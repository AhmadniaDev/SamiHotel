using Microsoft.AspNetCore.Mvc;
using Domain.Models.Hotels;

namespace WebApp.Controllers
{
    public class HotelController : Controller
    {
        private static List<Hotel> _hotels = new List<Hotel>();
        private static int _idCounter = 1;

        // لیست هتل‌ها
        public IActionResult Index()
        {
            return View(_hotels);
        }

        // صفحه ایجاد هتل
        public IActionResult Create()
        {
            return View();
        }

        // عملیات ایجاد هتل
        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
        
            _hotels.Add(hotel);
            return RedirectToAction(nameof(Index));
        }

        // صفحه ویرایش هتل
        public IActionResult Edit(int id)
        {
            var hotel = _hotels.FirstOrDefault(x => x.Id == id);
            if (hotel == null) return NotFound();
            return View(hotel);
        }

        // عملیات ویرایش هتل
        [HttpPost]
        public IActionResult Edit(Hotel updatedHotel)
        {
            var hotel = _hotels.FirstOrDefault(x => x.Id == updatedHotel.Id);
            if (hotel == null) return NotFound();

            hotel.Name = updatedHotel.Name;
            hotel.Email = updatedHotel.Email;
            hotel.Phone = updatedHotel.Phone;
            hotel.Description = updatedHotel.Description;
            hotel.Star = updatedHotel.Star;
            hotel.State = updatedHotel.State;
            hotel.Address = updatedHotel.Address;
            hotel.City = updatedHotel.City;

            return RedirectToAction(nameof(Index));
        }

        // حذف هتل
        public IActionResult Delete(int id)
        {
            var hotel = _hotels.FirstOrDefault(x => x.Id == id);
            if (hotel == null) return NotFound();

            _hotels.Remove(hotel);
            return RedirectToAction(nameof(Index));
        }

        // نمایش اطلاعات یک هتل
        public IActionResult Details(int id)
        {
            var hotel = _hotels.FirstOrDefault(x => x.Id == id);
            if (hotel == null) return NotFound();

            return View(hotel);
        }
    }
}
