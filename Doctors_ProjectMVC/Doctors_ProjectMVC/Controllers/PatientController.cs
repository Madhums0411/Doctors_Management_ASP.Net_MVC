using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Doctors_ProjectMVC.Controllers
{
    public class PatientController : Controller
    {

        private IPatientBL patientBL;

        public PatientController(IPatientBL patientBL)
        {
            this.patientBL = patientBL;
        }
        public IActionResult Patient()
        {

            return View();
        }
        [HttpGet]
        public IActionResult AddPatient()
        {

            return View();

        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPatient(PatientModel patientModel)
        {
   
            if (ModelState.IsValid)
                {
                    int UserID = (int)HttpContext.Session.GetInt32("UserID");
                    var result = patientBL.AddPatientDetails(UserID, patientModel);

                    if (result != null)
                    {

                        return RedirectToAction("Details", "Patient");
                    }


                }
    

            return View();
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            List<PatientModel> patientModel = new List<PatientModel>();
            patientModel = patientBL.GetAllPatients().ToList();
            return View(patientModel);
        }

        [HttpGet]
        public IActionResult Details(int? UserID)
        {
            UserID = (int)HttpContext.Session.GetInt32("UserID");

            if (UserID == null)
            {
                return RedirectToAction("AddPatient", "Patient");
            }
            var result = patientBL.GetPatientDetail(UserID);
            if (result != null)
            {
                HttpContext.Session.SetInt32("Patient_id", result.Patient_id);
                return View(result);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? UserID)
        {
            if (UserID == null)
            {
                return NotFound();
            }
            PatientModel patientModel = patientBL.GetPatientDetail(UserID);
            if (patientModel == null)
            {
                return NotFound();
            }
            return View(patientModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? UserID, [Bind] PatientModel patientModel)
        {
            if (UserID != patientModel.UserID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                patientBL.EditPatientDetails(patientModel);
                return RedirectToAction("Patient", "Patient");
            }
            return View(patientModel);
        }
        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAppointment(ApModel apModel)
        {
            if (ModelState.IsValid)
            {
                int Patient_id = (int)HttpContext.Session.GetInt32("Patient_id");
                int Doctor_id = (int)HttpContext.Session.GetInt32("Doctor_id");
                string D_Name = (string)HttpContext.Session.GetString("D_Name");
                patientBL.AppointmentCreate(Patient_id, Doctor_id, D_Name, apModel);
                return RedirectToAction("Patient", "Patient");

            }
            return View();
        }
        //[HttpGet]
        //public IActionResult GetAllAppointments()
        //{
        //    List<ApModel> apModel = new List<ApModel>();
        //    apModel = patientBL.GetAllAppointments().ToList();
        //    return View(apModel);
        //}
    }
}
