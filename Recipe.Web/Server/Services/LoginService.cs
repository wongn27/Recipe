using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            Regex regex = new Regex(@"^\S +@\S +\.\S +$");
           
            if (!regex.IsMatch(email)) {
                throw new ArgumentException("The email provided is not valid.");
            }
            return true;
        }

        public bool IsPasswordValid(string email, string nonHashedPassword)
        {
            Regex regex = new Regex(@"(?=^.{8,}$)(?=.*\w)(?=.*[0-9])");

            if (!regex.IsMatch(nonHashedPassword))
            {
                throw new ArgumentException("The password provided is not valid. Must be a minimum length of 8 and at least one number");
            }

            if (!accountService.HasAccount(email))
            {
                throw new ArgumentException("The email does not exist in the system to authenticate against.");
            }

            var user = context.Users.First(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            var hashedPassword = StringHasher.Hash(nonHashedPassword);
            return user.Password.Equals(hashedPassword);         
        }

        public void Authenticate(string email, string password)
        {
            if (!IsEmailValid(email))
            {
                throw new ArgumentException("The email does not exist in the system.");
            }

            if (!IsPasswordValid(email, password))
            {
                throw new ArgumentException("The password entered does not match in the account.");
            }
        }
    }
}
