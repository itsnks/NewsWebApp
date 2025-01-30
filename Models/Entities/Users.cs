using Microsoft.AspNetCore.Identity;

namespace NewsWebApp.Models.Entities
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
