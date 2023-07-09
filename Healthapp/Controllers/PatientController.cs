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
    public class PatientController : Controller
    {
        private IConfiguration _config;
        private HealthCareDBContext _myDbContext;

        public PatientController(IConfiguration config, HealthCareDBContext context)
        {
            _config = config;
            _myDbContext = context;
        }

        [HttpPost]
        public IActionResult Add(Patient patient)
        {
            this._myDbContext.Patient.Add(patient);
            this._myDbContext.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Patient patient)
        {
            var data = this._myDbContext.Patient.Where(x => x.Id == patient.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public IActionResult Update(Patient patient)
        {
            Patient patientModel = new Patient
            {
                firstName = patient.firstName,
                middleName = patient.middleName,
                lastName = patient.lastName,

                phoneNumber = patient.phoneNumber,
                address = patient.address,
                profilePicture = patient.profilePicture,

                isActive = patient.isActive,

            };
            this._myDbContext.Patient.Update(patientModel);
            this._myDbContext.SaveChanges();
            var data = this._myDbContext.Patient.Where(x => x.Id == patient.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
