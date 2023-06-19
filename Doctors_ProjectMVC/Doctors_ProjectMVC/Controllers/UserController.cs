using BusinessLayer.Interface;
using BusinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Doctors_ProjectMVC.Controllers
{
    public class UserController : Controller
    {
        private IUserBL userBL;

        public UserController(IUserBL userBL )
        {
            this.userBL = userBL;
        }
        
        public IActionResult Admin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind] UserModel user)
        {
            if (ModelState.IsValid)
            {
               userBL.UserRegister(user);
               return RedirectToAction("Login","User");
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind] LoginModel loginModel)
        {
            string message = string.Empty;
            if (ModelState.IsValid)
            {
                var result = userBL.UserLogin(loginModel);
               
                if (result != null)
                {
                    HttpContext.Session.SetInt32("UserID", result.UserID);
                    HttpContext.Session.SetInt32("Role_Id", result.Role_Id);
                    HttpContext.Session.SetString("Name", result.Name);
                    
                    if (result.Role_Id == 1)
                    {

                        return RedirectToAction("Admin", "User");
                    }
                    else if(result.Role_Id == 2)
                    {
                        return RedirectToAction("Doctor", "Doctor");
                    }
                    else if(result.Role_Id == 3)
                    {
                        
                        return RedirectToAction("Patient", "Patient");
                    }
                }
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Getall()
        {
            List<GetUser> users = new List<GetUser>();
            users=userBL.GetAllUser().ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Details(int? UserID)
        {
            if (UserID == null)
            {
                return NotFound();
            }
            GetUser user =userBL.GetUserDetails(UserID);
            if(user == null)
            {
                return NotFound();
            }
            //ViewBag.user = user;
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int? UserID)
        {
            if (UserID == null)
            {
                return NotFound();
            }
            GetUser user = userBL.GetUserDetails(UserID);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? UserID ,[Bind] GetUser user)
        {
            if (UserID != user.UserID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                userBL.UpdateUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
        public IActionResult Delete(int? UserID)
        {
            if (UserID == null)
            {
                return NotFound();
            }
            GetUser user = userBL.GetUserDetails(UserID);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? UserID)
        {
                userBL.DeleteUser(UserID);
                return RedirectToAction("Index", "Home");
            
        }


    }
}
