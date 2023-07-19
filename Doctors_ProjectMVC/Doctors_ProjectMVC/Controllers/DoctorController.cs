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
    public class DoctorController : Controller
    {

        private IDoctorBL doctorBL;
        public DoctorController(IDoctorBL doctorBL)
        {
            this.doctorBL = doctorBL;
        }
        public IActionResult Doctor()
        {
            
            return View();
        }

        [HttpGet]
        [Route("Doctor/Profile")]
        public IActionResult AddDoctor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDoctor( DoctorModel doctorModel)
        {
            if (ModelState.IsValid)
            {
                int UserID = (int)HttpContext.Session.GetInt32("UserID");
                doctorBL.AddDoctorDetails(UserID, doctorModel);
                int Doctor_id = (int)HttpContext.Session.GetInt32("Doctor_id");
                return RedirectToAction("Details", "Doctor");

            }
            return View();
        }

        [HttpGet]
        [Route("Doctor/AllDoctors")]
        public IActionResult GetDoctors()
        {
            List<DoctorModel> doctorModel = new List<DoctorModel>();
            doctorModel = doctorBL.GetAllDoctor().ToList();

                     return View(doctorModel);
        }
        
        [HttpGet]
        [Route("Doctor/Details")]
        public IActionResult Details(int? UserID, DoctorModel model)
        {
             UserID = (int)HttpContext.Session.GetInt32("UserID");
            if (UserID == null)
            {
                return NotFound();
            }
          model = doctorBL.GetDoctorDetail(UserID);
            if (model != null)
            {

                HttpContext.Session.SetInt32("Doctor_id", model.Doctor_id);
                HttpContext.Session.SetString("D_Name", model.Name);
                return View(model);
            }
            //ViewData["Doctor"] = model;
            //ViewBag.Doctor = model;
            return View();
        }
        [HttpGet]
        [Route("Doctor/Update")]
        public IActionResult Edit(int? UserID)
        {
            if (UserID == null)
            {
                return NotFound();
            }
            DoctorModel doctorModel = doctorBL.GetDoctorDetail(UserID);
            if (doctorModel == null)
            {
                return NotFound();
            }
            return View(doctorModel);
        }
        [HttpPost]
        public IActionResult Edit(int? UserID, [Bind] DoctorModel doctorModel)
        {
            if (UserID != doctorModel.UserID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                doctorBL.EditDoctorDetails(doctorModel);
                return RedirectToAction("Doctor", "Doctor");
            }
            return View(doctorModel);
        }
    }
}
