using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
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
            var forum = new Forum();
            var postList = new List<Post>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spGetForumById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    forum.Id = (int)reader["Id"];
                    forum.Title = (string)reader["Title"];
                    forum.Description = (string)reader["Description"];
                    forum.Created = (DateTime)reader["Created"];
                    forum.ImageUrl = (string)reader["ImageUrl"];                 
                }
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spGetPostsByForumId", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    postList.Add(new Post
                    {
                        Id = (int)reader["Id"],
                        ForumId= (int)reader["ForumId"],
                        Title= (string)reader["Title"],
                        Content = (string)reader["Content"],
                        Created = (DateTime)reader["Created"]
                    });
                }
            }
            forum.Posts = postList;
            return forum;
        }
    }
}
