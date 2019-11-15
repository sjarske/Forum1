using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using Models;

namespace Logic
{
    public class ForumLogic : IForum
    {
        private readonly IForum _context;

        public ForumLogic()
        {
            _context = new ForumSQLContext(); 
        }
        public Task Create(Forum forum)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.GetAll();
        }

        public Forum GetById(int id)
        {
            return _context.GetById(id);
        }
    }
}
