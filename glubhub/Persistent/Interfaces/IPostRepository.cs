using glubhub.Models;

public interface IPostRepository<T> where T : Post
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetByUserAsync(Guid userId);

    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int postId, Guid currentUserId);

    Task SaveChangesAsync();
}
