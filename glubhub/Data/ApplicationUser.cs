using glubhub.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace glubhub.Models
{
    public class ApplicationUser : IdentityUser
    {
        // UserName fjernet for at bruge inherited UserName property fra IdentityUser

        [Required]
        public string ProfilePicture { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public ICollection<Group> Groups { get; set; } = new List<Group>();

        public ICollection<ApplicationUser> Followers { get; set; } = new List<ApplicationUser>();
        public ICollection<ApplicationUser> Following { get; set; } = new List<ApplicationUser>();

        public ApplicationUser() { }

        public ApplicationUser(string userName, string profilePicture)
        {
            //bruger predefined UserName property fra IdentityUser
            UserName = userName;
            ProfilePicture = profilePicture;
        }
    }

}
