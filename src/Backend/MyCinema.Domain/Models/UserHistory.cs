using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Domain.Models
{
    internal class UserHistory :ModelBase
    {
        public int UserId { get; set; }
        public string  Film { get; set; }
        public string Room { get; set; }
        public DateTime DateAndTime { get; set; }

    }
}
