using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;
        private static Post _nullPost = new Post();

        public HomeController(IRepository repo) => _repo = repo;

        public async Task<IActionResult> Index()
        {
            var repos = await _repo.GetAllAsync();
            return View(repos);
        }

        public async Task<IActionResult> Post(int id)
        {
            var post = await _repo.GetAsync(id);
            return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id) => View(id.HasValue? await _repo.GetAsync(id.Value) : _nullPost);

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            ((post?.Id.Equals(0) ?? false) ? (Action<Post>)_repo.Add : _repo.Update).Invoke(post);
            await _repo.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
