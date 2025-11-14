using System.ComponentModel.DataAnnotations;

namespace glubhub.Models
{
    public class User
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

        public User(string Username, string Email, string PasswordHash, string ProfilePicture, DateTime Creationdate, int Followers, string Following, string Groups)
        {

        }
    }
}
