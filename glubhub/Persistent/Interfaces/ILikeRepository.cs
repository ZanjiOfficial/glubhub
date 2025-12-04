using glubhub.Models;
public interface ILikeRepository<T> where T : Like
{
    Task<T?> GetByUserAndPostAsync(Guid userId, int postId);
    Task<IEnumerable<T>> GetByPostsForUserAsync(Guid userId, IEnumerable<int> postIds);
    Task<IEnumerable<T>> GetByPostsAsync(IEnumerable<int> postIds);
    Task AddSync(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
