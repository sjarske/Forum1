using DAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class UserSQLContext : IUser
    {
        private readonly string _connectionString = @"Server=mssql.fhict.local;Database=dbi389621_forum;User Id=dbi389621_forum;Password=sjors;";

        public User GetById(int id)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("spGetUserById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user.Id = id;
                    user.Username = (string)reader["Username"];
                    user.Email = (string)reader["Email"];
                }
            }
            return user;
        }

        public User GetUser(User _user)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spLogin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", _user.Username));
                command.Parameters.Add(new SqlParameter("@Password", _user.Password));
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user.Id = (int)reader["UserId"];
                    user.Username = (string)reader["Username"];
                    user.Email = (string)reader["Email"];
                }
                reader.Close();
            }
            return user;
        }

        public IEnumerable<string> GetUserRoles(User user)
        {
            var roles = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spGetUserRoles", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", user.Username));
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    roles.Add(reader["AuthorizationName"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            return roles;
        }

        public bool Login(User user)
        {
            bool loginSuccesfull = false;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spLogin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Username", user.Username));
                command.Parameters.Add(new SqlParameter("@Password", user.Password));
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    loginSuccesfull = true;
                }
                reader.Close();
            }
            return loginSuccesfull;
        }

        public void Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
