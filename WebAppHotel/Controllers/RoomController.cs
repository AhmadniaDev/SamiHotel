using Application.Features.Rooms.Command;
using Application.Features.Rooms.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAppHotel.Controllers
{
    public class RoomController : Controller
    {
        private readonly IMediator _mediator;
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();

        }

        public async Task<IActionResult> GetList(int page = 1)
        {
            var res = await _mediator.Send(new GetRoomsQuery()
            {
                PageNumber = page,
                PageSize = 2

            });

            return PartialView(res);
        }

        public IActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRoom(CreateRoomCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }


    }
}
