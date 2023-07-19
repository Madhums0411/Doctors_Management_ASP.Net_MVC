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
        [Route("Patient/Profile")]
        public IActionResult AddPatient()
        {

            return View();

        } 

        [HttpPost]
        
        public IActionResult AddPatient(PatientModel patientModel)
        {

            string Name = HttpContext.Session.GetString("Name");

           
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
        [Route("Patient/AllPatients")]
        public IActionResult GetPatients()
        {
            List<PatientModel> patientModel = new List<PatientModel>();
            patientModel = patientBL.GetAllPatients().ToList();
            return View(patientModel);
        }

        [HttpGet]
        [Route("Patient/Details")]
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
        [Route("Patient/Update")]
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
        [Route("Patient/Appointment")]
        public IActionResult AddAppointment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAppointment(ApModel apModel)
        {
            if (ModelState.IsValid)
            {
                int Patient_id = (int)HttpContext.Session.GetInt32("Patient_id");
                int Doctor_id = (int)HttpContext.Session.GetInt32("Doctor_id");
                string D_Name = (string)HttpContext.Session.GetString("D_Name");
                var result = patientBL.AppointmentCreate(Patient_id, Doctor_id, D_Name, apModel);
                
                if(result != null)
                {
                    
                    return RedirectToAction("Patient", "Patient");
                }
                

            }
            return View();
        }
        [HttpGet]
        [Route("Patient/AllAppointments")]
        public IActionResult GetAllAppointments()
        {
            List<ApModel> apModel = new List<ApModel>();
            apModel = patientBL.GetAllAppointments().ToList();
            return View(apModel);
        }

        [HttpGet]
        [Route("Patient/AppointmentDetails")]
        public IActionResult APDetailsByID(int? Patient_id)
        {
             Patient_id = (int)HttpContext.Session.GetInt32("Patient_id");

            if (Patient_id == null)
            {
                return RedirectToAction("Patient", "Patient");
            }
            var result = patientBL.GetAppointmentById(Patient_id);
            if (result != null)
            {
                
                return View(result);
            }
            return View();
        }
        [HttpGet]
        [Route("Patient/EditAppointment")]
        public IActionResult APEdit(int? Patient_id)
        {
            if (Patient_id == null)
            {
                return NotFound();
            }
            ApModel apModel = patientBL.GetAppointmentById(Patient_id);
            if (apModel == null)
            {
                return NotFound();
            }
            return View(apModel);
        }
        [HttpPost]
        public IActionResult APEdit(int? Patient_id, [Bind] ApModel apModel)
        {
            if (Patient_id != apModel.Patient_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                patientBL.EditAppointment(apModel);
                return RedirectToAction("APDetailsByID", "Patient");
            }
            return View(apModel);
        }
    }
}
