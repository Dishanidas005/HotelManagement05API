﻿using hms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hms.Repository
{
    public interface IUserRep
    {
        public List<Users> GetDetails();

        public Users GetDetail(string id);

        public string AddDetail(Users user);

        public int UpdateDetail(string id, Users user);

        public int Delete(string id);
    }
}
