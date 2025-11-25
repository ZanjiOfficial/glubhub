using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace glubhub.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        [Required, MaxLength(255)] 
        public string Username { get; set; }
        [Required, MaxLength(255)]
        public string Email { get; set; }
        [Required, MaxLength(255)]
        public string PasswordHash { get; set; }
        [Required]
        public string ProfilePicture { get; set; }
        [Required]
        public DateTime Creationdate { get; } 
        = DateTime.Now;
        public List<User> Followers { get; set; }   
        public List<User> Following { get; set; }
        
        public List<Group> Groups { get; set; } = new List<Group>();

        public User(string username, string email, string passwordHash, string profilePicture, int userId)
        {
            UserId = userId;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            ProfilePicture = profilePicture;
            Followers = new List<User>();
            Following = new List<User>();
            Groups = new List<Group>();
        }
    }
}
