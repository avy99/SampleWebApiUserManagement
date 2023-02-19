using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.DataAccess.Repository;
using UserManagement.Model.Models;

namespace SampleWebApiUserManagement.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : Controller
    {
        private readonly IunitOfWork _unitofWork;

        public UsersController(IunitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitofWork.Users.GetAll();
        }

        [HttpGet("{userEmail}")]
        public async Task<ActionResult<User>> GetUser(string userEmail)
        {
            try
            {
                var user = await _unitofWork.Users.Get(userEmail);
                if (user != null)
                    return user;
                return NotFound("No object with such Id in database");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{userEmail}")]
        public async Task<ActionResult> GetAllUsers(string userEmail)
        {
            try
            {
                var user = await _unitofWork.Users.Get(userEmail);
                if (user != null)
                    await _unitofWork.Users.Remove(user);
                _unitofWork.Save();
                return NotFound("No object with such Id in database");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUsers([FromBody] User user)
        {
            try
            {
                await _unitofWork.Users.Add(user);
                _unitofWork.Save();
                return user;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch]
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUsers([FromBody] User user)
        {
            try
            {
                await _unitofWork.Users.Update(user);
                _unitofWork.Save();
                return user;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}