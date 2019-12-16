using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    public class ForumSQLContext : IForum
    {
        private readonly string _connectionString = @"Server=mssql.fhict.local;Database=dbi389621_forum;User Id=dbi389621_forum;Password=sjors;";

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            var forums = new List<Forum>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spGetAllForums", connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    forums.Add(new Forum
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"],
                        Created = (DateTime)reader["Created"],
                        ImageUrl = (string)reader["ImageUrl"]
                    });
                }
            }
            return forums;
        }

        public Forum GetById(int id)
        {
            Forum forum = new Forum();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spGetForumById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    forum.Id = id;
                    forum.Title = (string)reader["Title"];
                    forum.Description = (string)reader["Description"];
                    forum.ImageUrl = (string)reader["ImageUrl"];
                }
                return forum;
            }
        }

        public List<Post> GetPostsByForum(int id)
        {
            var newForum = new List<Post>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spGetPostsByForumId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    newForum.Add(new Post
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"],
                        Created = (DateTime)reader["Created"],
                        Content = (string)reader["Content"],
                        User = new User { Id = (int)reader["UserId"] },
                        Forum = new Forum { Id = (int)reader["ForumId"] }
                    });
                }
            }
            return newForum;
        }
    }
}
