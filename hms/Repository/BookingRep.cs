using hms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Repository
{
    public class BookingRep : IBookingRep
    {
        hmsContext db;

        public BookingRep(hmsContext _db)

        {

            db = _db;

        }
        public int AddDetail(Booking book)
        {
            {
                db.Bookings.Add(book);

                db.SaveChanges();

                return book.BookingId;
            }

        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)

            {



                var post = db.Bookings. FirstOrDefault(x => x.BookingId == id);



                if (post != null)

                {



                    db.Bookings.Remove(post);

                    result = db.SaveChanges();

                    return 1;

                }

                return result;

            }



            return result;
        }

        public Booking GetDetail(int id)
        {

            if (db != null)

            {

                return (db.Bookings.Where(x => x.BookingId == id)).FirstOrDefault();

            }

            return null;
        }

        public List<Booking> GetDetails()
        {
            return db.Bookings.ToList();
        }
    }
}
