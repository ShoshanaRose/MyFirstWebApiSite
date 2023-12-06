using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Text.Json;

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMapper _mapper;
        IUserService _userService;
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        // GET api/<UserController>/5//
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            User user = await _userService.getUserById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<User>> Post( [FromBody] userLoginDTO userLogin)
        {
            User userParse = _mapper.Map<userLoginDTO, User>(userLogin);
            User user = await _userService.getUserByUserNameAndPass(userParse.Email, userParse.Password);
            if (user != null)
            {
                userDTO userSave = _mapper.Map<User, userDTO>(user);
                return CreatedAtAction(nameof(Get), new { id = userSave.UserId}, userSave);
            }
            return NoContent();
        }
      
        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] userDTO user)
        {
            try
            {
                //int pass = Convert.ToInt32(user.Password);
                //user.Password = pass;
                User userParse = _mapper.Map<userDTO, User>(user);
                User newUser = await _userService.addUser(userParse);
                if (newUser == null)
                    return BadRequest();
                userDTO newUserSave = _mapper.Map<User, userDTO>(newUser);
                return CreatedAtAction(nameof(Get), new { id = newUserSave.UserId }, newUserSave);
            }
            catch(Exception e){
                throw e;
            }           
        }

        // POST api/<UserController>
        [Route("checkPassword")]
        [HttpPost]
        public ActionResult Post([FromBody] String pass)
        {
            int res = _userService.checkStrongePassword(pass);
            if (res >= 2)
                return Ok(res);
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] userDTO userToUpdate)
        {
            try
            {
                User userParse = _mapper.Map<userDTO, User>(userToUpdate);
                User userUpdated = await _userService.update(id, userParse);
                if (userToUpdate == null)
                    return BadRequest();
                return Ok(userUpdated);
            }
            catch (Exception e){
                throw e;
            }
        }
    }
}
