using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Doctors_ProjectMVC.Controllers.Ajax
{
    public class AjaxController : Controller
    {
        private IUserBL userBL;

        public AjaxController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult UserList()
        {

            var data = userBL.GetAllUser().ToList();
            return new JsonResult(data);
        }


    }
}
