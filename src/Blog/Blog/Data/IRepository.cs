using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Data
{
    public interface IRepository
    {
        void Add(Post post);
        void Update(Post post);
        void Remove(Post post);
        void Remove(int id);
        Task<Post> GetAsync(int id);
        Task<IReadOnlyList<Post>> GetAllAsync();
        Task<bool> SaveAsync();
    }
}
