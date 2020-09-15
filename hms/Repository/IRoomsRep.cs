using hms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Repository
{
    public interface IRoomsRep
    {
        public List<Rooms> GetDetails();

        public Rooms GetDetail(int id);

        public int AddDetail(Rooms room);

       // public int UpdateDetail(int id, Rooms room);

        public int Delete(int id);
    }
}
