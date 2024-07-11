using afh_db;
using afh_db.Libraries;
using afh_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace afh_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollectionController : ControllerBase
    {
        private readonly IControllerLibrary _controllerLibrary;

        public CollectionController(IControllerLibrary controllerlibrary)
        {
            _controllerLibrary = controllerlibrary;
        }

        // Get:
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetCollectionsList()
        {
            return await _controllerLibrary.GetCollectionsList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetCollectionById(int id)
        {
            var collection = await _controllerLibrary.GetCollectionById(id);

            if (collection == null)
            {
                return NotFound();
            }

            return collection;
        }

        [HttpPost("Add")]
        public async Task AddCollection([FromBody] Collection collection)
        {
            if (collection != null)
            {
                await _controllerLibrary.AddCollection(collection);
            }
            return;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditCollection(
            [FromBody] Collection updatedCollection,
            int id
        )
        {
            var existingCollection = await _controllerLibrary.GetCollectionById(id);
            if (existingCollection == null)
            {
                return NotFound();
            }

            try
            {
                await _controllerLibrary.EditCollection(updatedCollection);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Collection>> DeleteCollection(int id)
        {
            var collection = await _controllerLibrary.GetCollectionById(id);
            if (collection == null)
            {
                return NotFound();
            }
            await _controllerLibrary.DeleteCollection(collection);
            return NoContent();
        }
    }
}
