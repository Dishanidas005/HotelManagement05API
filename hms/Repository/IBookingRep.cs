using hms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Repository
{
    public interface IBookingRep
    {
        public List<Booking> GetDetails();

        public Booking GetDetail(int id);

        public int AddDetail(Booking book);

       // public int UpdateDetail(int id, Booking book);

        public int Delete(int id);
    }
}
