using afh_be.Data;
using afh_be.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace afh_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollectionController : ControllerBase
    {
        private readonly MovieDBContext _context;

        public CollectionController(MovieDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetCollection()
        {
            return await _context.Collections.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetCollection(int id)
        {
            var collection = await _context.Collections.FindAsync(id);

            if (collection == null)
            {
                return NotFound();
            }

            return collection;
        }

        // [HttpPost]
        // public async IEnumerable<User> AddUser(User user)
        // {
        //     await _context.Users.Add(User);
        //     await _context.SaveChangesAsync();
        //     return IAsyncEnumerator<User>;
        // }
    }
}