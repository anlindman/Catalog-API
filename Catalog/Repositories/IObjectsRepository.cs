using Object = Catalog.Entities.Object;

namespace Catalog.Repositories
{
    public interface IObjectsRepository
    {
        Task<Object> GetObjectAsync(Guid id);
        Task<IEnumerable<Object>> GetAllObjectsAsync();
        Task CreateObjectAsync(Object vobject);
        Task UpdateObjectAsync(Object vobject);
        Task DeleteObjectAsync(Guid id);
    }
}
