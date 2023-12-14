using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        ILogger<UserController> _logger;

        public UserController(IMapper mapper, IUserService userService, ILogger<UserController> logger)
        {
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        // GET api/<UserController>/5//
        [HttpGet("{id}")]
        public async Task<ActionResult<userDTO>> Get(int id)
        {
            User user = await _userService.getUserById(id);
            if (user == null)
                return NoContent();
            userDTO userDTO = _mapper.Map<User, userDTO>(user);
            return Ok(userDTO);
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<userSaveDTO>> Post( [FromBody] userLoginDTO userLogin)
        {
            User userParse = _mapper.Map<userLoginDTO, User>(userLogin);
            User user = await _userService.getUserByUserNameAndPass(userParse.Email, userParse.Password);
            if (user != null)
            {
                userSaveDTO userSave = _mapper.Map<User, userSaveDTO>(user);
                _logger.LogInformation("user {0} connect", userParse.Email);
                return CreatedAtAction(nameof(Get), new { id = user.UserId}, userSave);
            }
            return NoContent();
        }
      
        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<userDTO>> Post([FromBody] userDTO user)
        {
            User userParse = _mapper.Map<userDTO, User>(user);
            User newUser = await _userService.addUser(userParse);
            if (newUser == null)
                return BadRequest();
            userDTO newUserDTO = _mapper.Map<User, userDTO>(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUserDTO);
        }

        // POST api/<UserController>
        [Route("checkPassword")]
        [HttpPost]
        public ActionResult<User> Post([FromBody] string pass)
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
                if (userUpdated == null)
                    return BadRequest();
                return Ok(userUpdated);
            }
            catch (Exception e){
                throw e;
            }
        }
    }
}
