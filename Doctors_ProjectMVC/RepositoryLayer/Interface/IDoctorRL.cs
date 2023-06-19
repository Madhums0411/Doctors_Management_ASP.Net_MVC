using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IDoctorRL
    {
        public DoctorModel AddDoctorDetails(int? UserID, DoctorModel doctorModel);
        public IEnumerable<DoctorModel> GetAllDoctor();
        public DoctorModel GetDoctorDetail(int? UserID);
        public DoctorModel EditDoctorDetails(DoctorModel doctorModel);
    }
}
