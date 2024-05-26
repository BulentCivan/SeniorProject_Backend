using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SeniorProject_Backend2.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClients(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var users = await _userManager.Users.Where(x => x.AdminId == id).ToListAsync();

            return Ok(users);
        }


    }
}