using glubhub.Data;
using glubhub.Models;
using Microsoft.EntityFrameworkCore;

namespace glubhub.Controls
{
    public class UserService
    {
        private readonly UserDbContext _context;

        public UserService(UserDbContext context)
        {
            _context = context;
        }

        public DbSet<User> Users => _context.Users;
    }
}
