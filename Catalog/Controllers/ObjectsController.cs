using Catalog.Dtos;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Object = Catalog.Entities.Object;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("objects")]
    public class ObjectsController : ControllerBase
    {
        private readonly IObjectsRepository _repository;
        public ObjectsController(IObjectsRepository repository)
        {
            _repository = repository;
        }
        // GET /objects
        [HttpGet]
        public async Task<IEnumerable<ObjectDto>> GetAllObjectsAsync()
        {
            var objects = (await _repository.GetAllObjectsAsync())
                            .Select(vobject => vobject.AsDto());

            return objects;
        }

        // GET /objects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectDto>> GetObjectAsync(Guid Id)
        {
            var vobject = await _repository.GetObjectAsync(Id);

            if (vobject is null)
            {
                return NotFound();
            }

            return vobject.AsDto();
        }

        // POST /objects
        [HttpPost]
        public async Task<ActionResult<ObjectDto>> CreateObjectAsync(CreateObjectDto objectDto)
        {
            Object vobject = new()
            {
                Id = Guid.NewGuid(),
                ObjectTypeNo = objectDto.ObjectTypeNo,
                ObjectId = objectDto.ObjectId,
                Name = objectDto.Name
            };

            await _repository.CreateObjectAsync(vobject);

            return CreatedAtAction(nameof(GetObjectAsync), new { id = vobject.Id }, vobject.AsDto());
        }

        // PUT /objects/{id}
        [HttpPut]
        public async Task<ActionResult> UpdateObjectAsync(Guid id, UpdateObjectDto objectDto)
        {
            var existingObject = await _repository.GetObjectAsync(id);

            if (existingObject is null)
            {
                return NotFound();
            }

            Object updatedObject = existingObject with
            {
                ObjectTypeNo = objectDto.ObjectTypeNo,
                ObjectId = objectDto.ObjectId,
                Name = objectDto.Name
            };

            await _repository.UpdateObjectAsync(updatedObject);

            return NoContent();
        }

        // DELETE /objects/{id}
        [HttpDelete]
        public async Task<ActionResult> DeleteObjectAsync(Guid id)
        {
            var existingObject = await _repository.GetObjectAsync(id);

            if (existingObject is null)
            {
                return NotFound();
            }

            await _repository.DeleteObjectAsync(id);

            return NoContent();
        }
    }
}