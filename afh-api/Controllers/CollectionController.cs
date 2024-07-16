using afh_db;
using afh_db.Libraries;
using afh_db.Models;
using afh_shared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace afh_be.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionLibrary _collectionLibrary;
        private readonly IMapper _mapper;

        public CollectionController(ICollectionLibrary collectionlibrary, IMapper mapper)
        {
            _collectionLibrary = collectionlibrary;
            _mapper = mapper;
        }

        // Get:
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetCollectionsList()
        {
             var collections = await _collectionLibrary.GetCollectionsList();
             var collectionsDto = _mapper.Map<IEnumerable<CollectionDto>>(collections);
            return Ok(collectionsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetCollectionById(int id)
        {
            var collection = await _collectionLibrary.GetCollectionById(id);

    if (collection == null)
    {
        return NotFound();
    }

    var collectionDto = _mapper.Map<CollectionDto>(collection);
    return Ok(collectionDto);
        }

        [HttpPost("Add")]
        public async Task AddCollection([FromBody] Collection collection)
        {
            if (collection != null)
            {
                await _collectionLibrary.AddCollection(collection);
            }
            return;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> EditCollection(
            [FromBody] Collection updatedCollection,
            int id
        )
        {
            var existingCollection = await _collectionLibrary.GetCollectionById(id);
            if (existingCollection == null)
            {
                return NotFound();
            }

            try
            {
                await _collectionLibrary.EditCollection(updatedCollection);
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
            var collection = await _collectionLibrary.GetCollectionById(id);
            if (collection == null)
            {
                return NotFound();
            }
            await _collectionLibrary.DeleteCollection(collection);
            return NoContent();
        }
    }
}
