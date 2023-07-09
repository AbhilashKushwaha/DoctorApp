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

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private HealthCareDBContext _myDbContext;

        public LoginController(IConfiguration config, HealthCareDBContext context)
        {
            _config = config;
            _myDbContext = context;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            login.userName = "abhilash";
            login.password = "password";
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.userName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.emailId),
                new Claim("CreationDateTime", userInfo.creationDateTime.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User login)
        {
            //User userModel = new Healthapp.Model.User
            //{
            //    firstName = "Abhilash",
            //    middleName = "kumar",
            //    lastName = "kushwaha",

            //    userName = "abhilash",
            //    password = "password",
            //    emailId = "Abhilash@gmail.com",

            //    phoneNumber = "1234567890",
            //    address = "test",
            //    profilePicture = "pathhere",

            //    isDoctor = true,
            //    isActive = true,

            //};

            User user = null;
            //bool isEmail = Regex.IsMatch(login.emailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //bool isPhoneNumber = Regex.IsMatch(login.emailId, @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", RegexOptions.IgnoreCase);

            if (!string.IsNullOrEmpty(login.userName))
            {
                if (this._myDbContext.Users.Any(x => x.userName == login.userName && x.password == login.password))
                {
                    user = this._myDbContext.Users.Where(x => x.userName == login.userName && x.isActive == true).FirstOrDefault();
                }
            }
            return user;
        }
    }
}
