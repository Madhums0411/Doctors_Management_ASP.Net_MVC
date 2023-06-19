using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IDoctorBL
    {
        public DoctorModel AddDoctorDetails(int? UserID, DoctorModel doctorModel);
        public IEnumerable<DoctorModel> GetAllDoctor();
        public DoctorModel GetDoctorDetail(int? UserID);
        public DoctorModel EditDoctorDetails(DoctorModel doctorModel);
    }
}
