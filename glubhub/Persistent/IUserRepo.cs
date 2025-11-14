using glubhub.Models;
namespace glubhub.Persistent
{
    public interface IUserRepo<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddSync(T entity);
        
        void Update (T entity);
        void Delete (T entity);

        Task SaveChangesAsync();

    }
}
