using Application.Features.Hotels.Command;
using Application.Features.Hotels.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppHotel.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        private readonly IMediator _mediator;
        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _mediator.Send(new GetHotelQuery());

            return View(res);
        }

        [HttpPost]
        [Authorize(Roles = "modir")]
        public async Task<IActionResult> Hotel(UpdateHotelCommand command)
        {
            var res = await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
