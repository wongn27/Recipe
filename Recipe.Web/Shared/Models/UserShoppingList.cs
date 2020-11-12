using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class UserShoppingList
    {
        public Guid Id { get; set; }
        public Ingredient Ingredient { get; set; }
        public User User { get; set; }
    }
}
