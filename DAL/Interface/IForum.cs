using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IForum
    {
        IEnumerable<Forum> GetAll();
        Forum GetById(int id);
        Task Create(Forum forum);
        Task Delete(int forumId);
        List<Post> GetAscDateSortedPostsByForum(int id);
        List<Post> GetDescDateSortedPostsByForum(int id);
        List<Post> GetRatingSortedPostsByForum(int id);
    }
}
