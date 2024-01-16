using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApplication1.EndPoint.ViewModels.Login;
using WebApplication1.EndPoint.ViewModels.Register;

namespace WebApplication1.EndPoint.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        /// <summary>
        /// ثبت نام کاربر 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/user/register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = _userManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    return Ok(new { Message = "عملیات ثبت نام با موفقیت انجام شد." });
                }

                return BadRequest(new { Message = "خطا در ثبت نام", Errors = result.Errors.Select(e => e.Description) });
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// ورود کاربر و دریافت توکن
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login")] 
        public IActionResult Login(LoginViewModel model)
        {
            var user = _userManager.FindByEmailAsync(model.Email).Result;

            if (user == null || !_userManager.CheckPasswordAsync(user, model.Password).Result)
            {
                return Unauthorized(new { Message = "اطلاعات ورود نامعتبر است" });
            }

            var token = GenerateToken(user.Id, user.Email);

            return Ok(new { Token = token });
        }


        /// <summary>
        /// ساخت توکن
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GenerateToken(string userId, string email)
        {
            string _secretKey = _configuration["JwtConfig:SecretKey"];
            string _issuer = _configuration["JwtConfig:Issuer"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
