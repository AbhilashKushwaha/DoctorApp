using Healthapp.DBContext;
using Healthapp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace Healthapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IConfiguration _config;
        private HealthCareDBContext _myDbContext;

        public UserController(IConfiguration config, HealthCareDBContext context)
        {
            _config = config;
            _myDbContext = context;
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            this._myDbContext.Users.Add(user);
            this._myDbContext.SaveChanges();   
            return View();
        }

        [HttpGet]
        public IActionResult Edit(User user)
        {
            var data = this._myDbContext.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            User userModel = new User
            {
                firstName = user.firstName,
                middleName = user.middleName,
                lastName = user.lastName,

                phoneNumber = user.phoneNumber,
                address = user.address,
                profilePicture = user.profilePicture,

                isDoctor = user.isDoctor,
                isActive = user.isActive,

            };

            var data = this._myDbContext.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
