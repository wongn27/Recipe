using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipe.Web.Data;
using Recipe.Web.Data.Models;
using Recipe.Web.Data.Utilities;
using Recipe.Web.Server.Services;

namespace Recipe.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        private readonly RecipeContext context;
        private readonly AccountService accountService;

        public AccountController(ILogger<AccountController> logger, RecipeContext context, AccountService accountService)
        {
            this.logger = logger;
            this.context = context;
            this.accountService = accountService;
        }

        [HttpPost]
        public void CreateUserAccount(User user)
        {
            accountService.CreateAccount(user);
        }
    }
}
