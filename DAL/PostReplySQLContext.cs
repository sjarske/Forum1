using DAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class PostReplySQLContext : IPostReply
    {
        private readonly string _connectionString = @"Server=mssql.fhict.local;Database=dbi389621_forum;User Id=dbi389621_forum;Password=sjors;";

        public void Create(PostReply postReply)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("spCreatePostReply", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@PostId", postReply.Post.Id));
                command.Parameters.Add(new SqlParameter("@UserId", postReply.User.Id));
                command.Parameters.Add(new SqlParameter("@Content", postReply.Content));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<PostReply> GetById(int id)
        {
            var replies = new List<PostReply>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("spGetAllRepliesById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    replies.Add(new PostReply
                    {
                        Id = (int)reader["Id"],
                        Post = new Post { Id = (int)reader["PostId"] },
                        User = new User { Id = (int)reader["UserId"] },
                        Created = (DateTime)reader["Created"],
                        Content = (string)reader["Content"]
                    });
                }
            }
            return replies;
        }
    }
}
