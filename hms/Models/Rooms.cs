using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Models
{
    public class Rooms
    {[Key]

        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int price { get; set; }

    }
}
