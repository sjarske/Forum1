using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPost
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        void Create(Post post);
        void Delete(int id);
        Task EditPostContent(int id, string newContent);
        void LikePost(int id, int userid);
        int GetRatingById(int id);
        bool CheckLikeByUserId(int userid, int postid);
        void RemoveLike(int id, int userid);
    }
}
