using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Domain.Models
{
    public class RoomModel : ModelBase
    {
        public string? Name { get; set; }
        public int Capacity { get; set; }
    }
}
