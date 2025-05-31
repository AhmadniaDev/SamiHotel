using Application.Features.Capacity.Command;
using Application.Features.Capacity.Query;
using Application.Features.RoomPrices.Command;
using Application.Features.RoomPrices.Query;
using Application.Features.Rooms.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppHotel.Controllers
{
    public class RoomCapacityController : Controller
    {
        private readonly IMediator _mediator;
        public RoomCapacityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult>  Index()
        {
            var room = await _mediator.Send(new GetRoomsQuery() { DisablePaging = true });
            ViewBag.Rooms = new SelectList(room.Items, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> List(DateTime? start = null, string? week = null, [FromBody] List<int>? rooms = null)
        {
            start ??= DateTime.Now;
            if (!string.IsNullOrWhiteSpace(week))
            {
                if (week == "next")
                    start = start.Value.AddDays(7);
                if (week == "last")
                    start = start.Value.AddDays(-7);
            }
            var res = await _mediator.Send(new GetRoomCapacityQuery() { startDate = start.Value, rooms = rooms });
            ViewBag.start = start.ToString();
            return PartialView(res);
        }



        [Authorize(Roles = "modir")]
        public async Task<IActionResult> CreateViews()
        {
            var room = await _mediator.Send(new GetRoomsQuery() { DisablePaging = true });
            ViewBag.Rooms = new SelectList(room.Items, "Id", "Name");
            return PartialView();
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateRoomCapacity(CreateRoomCapacityCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateView(UpdateRoomCapacityCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

    }
}
