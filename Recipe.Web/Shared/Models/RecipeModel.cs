using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.Web.Data.Models
{
    //https://spoonacular.com/food-api/docs#Search-Recipes-by-Ingredients - Site Reference
    public class RecipeModel
    {
        [Parameter]
        public int id { get; set; }
        [Parameter]
        public string title { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public int usedIngredientCount { get; set; }
        public int missedIngredientCount { get; set; }
        public Missedingredient[] missedIngredients { get; set; }
        public Usedingredient[] usedIngredients { get; set; }
        public object[] unusedIngredients { get; set; }
        public int likes { get; set; }
    }

    public class Missedingredient
    {
        public int id { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public string unitLong { get; set; }
        public string unitShort { get; set; }
        public string aisle { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public string[] metaInformation { get; set; }
        public string[] meta { get; set; }
        public string extendedName { get; set; }
        public string image { get; set; }
    }

    public class Usedingredient
    {
        public int id { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public string unitLong { get; set; }
        public string unitShort { get; set; }
        public string aisle { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public string[] metaInformation { get; set; }
        public string[] meta { get; set; }
        public string image { get; set; }
    }

    public class RecipeSummarize
    {
        public int id { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
    }


    public class CookingInstructions
    {
        public string name { get; set; }
        public StepRT[] steps { get; set; }
    }

    public class StepRT
    {
        public int number { get; set; }
        public string step { get; set; }
        public Ingredient[] ingredients { get; set; }
        public Equipment[] equipment { get; set; }
        public Length length { get; set; }
    }

    public class LengthRT
    {
        public int number { get; set; }
        public string unit { get; set; }
    }

    public class IngredientInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
    }

    public class Equipment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
        public Temperature temperature { get; set; }
    }

    public class Temperature
    {
        public float number { get; set; }
        public string unit { get; set; }
    }




}

