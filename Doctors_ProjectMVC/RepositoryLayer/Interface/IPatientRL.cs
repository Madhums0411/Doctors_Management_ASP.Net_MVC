using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IPatientRL
    {
        public PatientModel AddPatientDetails(int UserID, PatientModel patientModel);
        public IEnumerable<PatientModel> GetAllPatients();

        public PatientModel GetPatientDetail(int? UserID);

        public PatientModel EditPatientDetails(PatientModel patientModel);
        public ApModel AppointmentCreate(int? Patient_id, int? Doctor_id, string D_Name, ApModel apModel);
        public IEnumerable<ApModel> GetAllAppointments();

    }
}
