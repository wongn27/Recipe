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
        public int? Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public User User { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
