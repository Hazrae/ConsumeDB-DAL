using Consommation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Consommation.Utils;
using Consommation.Services;

namespace Consommation
{
    class Program
    {
        static void Main(string[] args)
        {
            //User steve = new User
            //{
            //    UserName = "Steve",
            //    Email = "obiwan@jedi.noob",
            //    Password = "truc"
            //};

            //UserService.Instance.Create(steve);

            User userToUpdate = UserService.Instance.GetOne("Steve");

            userToUpdate.Email = "truc@machin.bidule";

            UserService.Instance.Update(userToUpdate);

            User u = UserService.Instance.GetOne(3);
            Console.WriteLine(u.UserName + " "+ u.Email);

            UserService.Instance.Delete(userToUpdate.Id);

            foreach (User user in UserService.Instance.GetAll())
            {
                Console.WriteLine(user.UserName);
            }


            Console.ReadLine();
        }
    }
}
