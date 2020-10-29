using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController: Controller
    {
        private readonly AppDbContext _ctx;

        public HomeController(AppDbContext ctx) => _ctx = ctx;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            _ctx.Add(post);
            await _ctx.SaveChangesAsync();
            return Redirect(nameof(Index));
        }
        
    }
}
