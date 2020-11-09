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

        public bool DoesPasswordMatchHash(string email, string nonHashedPassword)
        {
            var user = context.Users.First(e => e.Email.Equals(email.ToLower()));

            var hashedPassword = StringHasher.Hash(nonHashedPassword);
            return user.Password.Equals(hashedPassword);
        }

        public bool Authenticate(string email, string password)
        {
            try
            {
                return DoesPasswordMatchHash(email, password);
            }
            catch (Exception e)
            {
                throw e;

            }
            return true;
        }
    }
}
