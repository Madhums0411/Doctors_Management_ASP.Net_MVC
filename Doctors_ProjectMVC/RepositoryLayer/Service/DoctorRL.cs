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
    public class DoctorRL : IDoctorRL
    {
        private SqlConnection sqlConnection;

        private IConfiguration configuration { get; }

        public DoctorRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DoctorModel AddDoctorDetails(int? UserID, DoctorModel doctorModel)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_Doctor_AddDetails", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@Profile", doctorModel.Profile);
                cmd.Parameters.AddWithValue("@Name", doctorModel.Name);
                cmd.Parameters.AddWithValue("@Age", doctorModel.Age);
                cmd.Parameters.AddWithValue("@Gender", doctorModel.Gender);
                cmd.Parameters.AddWithValue("@Qualification", doctorModel.Qualification);
                cmd.Parameters.AddWithValue("@Job_specification", doctorModel.Job_specification);
                cmd.Parameters.AddWithValue("@Experience_year", doctorModel.Experience_year);
                cmd.Parameters.AddWithValue("@Contact_number", doctorModel.Contact_number);
                cmd.Parameters.AddWithValue("@Doctor_fee", doctorModel.Doctor_fee);
                cmd.Parameters.AddWithValue("@Trash", doctorModel.Trash);
                this.sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result != 0)
                {
                    return doctorModel;
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
        public IEnumerable<DoctorModel> GetAllDoctor()
        {
            try
            {
                List<DoctorModel> doctorModel = new List<DoctorModel>();
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_Doctor_DoctorList", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                this.sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows) 
                { 
                    while(reader.Read())
                    {
                        DoctorModel model = new DoctorModel();
                        model.UserID = Convert.ToInt32(reader["UserID"]);
                        model.Doctor_id = Convert.ToInt32(reader["Doctor_id"]);
                        model.Profile = Convert.ToString(reader["Profile"]);
                        model.Name = Convert.ToString(reader["Name"]);
                        model.Age = Convert.ToInt32(reader["Age"]);
                        model.Gender = Convert.ToString(reader["Gender"]);
                        model.Qualification = Convert.ToString(reader["Qualification"]);
                        model.Job_specification = Convert.ToString(reader["Job_specification"]);
                        model.Experience_year = Convert.ToInt32(reader["Experience_year"]);
                        model.Contact_number = Convert.ToInt64(reader["Contact_number"]);
                        model.Doctor_fee = Convert.ToInt32(reader["Doctor_fee"]);
                        model.Trash = Convert.ToInt32(reader["Trash"]);
                        doctorModel.Add(model);
                    }
                    this.sqlConnection.Close();
                    return doctorModel;
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
        public DoctorModel GetDoctorDetail(int? UserID)
        {
            try
            {
                DoctorModel model = new DoctorModel();
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_Doctordetails_byId", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                this.sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                      
                        model.UserID = Convert.ToInt32(reader["UserID"]);
                        model.Doctor_id = Convert.ToInt32(reader["Doctor_id"]);
                        model.Profile = Convert.ToString(reader["Profile"]);
                        model.Name = Convert.ToString(reader["Name"]);
                        model.Age = Convert.ToInt32(reader["Age"]);
                        model.Gender = Convert.ToString(reader["Gender"]);
                        model.Qualification = Convert.ToString(reader["Qualification"]);
                        model.Job_specification = Convert.ToString(reader["Job_specification"]);
                        model.Experience_year = Convert.ToInt32(reader["Experience_year"]);
                        model.Contact_number = Convert.ToInt64(reader["Contact_number"]);
                        model.Doctor_fee = Convert.ToInt32(reader["Doctor_fee"]);
                        model.Trash = Convert.ToInt32(reader["Trash"]);

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
        public DoctorModel EditDoctorDetails(DoctorModel doctorModel)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_Doctor_Edit", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", doctorModel.UserID);
                cmd.Parameters.AddWithValue("@Profile", doctorModel.Profile);
                cmd.Parameters.AddWithValue("@Name", doctorModel.Name);
                cmd.Parameters.AddWithValue("@Age", doctorModel.Age);
                cmd.Parameters.AddWithValue("@Gender", doctorModel.Gender);
                cmd.Parameters.AddWithValue("@Qualification", doctorModel.Qualification);
                cmd.Parameters.AddWithValue("@Job_specification", doctorModel.Job_specification);
                cmd.Parameters.AddWithValue("@Experience_year", doctorModel.Experience_year);
                cmd.Parameters.AddWithValue("@Contact_number", doctorModel.Contact_number);
                cmd.Parameters.AddWithValue("@Doctor_fee", doctorModel.Doctor_fee);
                this.sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result != 0)
                {
                    return doctorModel;
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
