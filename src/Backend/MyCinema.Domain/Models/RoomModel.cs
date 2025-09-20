using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Domain.Models
{
    public class RoomModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Capacity { get; set; }
    }
}
