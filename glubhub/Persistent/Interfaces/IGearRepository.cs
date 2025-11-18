using glubhub.Models;
namespace glubhub.Persistent.Interfaces
{
    public interface IGearRepository<T> where T : Gear
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddSync(T entity);

        void Update(T entity);
        void Delete(T entity);

        Task SaveChangesAsync();
    }
}
