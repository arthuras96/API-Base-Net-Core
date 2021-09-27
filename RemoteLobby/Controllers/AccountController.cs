using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Authenticate;
using Application.Authenticate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RemoteLobby.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody]User model)
        {
            try
            {
                var service = new UserService();
                var user = service.Authenticate(model.Username, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}