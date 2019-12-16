using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IForum
    {
        List<Post> GetPostsByForum(int id);
        IEnumerable<Forum> GetAll();
        Forum GetById(int id);
        Task Create(Forum forum);
        Task Delete(int forumId);
    }
}
