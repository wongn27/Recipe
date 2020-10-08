using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ApiClientRecipe.Models
{
    public class InformationApi
    {
        public string token { get; } = "apiKey=d36cb53813e341069b3c81d6d3b61c31";



        //Used for getting data from array/list Json *************************************

    //     using (var response = await client.SendAsync(request))
    //    {
    //        response.EnsureSuccessStatusCode();

    //        //String of Json from API call
    //        var jsonString = await response.Content.ReadAsStringAsync();


    //var root = Newtonsoft.Json.JsonConvert.DeserializeObject<List<IngredientInfo>>(jsonString);

    //IngredientInfo test = new IngredientInfo();

    //        foreach (var arry in root)
    //        {
    //            for (int i = 0; i<root.Count; ++i)
    //            {
    //                test.name = arry.name;
    //                test.image = arry.image;
    //            }

            }

}
