using glubhub.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace glubhub.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(255)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string ProfilePicture { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

        public virtual ICollection<ApplicationUser> Followers { get; set; } = new List<ApplicationUser>();
        public virtual ICollection<ApplicationUser> Following { get; set; } = new List<ApplicationUser>();

        public ApplicationUser() { }

        public ApplicationUser(string username, string profilePicture)
        {
            Username = username;
            ProfilePicture = profilePicture;
        }
    }

}
