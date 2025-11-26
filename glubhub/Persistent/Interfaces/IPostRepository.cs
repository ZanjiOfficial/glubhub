using glubhub.Models;
namespace glubhub.Persistent.Interfaces
{
    public interface IPostRepository<T> where T : Post
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);

        void Update(T entity);
        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
