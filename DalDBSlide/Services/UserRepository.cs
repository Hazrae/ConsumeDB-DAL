using DalDBSlide.Models;
using DalDBSlide.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DalDBSlide.Services
{
    public class UserRepository : IRepository<User>
    {
        
        private const string ConnectionString = @"Data Source=FORMA-VDI1100\TFTIC;Initial Catalog=ExoDal;User ID=sa;Password=tftic@2012";

        private static IRepository<User> _instance;

        public static IRepository<User> Instance
        {
            get
            {
                return _instance ?? (_instance = new UserRepository());
            }
        }

        private SqlConnection _connection;

        private UserRepository()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }
        
        public List<User> GetAll()
        {
            List<User> l = new List<User>();
            
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users";
                   
                using (SqlDataReader dr = cmd.ExecuteReader())
                { 
                    while(dr.Read())
                    {
                        l.Add( new User
                        {
                            Id = (int)dr["Id"],
                            UserName = dr["UserName"].ToString(),
                            Email = dr["Email"].ToString(),
                            Password = dr["Password"].ToString()
                        });
                    }
                }
            }

            return l;
        }

        public User GetOne(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);
                User u = new User();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        u.Id = (int)dr["Id"];
                        u.UserName = dr["UserName"].ToString();
                        u.Email = dr["Email"].ToString();
                        u.Password = dr["Password"].ToString();

                    }
                }
                return u;
            }
        }

        public void Create(User t)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Users (UserName, Email, Password) " +
                                  "VALUES (@Username, @email, @pwd)";
                cmd.Parameters.AddWithValue("Username", t.UserName);
                cmd.Parameters.AddWithValue("email", t.Email);
                cmd.Parameters.AddWithValue("pwd", t.Password);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(User t)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE Users SET UserName = @Username, Email = @email, Password = @pwd " +
                                  "WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Username", t.UserName);
                cmd.Parameters.AddWithValue("email", t.Email);
                cmd.Parameters.AddWithValue("pwd", t.Password);
                cmd.Parameters.AddWithValue("Id", t.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
