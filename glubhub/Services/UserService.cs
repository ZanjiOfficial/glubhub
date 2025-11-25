using glubhub.Data;
using glubhub.Models;
using Microsoft.EntityFrameworkCore;

namespace glubhub.Controls
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<ApplicationUser> Users => _context.Users;
    }
}
