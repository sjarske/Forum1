using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IForum
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();

        Task Create(Forum forum);
        Task Delete(int forumId);
    }
}
