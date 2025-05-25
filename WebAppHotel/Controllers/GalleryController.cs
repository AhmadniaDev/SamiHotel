using Application.Features.HotelGalleries.Command;
using Application.Features.HotelGalleries.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppHotel.Controllers
{
    [Authorize(Roles = "modir")]
    public class GalleryController : Controller
    {
        private readonly IMediator _mediator;

        public GalleryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IActionResult>  Index()
        {   
            var res =await  _mediator.Send(new GetHotelImgesQuery());  
            
            return View(res);
        }

        [HttpPost]
         public async Task<IActionResult> SetImg(IFormFile file)
        {
            var Command = new CreateImgCommand()
            {
                file = file
            };

            await _mediator.Send(Command);
            return RedirectToAction("Index");
        }
    
         public async Task<IActionResult> RemoveImg(int id)
        {
            var Command = new RemoveImgCommand()
            {
                id = id   
            };

            await _mediator.Send(Command);
            return RedirectToAction("Index");
        }
    }
}
