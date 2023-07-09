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
    public class DepartmentController : Controller
    {
        private IConfiguration _config;
        private HealthCareDBContext _myDbContext;

        public DepartmentController(IConfiguration config, HealthCareDBContext context)
        {
            _config = config;
            _myDbContext = context;
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            this._myDbContext.Department.Add(department);
            this._myDbContext.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(Department department)
        {
            var data = this._myDbContext.Department.Where(x => x.Id == department.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            Department DepartmentModel = new Department
            {
                code = department.code,
                deptartmentName = department.deptartmentName,
                isActive = department.isActive,

            };
            this._myDbContext.Department.Update(DepartmentModel);
            this._myDbContext.SaveChanges();
            var data = this._myDbContext.Department.Where(x => x.Id == department.Id).FirstOrDefault();
            return Json(data, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
    }
}
