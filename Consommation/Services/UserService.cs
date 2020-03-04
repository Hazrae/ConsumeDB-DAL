using Consommation.Models;
using Consommation.Utils;
using DalDBSlide.Repository;
using DalDBSlide.Services;
using d = DalDBSlide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consommation.Services
{
    public class UserService : IRepository<User>
    {
        private static UserService _instance;

        public static UserService Instance
        {
            get
            {
                return _instance ?? (_instance = new UserService());
            }
        }
        private IRepository<d.User> _dalInstance;
        private UserService()
        {
            _dalInstance = UserRepository.Instance;
        }

        public List<User> GetAll()
        {
            return _dalInstance.GetAll().Select(x => x.ToLocal()).ToList();
        }

        public User GetOne(int id)
        {
            return _dalInstance.GetOne(id).ToLocal();
        }

        public User GetOne(string nom)
        {
            return _dalInstance.GetAll().Where(x => x.UserName == nom).SingleOrDefault().ToLocal();
        }

        public void Create(User t)
        {
            _dalInstance.Create(t.ToGlobal());
        }

        public void Delete(int id)
        {
            _dalInstance.Delete(id);
        }

        public void Update(User t)
        {
            _dalInstance.Update(t.ToGlobal());
        }
    }
}
