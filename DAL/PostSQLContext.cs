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

        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            var posts = new List<Post>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spGetPostsByForum", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    posts.Add(new Post
                    {
                        Id = (int)reader["Id"],
                        ForumId= (int)reader["ForumId"],
                        Created= (DateTime)reader["Created"],
                        Title= (string)reader["Title"],
                        Content=(string)reader["Content"]
                    });
                }
            }
            return posts;
        }
    }
}
