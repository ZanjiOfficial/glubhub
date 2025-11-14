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
        public string profilePicture { get; set; }
        [Required]
        public DateTime Creationdate { get; } 
        = DateTime.Now;
        public int Followers { get; set; }
        public string Following { get; set; }
        public string Groups { get; set; }
    }
}
