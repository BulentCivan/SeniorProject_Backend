using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Test;
using api.Extensions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/UserTest")]
    [ApiController]
    public class UserTestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserTestRepository _userTestRepository;
        public UserTestController(UserManager<AppUser> userManager, ITestRepository testRepo, IUserTestRepository userTestRepo){
                _userManager = userManager;
                _testRepository = testRepo;
                _userTestRepository = userTestRepo;
        }   

        

        

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserTest(int testId)
        {
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var test = await _testRepository.GetByIdAsync(testId);

            if (test == null)
            {
                return BadRequest("Test not found");
            }

            var userTestModel = new UserTest
            {
                AppUserId = appUser.Id,
                TestId = test.Id
            };

            await _userTestRepository.CreateAsync(userTestModel);

            if (userTestModel== null)
            {
                return StatusCode(500,"Could not create.");
            }
            else{
                return Created();
            }

            
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteUserTest(int testId){
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var userTests = await _userTestRepository.GetUserTests(appUser);
            var filteredParadigm = userTests.Where(s => s.Id == testId).ToList();

            if (filteredParadigm.Count() ==1)
            {
                await _userTestRepository.DeleteAsync(appUser,testId);
            }
            else
            {
                return BadRequest("Test not found");
            }
            return Ok();
            
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserTests()
        {
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var userTests = await _userTestRepository.GetUserTests(appUser);
            return Ok(userTests);
        }

        [HttpPost("testName")]
        [Authorize]
        public async Task<IActionResult> GetUserTestByName([FromBody] GetAskedTestDto testDto)
        {
            var userName=User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(userName);
            var userTests = await _userTestRepository.GetUserTests(appUser);

            List<Test> userTestList = new List<Test>();
            for (int i = 0; i < userTests.Count; i++)
            {
                if (userTests[i].Name == testDto.Name)
                {
                    userTestList.Add(userTests[i]);
                }
            }
            
            return Ok(userTestList);
        }
    }
}