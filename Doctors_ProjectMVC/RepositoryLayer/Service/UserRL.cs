using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL :IUserRL
    {
        private SqlConnection sqlConnection;
        private IConfiguration Configuration { get; }
        public UserRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public UserModel UserRegister(UserModel user)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.Configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_user_insert", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Role_Id", user.Role_Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email_id", user.Email_id);
                this.sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result != 0)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            
            }
            catch (Exception)
            {

                throw;
            }

        }

        public UserModel UserLogin(LoginModel loginModel)
        {
            try
            {
                UserModel model = new UserModel();
                this.sqlConnection = new SqlConnection(this.Configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_user_login", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email_id", loginModel.Email_id);
                cmd.Parameters.AddWithValue("@Password", loginModel.Password);
                this.sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        //UserModel model = new UserModel();
                        model.UserID = Convert.ToInt32(reader["UserID"]);
                        model.Role_Id = Convert.ToInt32(reader["Role_Id"]);
                        model.Name = Convert.ToString(reader["Name"]);
                        model.Password = Convert.ToString(reader["Password"]);
                        model.Email_id = Convert.ToString(reader["Email_id"]);
                      
                    }
                    this.sqlConnection.Close();
                    return model;
                }
                
                else 
                { 
                    return null; 
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<GetUser> GetAllUser()
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.Configuration["ConnectionStrings:Doctors_DB"]);
                List<GetUser> users = new List<GetUser>();
                SqlCommand cmd = new SqlCommand("SP_user_Retrieve", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("Role_Id", Role_Id);
                this.sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
             
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GetUser user = new GetUser();
                        user.Role_Id = Convert.ToInt32(reader["Role_Id"]);
                        user.UserID = Convert.ToInt32(reader["UserID"]);
                        user.Name = Convert.ToString(reader["Name"]);
                        user.Email_id = Convert.ToString(reader["Email_id"]);
                        user.Password = Convert.ToString(reader["Password"]);
                        users.Add(user);
                    }
                    this.sqlConnection.Close();
                    return users;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public GetUser GetUserDetails(int? UserID)
        {
            try
            {
                GetUser user = new GetUser();
                this.sqlConnection = new SqlConnection(this.Configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_userbyID", this.sqlConnection);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                this.sqlConnection.Open ();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.UserID = Convert.ToInt32(reader["UserID"]);
                        user.Role_Id = Convert.ToInt32(reader["Role_Id"]);
                        user.Name = Convert.ToString(reader["Name"]);
                        user.Email_id = Convert.ToString(reader["Email_id"]);
                        user.Password = Convert.ToString(reader["Password"]);
                    }
                    this.sqlConnection.Close();
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public GetUser UpdateUser(GetUser user)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.Configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_user_update", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID",user.UserID);
                cmd.Parameters.AddWithValue("@Role_Id", user.Role_Id);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email_id", user.Email_id);
                this.sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result != 0)
                {
                    return user;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public GetUser DeleteUser(int? UserID)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.Configuration["ConnectionStrings:Doctors_DB"]);
                GetUser users = new GetUser();
                SqlCommand cmd = new SqlCommand("SP_user_delete", this.sqlConnection);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserID", UserID);
                this.sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result != 0)
                {
                    return users;
                }
                else 
                { 
                    return null; 
                }  
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
