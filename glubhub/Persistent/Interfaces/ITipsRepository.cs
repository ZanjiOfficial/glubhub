using glubhub.Models;
namespace glubhub.Persistent.Interfaces
{
    public interface ITipsRepository<T> where T : Tips
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddSync(T entity);

        void Update(T entity);
        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
