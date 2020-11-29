using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recipe.Web.Data.Models
{
    public class UserRecipePost
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public string CookingTime { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public int CalorieCount { get; set; }
        public int Servings { get; set; }
        public bool IsVegan { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsDairyFree { get; set; }
        public bool IsHealthy { get; set; }
    }
}
