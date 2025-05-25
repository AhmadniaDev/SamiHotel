using Application.Common.MediatR;
using Application.Features.Hotels.Command;
using Application.Features.Rooms.Command;
using Application.Features.Rooms.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAppHotel.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "modir")]
        public async Task<IActionResult> GetList(int page = 1 , string? search = null)
        {
            var res = await _mediator.Send(new GetRoomsQuery()
            {
                PageNumber = page,
                PageSize = 3,
                Search = search
            });
      
            ViewBag.search = search;
            return PartialView(res);
        }
        [Authorize(Roles = "modir")]
        public IActionResult Create()
        {
            return PartialView();
        }


        [HttpPost]
        [Authorize(Roles = "modir")]
        public async Task<IActionResult> CreateRoom(CreateRoomCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }


        [Authorize(Roles = "modir")]
        public async Task<IActionResult> UpdateView(int id , int page)
        {
            var res = await _mediator.Send(new GetRoomByIdQuery() { Id = id});
            ViewBag.page = page;
            return PartialView(res);
        }

        [HttpPost]
        [Authorize(Roles = "modir")]
        public async Task<IActionResult> UpdateRoom(UpdateRoomCommand command)
        {
            var res = await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "modir")]
        public async Task<IActionResult> DeleteRoom([FromBody] DeleteRoomCommand command)
        {
            var res = await _mediator.Send(command);
            return RedirectToAction("Index");
        }

    }
}
