using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/UserParadigm")]
    [ApiController]
    public class UserParadigmController : ControllerBase
    {
        private readonly IParadigmRepository _paradigmRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserParadigmsRepository _userParadigmsRepository;
        public UserParadigmController(UserManager<AppUser> userManager, IParadigmRepository paradigmRepo, IUserParadigmsRepository userParadigmsRepo){
                _userManager = userManager;
                _paradigmRepository = paradigmRepo;
                _userParadigmsRepository = userParadigmsRepo;
        }   

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserParadigms()
        {
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var userParadigms = await _userParadigmsRepository.GetUserParadigms(appUser);
            return Ok(userParadigms);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserParadigms(int paradigmId)
        {
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var paradigm = await _paradigmRepository.GetByIdAsync(paradigmId);

            if (paradigm == null)
            {
                return BadRequest("Paradigm not found");
            }

            //var userParadigms = await _userParadigmsRepository.GetUserParadigms(appUser);

            var userParadigmModel = new UserParadigm
            {
                AppUserId = appUser.Id,
                ParadigmId = paradigm.Id
            };

            await _userParadigmsRepository.CreateAsync(userParadigmModel);

            if (userParadigmModel== null)
            {
                return StatusCode(500,"Could not create.");
            }
            else{
                return Created();
            }

            
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUserParadigms(int paradigmId){
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var userParadigms = await _userParadigmsRepository.GetUserParadigms(appUser);
            var filteredParadigm = userParadigms.Where(s => s.Id == paradigmId).ToList();

            if (filteredParadigm.Count() ==1)
            {
                await _userParadigmsRepository.DeleteAsync(appUser,paradigmId);
            }
            else
            {
                return BadRequest("Paradigm not found");
            }
            return Ok();
            
        }
    }
}