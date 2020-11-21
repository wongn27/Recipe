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
        //[Key]
        //[Column(Order = 1)]
        public Guid Id { get; set; }
        //[Key]
        //[Column(Order = 2)]
        public Guid InTheFridgeRecipeId { get; set; }
        //[Key]
        //[Column(Order = 3)]
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
        public float Rating { get; set; }
        public string Review { get; set; }
        public InTheFridgeRecipe InTheFridgeRecipe { get; set; }
        public User User { get; set; }


    }
   

}
