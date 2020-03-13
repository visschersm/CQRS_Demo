using Api.Controllers.UserCQ.CommandResults;
using Api.Controllers.UserCQ.Commands;
using Api.Controllers.UserCQ.Queries;
using Api.Model.Entities;
using Api.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IHandler _handler;
        public UserController(IHandler handler)
        {
            _handler = handler;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var result = await _handler.HandleQueryAsync<GetUserListQuery, UserListView>(new GetUserListQuery { });

            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (result.GetType() == typeof(UserListView))
                return Ok(result);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var result = await _handler.HandleCommandAsync(new CreateUserCommand());

            if (result.GetType() == typeof(UserAlreadyExistsResult))
                return BadRequest("User already exists");

            if (result.GetType() == typeof(UserSuccessfullyCreatedResult))
            {
                var id = ((UserSuccessfullyCreatedResult)result).Id;

                return CreatedAtAction("GetUser", new { id }, user);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
