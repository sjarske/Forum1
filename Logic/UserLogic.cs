using DAL;
using DAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class UserLogic : IUser
    {
        private readonly IUser _context;
        public UserLogic()
        {
            _context = new UserSQLContext();

        }
        public User GetById(int id)
        {
            return _context.GetById(id);
        }

        public User GetUser(User user)
        {
            return _context.GetUser(user);
        }

        public IEnumerable<string> GetUserRoles(User user)
        {
            return _context.GetUserRoles(user);
        }

        public bool Login(User user)
        {
            return _context.Login(user);
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
