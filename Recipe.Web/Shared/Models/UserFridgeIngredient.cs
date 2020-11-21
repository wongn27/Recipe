using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class UserFridgeIngredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime ExpirationDate { get; set; }
        public User User { get; set; }
    }
}
