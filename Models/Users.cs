using Microsoft.AspNetCore.Identity;

namespace NewsWebApp.Models
{
    public class Users:IdentityUser
    {
        public string FullName { get; set; }
    }
}
