using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Recipe.Web.Data.Models
{
    public class AuthenticateModel : ComponentBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string ValidationMessage { get; set; }

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
    }
}
