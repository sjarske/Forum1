using DAL;
using DAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class PostReplyLogic : IPostReply
    {
        private readonly IPostReply _context;
        private readonly IUser _userContext;

        public PostReplyLogic()
        {
            _context = new PostReplySQLContext();
            _userContext = new UserSQLContext();

        }
        public void Create(PostReply postReply)
        {
            _context.Create(postReply);
        }

        public List<PostReply> GetById(int id)
        {
            var returnedList = _context.GetById(id);
            for (int i = 0; i < returnedList.Count; i++)
            {
                returnedList[i].User = _userContext.GetById(returnedList[i].User.Id);
            }
            return returnedList;
        }
    }
}
