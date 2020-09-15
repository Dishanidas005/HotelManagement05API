using hms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Repository
{
    public class RoomsRep : IRoomsRep

    {
        hmsContext db;

        public RoomsRep(hmsContext _db)

        {

            db = _db;

        }
        public int AddDetail(Rooms room)
        {
            db.Rooms.Add(room);

            db.SaveChanges();

            return room.RoomId;
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)

            {



                var post = db.Rooms.FirstOrDefault(x => x.RoomId == id);



                if (post != null)

                {



                    db.Rooms.Remove(post);

                    result = db.SaveChanges();

                    return 1;

                }

                return result;

            }



            return result;
        }



        public Rooms GetDetail(int id)
        {
            if (db != null)

            {

                return (db.Rooms.Where(x => x.RoomId == id)).FirstOrDefault();

            }

            return null;
        }
        public List<Rooms> GetDetails()
        {
            return db.Rooms.ToList();
        }
    }
}




