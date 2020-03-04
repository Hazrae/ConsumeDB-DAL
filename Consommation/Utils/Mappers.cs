using System;
using System.Collections.Generic;
using System.Text;
using d = DalDBSlide.Models;
using a = Consommation.Models;

namespace Consommation.Utils
{
    public static class Mappers
    {
        public static a.User ToLocal(this d.User u)
        {
            return new a.User
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                Password = u.Password
            };
        }

        public static d.User ToGlobal(this a.User u)
        {
            return new d.User
            {
                Id = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                Password = u.Password
            };
        }
    }
}
