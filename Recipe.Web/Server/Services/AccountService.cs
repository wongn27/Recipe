using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Recipe.Web.Data;
using Recipe.Web.Data.Models;
using Recipe.Web.Data.Utilities;

namespace Recipe.Web.Server.Services
{
    public class AccountService
    {
        private readonly RecipeContext context;

        public AccountService(RecipeContext context)
        {
            this.context = context;
        }

        public bool HasAccount(string email)
        {
            var user = context.Users.FirstOrDefault(u => u.Email.Equals(email));
            return user != null;
        }

        public bool IsAccountLocked(string email)
        {
            var isLocked = context.Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).IsLocked;
            return isLocked;
        }

        public void CreateAccount(User user)
        {
            if (HasAccount(user.Email))
            {
                throw new ArgumentException($"The user account with email address {user.Email} exists.");
            }

            user.Password = StringHasher.Hash(user.Password);
            
            context.Users.Attach(user);
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
