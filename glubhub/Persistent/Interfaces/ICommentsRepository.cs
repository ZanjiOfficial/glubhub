using glubhub.Models;
namespace glubhub.Persistent.Interfaces
{
    public interface ICommentsRepository<T> where T : Comments
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddSync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetByPostAsync(int postId);
        Task SaveChangesAsync();
    }
}
