using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient.Server;
using Recipe.Web.Data;
using Recipe.Web.Data.Models;
using Recipe.Web.Data.Utilities;

namespace Recipe.Web.Server.Services
{
    public class LoginService
    {
        private readonly RecipeContext context;
        private readonly AccountService accountService;

        public LoginService(RecipeContext context, AccountService accountService)
        {
            this.context = context;
            this.accountService = accountService;
        }

        public bool IsEmailValid(string email)
        {
            return accountService.HasAccount(email);
        }

        public bool IsPasswordValid(string email, string nonHashedPassword)
        {
            if (!IsEmailValid(email))
            {
                throw new ArgumentException("The email does not exist in the system to authenticate against.");
            }

            var user = context.Users.First(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            var hashedPassword = StringHasher.Hash(nonHashedPassword);
            return user.Password.Equals(hashedPassword);         
        }

        public bool Authenticate(string email, string password)
        {
            if (!IsEmailValid(email))
            {
                throw new ArgumentException("The email does not exist in the system.");
            }

            if (!IsPasswordValid(email, password))
            {
                throw new ArgumentException("The password entered does not match in the account.");
            }

            return true;
        }
    }
}
