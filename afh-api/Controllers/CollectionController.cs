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
        public async Task<IActionResult> AddCollection([FromBody] AddCollectionDto newCollectionDto)
        {
            if (newCollectionDto != null)
            {
                var collectionDto = _mapper.Map<Collection>(newCollectionDto);
                await _collectionLibrary.AddCollection(collectionDto);
                return NoContent();
            }
            return BadRequest("Collection data is null");
        }

  [HttpPatch("{id}")]
public async Task<IActionResult> EditCollection(
    [FromBody] EditCollectionDto updatedCollection,
    int id
)
{
    var existingCollection = await _collectionLibrary.GetCollectionById(id);
    if (existingCollection == null)
    {
        return NotFound();
    }

    if (existingCollection.CollectionID != id)
    {
        return BadRequest("Collection ID mismatch");
    }

    try
    {
        await _collectionLibrary.EditCollection(existingCollection, updatedCollection);
        return NoContent();
    }
    catch (DbUpdateConcurrencyException)
    {
        return Conflict("The collection was modified by another process.");
    }
    catch (Exception ex)
    {
        // Log the exception
        return StatusCode(500, $"An error occurred while updating the collection: {ex}");
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
