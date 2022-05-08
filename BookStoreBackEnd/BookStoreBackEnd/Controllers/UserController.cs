using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost("Register")]
        public IActionResult UserRegister(UserRegistrationModel userRegistration)
        {
            try
            {
                var user = this.userBL.UserRegister(userRegistration);
                if (user != null)
                {
                    return this.Ok(new { Success = true, message = " Sucessfull User Registration", Response = user });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Unsuccessfull User Registration Failed" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPost("Login")]
        public IActionResult UserLogin(UserLoginModel userLogin)
        {
            try
            {
                var login = this.userBL.UserLogin(userLogin.Email, userLogin.Password);
                if (login != null)
                {
                    return this.Ok(new { Success = true, message = " Sucessfull Login -Token", Response = login });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Unsuccessfull Login" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
