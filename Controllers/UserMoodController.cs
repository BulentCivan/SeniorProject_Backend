using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/UserMood")]
    [ApiController]
    public class UserMoodController : ControllerBase
    {
        private readonly IMoodRepository _moodRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserMoodRepository _userMoodRepository;
        public UserMoodController(UserManager<AppUser> userManager, IMoodRepository moodRepo, IUserMoodRepository userMoodRepo){
                _userManager = userManager;
                _moodRepository = moodRepo;
                _userMoodRepository = userMoodRepo;
        }   

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserMoods()
        {
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var userMoods = await _userMoodRepository.GetUserMoods(appUser);
            return Ok(userMoods);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserMoods(int moodId)
        {
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var mood = await _moodRepository.GetByIdAsync(moodId);

            if (mood == null)
            {
                return BadRequest("Mood not found");
            }

            var userMoodModel = new UserMood
            {
                AppUserId = appUser.Id,
                MoodId = mood.Id
            };

            await _userMoodRepository.CreateAsync(userMoodModel);

            if (userMoodModel== null)
            {
                return StatusCode(500,"Could not create.");
            }
            else{
                return Created();
            }

            
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUserMood(int moodId){
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var userMoods = await _userMoodRepository.GetUserMoods(appUser);
            var filteredParadigm = userMoods.Where(s => s.Id == moodId).ToList();

            if (filteredParadigm.Count() ==1)
            {
                await _userMoodRepository.DeleteAsync(appUser,moodId);
            }
            else
            {
                return BadRequest("Mood not found");
            }
            return Ok();
            
        }
        
    }
}