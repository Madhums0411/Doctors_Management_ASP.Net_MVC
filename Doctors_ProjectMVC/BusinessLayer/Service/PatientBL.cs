using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class PatientBL :IPatientBL
    {
        IPatientRL patientRL;
        public PatientBL(IPatientRL patientRL)
        {
            this.patientRL = patientRL;
        }

        public PatientModel AddPatientDetails(int UserID, PatientModel patientModel)
        {
            try
            {
                return this.patientRL.AddPatientDetails(UserID, patientModel);
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
                return this.patientRL.GetAllPatients();
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
                return this.patientRL.GetPatientDetail(UserID);
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
                return this.patientRL.EditPatientDetails(patientModel);
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
                return this.patientRL.AppointmentCreate(Patient_id, Doctor_id, D_Name, apModel);
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
                return this.patientRL.GetAllAppointments();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
