using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class RepositoryForPosts : IRepository
    {
        private readonly AppDbContext _ctx;

        public RepositoryForPosts(AppDbContext ctx) => _ctx = ctx;

        public void Add(Post post) => _ctx.Add(post);

        public Task<Post> GetAsync(int id) => _ctx.Posts.SingleAsync(p => p.Id.Equals(id));

        public async Task<IReadOnlyList<Post>> GetAllAsync() => (await _ctx.Posts.ToListAsync()).AsReadOnly();

        public void Remove(Post post) => _ctx.Remove(post);

        public void Remove(int id)
        {
            var x = _ctx.Posts.Single(p => p.Id.Equals(id));
            _ctx.Posts.Remove(x);
        }

        public async Task<bool> SaveAsync() => (await _ctx.SaveChangesAsync()) > 0;

        public void Update(Post post) => _ctx.Posts.Update(post);
    }
}
