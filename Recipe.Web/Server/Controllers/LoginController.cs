using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe.Web.Data;
using Recipe.Web.Data.Models;
using Recipe.Web.Server.Services;

namespace Recipe.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> logger;
        private readonly RecipeContext context;
        private readonly AccountService accountService;
        private readonly LoginService loginService;

        public LoginController(ILogger<LoginController> logger, RecipeContext context, AccountService accountService, LoginService loginService)
        {
            this.logger = logger;
            this.context = context;
            this.accountService = accountService;
            this.loginService = loginService;
        }

        [HttpPost]
        public IActionResult UserLogin(AuthenticateModel model)
        {
            try
            {
                if (loginService.Authenticate(model.Email, model.Password))
                    return Ok();
                else
                    return Forbid();
                
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
