using FlappyAPI.Models;
using FlappyAPI.Modelss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlappyAPI.Controllers
{


    

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UserManager<User> UserManager;

        public UsersController(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        [HttpPost]
        public ActionResult Register(RegisterDTO register)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Login()
        {
            return Ok();
        }

    }

}
