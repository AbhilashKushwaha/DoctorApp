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
    public class HospitalTypeController : Controller
    {
        private IConfiguration _config;
        private HealthCareDBContext _myDbContext;

        public HospitalTypeController(IConfiguration config, HealthCareDBContext context)
        {
            _config = config;
            _myDbContext = context;
        }

        [HttpPost]
        public IActionResult Add(HospitalType hospitalType)
        {
            this._myDbContext.HospitalType.Add(hospitalType);
            this._myDbContext.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(HospitalType hospitalType)
        {
            var data = this._myDbContext.HospitalType.Where(x => x.Id == hospitalType.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public IActionResult Update(HospitalType hospitalType)
        {
            HospitalType HospitalTypeModel = new HospitalType
            {
                name = hospitalType.name,
                code = hospitalType.code,
                isActive = hospitalType.isActive,

            };
            this._myDbContext.HospitalType.Update(HospitalTypeModel);
            this._myDbContext.SaveChanges();
            var data = this._myDbContext.HospitalType.Where(x => x.Id == hospitalType.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
