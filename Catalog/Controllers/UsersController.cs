using Catalog.Repositories;
using Catalog.Dtos;
using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repository;
        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }
        
        // GET /users
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = (await _repository.GetAllUsersAsync())
                        .Select(user => user.AsDto());

            return users;
        }

        // GET /users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(Guid id)
        {
            var user = await _repository.GetUserAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user.AsDto();
        }

        // POST /users
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAsync(CreateUserDto userDto)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                Language = userDto.Language,
                Email = userDto.Email,
                UserRole = userDto.UserRole,
                ManagerRole = userDto.ManagerRole,
                AuthorizationAmount = userDto.AuthorizationAmount
            };

            await _repository.CreateUserAsync(user);

            return CreatedAtAction(nameof(GetUserAsync), new { id = user.Id }, user.AsDto());
        }

        // PUT /users/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(Guid id, UpdateUserDto userDto)
        {
            var existingUser = await _repository.GetUserAsync(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            User updatedUser = existingUser with
            {
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                Language = userDto.Language,
                Email = userDto.Email
            };

            await _repository.UpdateUserAsync(updatedUser);

            return NoContent();
        }

        // DELETE /users/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            var existingUser = await _repository.GetUserAsync(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            await _repository.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
