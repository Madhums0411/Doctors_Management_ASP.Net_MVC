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
        public IActionResult AddDoctor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDoctor( DoctorModel doctorModel)
        {
            if (ModelState.IsValid)
            {
                int UserID = (int)HttpContext.Session.GetInt32("UserID");
                doctorBL.AddDoctorDetails(UserID, doctorModel);
                return RedirectToAction("Privacy", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            List<DoctorModel> doctorModel = new List<DoctorModel>();
            doctorModel = doctorBL.GetAllDoctor().ToList();

                     return View(doctorModel);
        }
        
        [HttpGet]
        public IActionResult Details(int? UserID)
        {
             //UserID = (int)HttpContext.Session.GetInt32("UserID");
            if (UserID == null)
            {
                return NotFound();
            }
            DoctorModel model = doctorBL.GetDoctorDetail(UserID);
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
        [ValidateAntiForgeryToken]
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
