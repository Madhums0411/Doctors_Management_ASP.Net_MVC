using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IPatientBL
    {
        public PatientModel AddPatientDetails(int UserID, PatientModel patientModel);
        public IEnumerable<PatientModel> GetAllPatients();
        public PatientModel GetPatientDetail(int? UserID);
        public PatientModel EditPatientDetails(PatientModel patientModel);
        public ApModel AppointmentCreate(int? Patient_id, int? Doctor_id, string D_Name, ApModel apModel);
        public IEnumerable<ApModel> GetAllAppointments();
        public ApModel GetAppointmentById(int? Patient_id);
        public ApModel EditAppointment(ApModel apModel);
    }
}
