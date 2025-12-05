using glubhub.Data;
using glubhub.Models;
using glubhub.Persistent.Interfaces;
using Microsoft.EntityFrameworkCore;

public class PostRepository<T> : IPostRepository<T> where T : Post
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task DeleteAsync(int postId, Guid currentUserId)
    {
        var post = await _dbSet.FirstOrDefaultAsync(
            p => p.PostId == postId && p.UserId == currentUserId);

        if (post is null)
            return; // not found or not owned by this user

        _dbSet.Remove(post);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet
            .Include(p => p.Location)
            .Include(p => p.Fish)
            .Include(p => p.Gear)
            .Include(p => p.Technique)
            .Include(p => p.Tips)
            .Include(p => p.Picture)
            .Include(p => p.Comments)
            .Include(p => p.Likes)
            .OrderByDescending(p => p.Timestamp)
            .ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetByUserAsync(Guid userId)
    {
        return await _dbSet
            .Where(p => p.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await Task.CompletedTask;
    }
}
