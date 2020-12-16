using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class UserFridgeIngredient
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double? Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Guid UserId { get; set; }
        public string Unit { get; set; }        
    }
}
