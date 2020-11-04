using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

        public bool IsValidPassword(string nonHashedPassword)
        {
            // TODO Fix regex for next sprint
            // var regex = new Regex(@"(?=^.{8,}$)(?=.*\w)(?=.*[0-9])");
            //return !regex.IsMatch(nonHashedPassword);
            return true;
        }

        public void CreateAccount(User user)
        {
            if (HasAccount(user.Email))
            {
                throw new ArgumentException($"The user account with email address {user.Email} exists.");
            }

            if (!IsValidPassword(user.Password))
            {
                throw new Exception("The password provided is not valid. Must be a minimum length of 8 and at least one number!");
            }

            user.Email = user.Email.ToLower();
            user.Password = StringHasher.Hash(user.Password);
            
            context.Users.Attach(user);
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
