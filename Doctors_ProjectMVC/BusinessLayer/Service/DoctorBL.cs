using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class DoctorBL : IDoctorBL
    {
        IDoctorRL doctorRL;
        public DoctorBL(IDoctorRL doctorRL)
        {
            this.doctorRL = doctorRL;
        }

        public DoctorModel AddDoctorDetails(int? UserID, DoctorModel doctorModel)
        {
            try
            {
                return this.doctorRL.AddDoctorDetails(UserID, doctorModel);
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
                return this.doctorRL.GetAllDoctor();
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
                return this.doctorRL.GetDoctorDetail(UserID);
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
                return this.doctorRL.EditDoctorDetails(doctorModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
