using hms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Repository
{
    public class UsersRep : IUserRep
    {
        hmsContext db;

        public UsersRep(hmsContext _db)

        {

            db = _db;

        }
        public string  AddDetail(Users user)
        {
            db.Users.Add(user);

            db.SaveChanges();

             return user.Email;
        }

        public int Delete(string id)
        {
            int result = 0;

            if (db != null)

            {



                var post = db.Users.FirstOrDefault(x => x.Email == id);



                if (post != null)

                {



                    db.Users.Remove(post);

                    result = db.SaveChanges();

                    return 1;

                }

                return result;

            }



            return result;
        }

        public Users GetDetail(string id)
        {
            if (db != null)

            {

                return (db.Users.Where(x => x.Email == id)).FirstOrDefault();

            }

            return null;
        }

        public List<Users> GetDetails()
        {
            return db.Users.ToList();
        }

        public int UpdateDetail(string id, Users user)
        {
            if (db != null)

            {

                var obj = (db.Users.Where(x => x.Email == id)).FirstOrDefault();

                if (obj != null)

                {

                    obj.FirstName= user.FirstName;

                    obj.LastName = user.LastName;

                    obj.Password = user.Password;


                    db.SaveChanges();

                    return 1;

                }

                return 0;

            }

            return 0;
        }
    }
}
