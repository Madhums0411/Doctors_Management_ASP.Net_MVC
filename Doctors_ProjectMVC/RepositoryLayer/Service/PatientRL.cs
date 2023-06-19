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
    public class PatientRL : IPatientRL
    {
        private SqlConnection sqlConnection;
        private IConfiguration configuration { get; }

        public PatientRL ( IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public PatientModel AddPatientDetails(int UserID, PatientModel patientModel)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_Patient_AddDetails", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@Profile", patientModel.Profile);
                cmd.Parameters.AddWithValue("@Name", patientModel.Name);
                cmd.Parameters.AddWithValue("@Date_of_birth", patientModel.Date_of_birth);
                cmd.Parameters.AddWithValue("@Gender", patientModel.Gender);
                cmd.Parameters.AddWithValue("@Blood_group", patientModel.Blood_group);
                cmd.Parameters.AddWithValue("@Medical_history", patientModel.Medical_history);
                cmd.Parameters.AddWithValue("@Phone_number", patientModel.Phone_number);
                cmd.Parameters.AddWithValue("@Address", patientModel.Address);
                cmd.Parameters.AddWithValue("@Trash", patientModel.Trash);
                this.sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if(result != 0 )
                {
                    return patientModel;
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

        public IEnumerable<PatientModel> GetAllPatients() 
        {
            try
            {
                List<PatientModel> patientModel = new List<PatientModel> ();
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_Patient_PatientList", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                this.sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null )
                {
                    while (reader.Read())
                    {
                        PatientModel model = new PatientModel();
                        model.UserID = Convert.ToInt32(reader["UserID"]);
                        model.Patient_id = Convert.ToInt32(reader["Patient_id"]);
                        model.Profile = Convert.ToString(reader["Profile"]);
                        model.Name = Convert.ToString(reader["Name"]);
                        model.Date_of_birth = Convert.ToDateTime(reader["Date_of_birth"]);
                        model.Gender = Convert.ToString(reader["Gender"]);
                        model.Blood_group = Convert.ToString(reader["Blood_group"]);
                        model.Medical_history = Convert.ToString(reader["Medical_history"]);
                        model.Phone_number = Convert.ToString(reader["Phone_number"]);
                        model.Address = Convert.ToString(reader["Address"]);
                        model.Trash = Convert.ToInt32(reader["Trash"]);
                        patientModel.Add(model);
                    }
                    this.sqlConnection.Close();
                    return( patientModel );
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
        public PatientModel GetPatientDetail(int? UserID)
        {
            try
            {
                PatientModel model = new PatientModel();
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_Patientdetails_byId", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserID", UserID);
                this.sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        model.UserID = Convert.ToInt32(reader["UserID"]);
                        model.Patient_id = Convert.ToInt32(reader["Patient_id"]);
                        model.Profile = Convert.ToString(reader["Profile"]);
                        model.Name = Convert.ToString(reader["Name"]);
                        model.Date_of_birth = Convert.ToDateTime(reader["Date_of_birth"]);
                        model.Gender = Convert.ToString(reader["Gender"]);
                        model.Blood_group = Convert.ToString(reader["Blood_group"]);
                        model.Medical_history = Convert.ToString(reader["Medical_history"]);
                        model.Phone_number = Convert.ToString(reader["Phone_number"]);
                        model.Address = Convert.ToString(reader["Address"]);
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
        public PatientModel EditPatientDetails(PatientModel patientModel)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_Patient_Edit", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", patientModel.UserID);
                cmd.Parameters.AddWithValue("@Profile", patientModel.Profile);
                cmd.Parameters.AddWithValue("@Name", patientModel.Name);
                cmd.Parameters.AddWithValue("@Date_of_birth", patientModel.Date_of_birth);
                cmd.Parameters.AddWithValue("@Gender", patientModel.Gender);
                cmd.Parameters.AddWithValue("@Blood_group", patientModel.Blood_group);
                cmd.Parameters.AddWithValue("@Medical_history", patientModel.Medical_history);
                cmd.Parameters.AddWithValue("@Phone_number", patientModel.Phone_number);
                cmd.Parameters.AddWithValue("@Address", patientModel.Address);
                this.sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if(result != 0 )
                {
                    return patientModel;
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

        public ApModel AppointmentCreate(int? Patient_id, int? Doctor_id, string D_Name, ApModel apModel)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_AP_create", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Patient_id", Patient_id);
                cmd.Parameters.AddWithValue("P_Name", apModel.P_Name);
                cmd.Parameters.AddWithValue("Ap_Date", apModel.Ap_Date);
                cmd.Parameters.AddWithValue("TimeSlotStart", apModel.TimeSlotStart);
                cmd.Parameters.AddWithValue("TimeSlotEnd", apModel.TimeSlotEnd);
                cmd.Parameters.AddWithValue("Purpose", apModel.Purpose);
                cmd.Parameters.AddWithValue("Doctor_id", Doctor_id);
                cmd.Parameters.AddWithValue("D_Name", D_Name);
                this.sqlConnection.Open();
                var result = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if(result != 0 )
                { 
                    return apModel;
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
        public IEnumerable<ApModel> GetAllAppointments() 
        {
            try
            {
                List<ApModel> apModel  = new List<ApModel> ();
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:Doctors_DB"]);
                SqlCommand cmd = new SqlCommand("SP_AP_Getall", this.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                this.sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader != null )
                {
                    while(reader.Read())
                    {
                        ApModel model = new ApModel();
                        model.Ap_id = Convert.ToInt32(reader["Ap_id"]);
                        model.Patient_id = Convert.ToInt32(reader["Patient_id"]);
                        model.P_Name = Convert.ToString(reader["P_Name"]);
                        model.Ap_Date = reader.GetDateTime(3);
                        model.TimeSlotStart = reader.GetTimeSpan(4);
                        model.TimeSlotEnd = reader.GetTimeSpan(5);
                        model.Purpose = Convert.ToString(reader["Purpose"]);
                        model.Doctor_id = Convert.ToInt32(reader["Doctor_id"]);
                        model.D_Name = Convert.ToString(reader["D_Name"]);
                        apModel.Add(model);

                    }
                    this.sqlConnection.Close();
                    return apModel;
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
