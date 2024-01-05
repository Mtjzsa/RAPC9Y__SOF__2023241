using Microsoft.AspNetCore.Identity;

namespace RAPC9Y_SOF_2023241.MVC.Models
{
    public class SiteUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
