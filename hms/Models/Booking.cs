using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Models
{
    public class Booking
    {[Key]


        public int BookingId { get; set; }
        public string emailId { get; set; }
        public int RoomID { get; set; }

    }
}
