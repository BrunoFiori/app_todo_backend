using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App_Todo_Backend.Data;
using App_Todo_Backend.Models.User;
using AutoMapper;
using App_Todo_Backend.Contract.Users;

namespace App_Todo_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {            
            _mapper = mapper;
            _userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutputUser>>> GetUsers()
        {
            return _mapper.Map<List<OutputUser>>(await _userRepository.ListAllAsync());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutputUser>> GetUser(int id)
        {
            var user = await _userRepository.GetTodos(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OutputUser>(user));
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UpdateUser updateUser)
        {   
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(updateUser, user);

            try
            {
                await _userRepository.UpdateAsync(user);
                await _userRepository.Commit();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex);
            }
                        
            return Ok(); 
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUser inputUser)
        {
            User user = _mapper.Map<User>(inputUser);

            await _userRepository.AddAsync(user);
            await _userRepository.Commit();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(user);
            await _userRepository.Commit();

            return NoContent();
        }

        private async Task<bool> UserExists(int id)
        {
            return await _userRepository.Exists(id);
        }
    }
}
