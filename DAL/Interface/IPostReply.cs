using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IPostReply
    {
        List<PostReply> GetById(int id);
        void Create(PostReply postReply);
    }
}
