﻿using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult> Get( [FromQuery] string userName, [FromQuery] int Password)
        {
            User user = await _userService.getUserByUserNameAndPass(userName, Password);
            if (user == null)
                return NoContent();
            return Ok(user);

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            User user = await _userService.getUserById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                User newUser = _userService.addUser(user);
                if (newUser == null)
                    return BadRequest();
                return Ok(newUser);
                //return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
            }
            catch(Exception e){
                throw e;
            }           
        }

        // POST api/<UserController>
        [HttpPost("checkPassword")]
        public ActionResult Post([FromBody] String pass)
        {
            int res = _userService.checkStrongePassword(pass);
            if (res >= 2)
                return Ok(res);
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            try
            {
                User userUpdated = await _userService.update(id, userToUpdate);
                if (userToUpdate == null)
                    return BadRequest();
                return Ok(userUpdated);
                //return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
            }
            catch (Exception e){
                throw e;
            }
        }
    }
}
