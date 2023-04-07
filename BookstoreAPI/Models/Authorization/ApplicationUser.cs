using Microsoft.AspNetCore.Identity;

namespace BookstoreAPI.Models.Authorization
{
    public class ApplicationUser:IdentityUser
    {

        public string FirstName { get; set; }   

        public string LastName { get; set; }


    }
}
