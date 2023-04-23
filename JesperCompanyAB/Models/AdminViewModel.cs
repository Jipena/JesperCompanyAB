using Microsoft.AspNetCore.Identity;

namespace JesperCompanyAB.Models
{
    public class AdminViewModel
    {
        public IdentityUser[] Administrators { get; set; }
        public IdentityUser[] Everyone { get; set; }
    }
}
