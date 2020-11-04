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
        public void UserLogin(AuthenticateModel model)
        {
            try
            {
                loginService.Authenticate(model.Email, model.Password);
            }
            catch (Exception e)
            {
                // Send this error message to the user. 
                // e.Message
            }
        }
    }
}
