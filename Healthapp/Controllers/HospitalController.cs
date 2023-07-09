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
    [Authorize]
    public class HospitalController : Controller
    {
        private IConfiguration _config;
        private HealthCareDBContext _myDbContext;

        public HospitalController(IConfiguration config, HealthCareDBContext context)
        {
            _config = config;
            _myDbContext = context;
        }

        [HttpPost]
        public IActionResult Add(Hospital hospital)
        {
            this._myDbContext.Hospital.Add(hospital);
            this._myDbContext.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Hospital hospital)
        {
            var data = this._myDbContext.Hospital.Where(x => x.Id == hospital.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public IActionResult Update(Hospital hospital)
        {
            Hospital HospitalModel = new Hospital
            {
                name = hospital.name,
                type = hospital.type,
                emailId = hospital.emailId,
                phoneNumber = hospital.phoneNumber,
                address = hospital.address,
                logoPath = hospital.logoPath,
                zipcode = hospital.zipcode,
                isActive = hospital.isActive,

            };
            this._myDbContext.Hospital.Update(HospitalModel);
            this._myDbContext.SaveChanges();
            var data = this._myDbContext.Hospital.Where(x => x.Id == hospital.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
