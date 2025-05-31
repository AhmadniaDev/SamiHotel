using Application.Common.MediatR;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Capacity.Command
{
    public class CreateRoomCapacityCommand : BaseCommandRequest, IRequest<bool>
    {
        public string form { get; set; }
        public string to { get; set; }
        public int Qty { get; set; }
        public bool State { get; set; }
        public List<int> Rooms { get; set; }
    }
}
