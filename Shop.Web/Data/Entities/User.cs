using Microsoft.AspNetCore.Identity;
namespace Shop.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
