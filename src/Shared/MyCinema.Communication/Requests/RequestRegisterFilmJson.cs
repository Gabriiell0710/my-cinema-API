using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Communication.Requests
{
    public class RequestRegisterFilmJson
    {
        public string Title { get; set; }
        public string Gender { get; set; }
        public int Duration { get; set; }
        public string Classification {  get; set; } 
    }
}
