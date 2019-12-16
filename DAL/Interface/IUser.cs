using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IUser
    {
        User GetById(int id);
        void Register(User user);
        bool Login(User user);
        User GetUser(User user);
        IEnumerable<string> GetUserRoles(User user);
    }
}
