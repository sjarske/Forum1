using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class PostSQLContext : IPost
    {
        private readonly string _connectionString = @"Server=mssql.fhict.local;Database=dbi389621_forum;User Id=dbi389621_forum;Password=sjors;";

        public void Create(Post post)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spCreatePost", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ForumId", post.Forum.Id));
                command.Parameters.Add(new SqlParameter("@Title", post.Title));
                command.Parameters.Add(new SqlParameter("@UserId", post.User.Id));
                command.Parameters.Add(new SqlParameter("@Content", post.Content));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeletePost", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            Post post = new Post();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spGetPostById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    post.Id = id;
                    post.Title = (string)reader["Title"];
                    post.Content = (string)reader["Content"];
                    post.Created = (DateTime)reader["Created"];
                    post.Forum.Id = (int)reader["ForumId"];
                    post.User.Id = (int)reader["UserId"];
                }
            }
            return post;
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            throw new NotImplementedException();
        }
    }
}
