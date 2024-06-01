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

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IUserParadigmsRepository _userParadigmsRepository;


        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IUserParadigmsRepository userParadigmsRepo)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
            _userParadigmsRepository = userParadigmsRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.Email,
                    Email = registerDto.Email,
                    Age = (int)registerDto.Age,
                    MonthlyIncome = registerDto.MonthlyIncome,
                    Gender = registerDto.Gender,
                    MarialStatus = registerDto.MarialStatus,
                    EducationField = registerDto.EducationField,
                    EducationLevel = registerDto.EducationLevel,
                    LongestResidence = registerDto.LongestResidence,
                    ChronicCondition = registerDto.ChronicCondition,
                    ChronicConditionName = registerDto.ChronicConditionName,
                    ChronicConditionMed = registerDto.ChronicConditionMed,
                    PsychologicalCondition = registerDto.PsychologicalCondition,
                    PsychologicalConditionMed = registerDto.PsychologicalConditionMed,
                    ReceivingPsychoTreatment = registerDto.ReceivingPsychoTreatment,
                    ProgressLevel = 1,
                    AdminId = 1

                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser),
                                ProgressLevel = appUser.ProgressLevel
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.UserMail.ToLower());

            if (user == null) return Unauthorized("Invalid user mail!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("User not found");
            }

            return Ok(
                new NewUserDto
                {

                    Token = _tokenService.CreateToken(user),
                    Email = user.Email,
                    ProgressLevel = user.ProgressLevel,
                    Gender = user.Gender,
                    MarialStatus = user.MarialStatus,
                    EducationField = user.EducationField,
                    EducationLevel = user.EducationLevel,
                    LongestResidence = user.LongestResidence,
                    ChronicCondition = user.ChronicCondition,
                    ChronicConditionMed = user.ChronicConditionMed,
                    PsychologicalCondition = user.PsychologicalCondition,
                    PsychologicalConditionMed = user.PsychologicalConditionMed,
                    ReceivingPsychoTreatment = user.ReceivingPsychoTreatment,
                    AdminId = user.AdminId
                }
            );
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userName = User.GetUsername(); // This will throw if User or the claim is null
                var user = await _userManager.FindByNameAsync(userName);
                if (user == null) return Unauthorized("User not found");

                user.Gender = updateDto.Gender;
                user.MarialStatus = updateDto.MarialStatus;
                user.EducationField = updateDto.EducationField;
                user.EducationLevel = updateDto.EducationLevel;
                user.LongestResidence = updateDto.LongestResidence;
                user.MonthlyIncome = updateDto.MonthlyIncome;
                user.ChronicCondition = updateDto.ChronicCondition;
                user.ChronicConditionName = updateDto.ChronicConditionName ?? "None";
                user.ChronicConditionMed = updateDto.ChronicConditionMed;
                user.PsychologicalCondition = updateDto.PsychologicalCondition;
                user.PsychologicalConditionMed = updateDto.PsychologicalConditionMed;
                user.ReceivingPsychoTreatment = updateDto.ReceivingPsychoTreatment;


                var result = await _userManager.UpdateAsync(user);

                return Ok(new { Message = "User updated successfully" });
            }




            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request if user is null
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message); // 401 Unauthorized if claim is missing
            }
            catch (Exception ex)
            {
                // Log exception and return a generic error message
                // Use a logging framework here to log the exception details
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost("updatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto passwordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == passwordDto.Email.ToLower());

            if (user == null)
            {
                return Unauthorized("User not found");
            }

            var result = await _userManager.ChangePasswordAsync(user, passwordDto.OldPassword, passwordDto.NewPassword);

            if (result.Succeeded)
            {
                return Ok("Password updated successfully");
            }

            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new { Errors = errors });
        }

        [HttpGet("patient")]
        public async Task<IActionResult> GetPatient(string email)
        {
            //paradigma, test,

            if (string.IsNullOrEmpty(email))
            {
                return BadRequest();
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == email);
            var paradigms = await _userParadigmsRepository.GetUserParadigmsByEmail(email);

            // var retVal = new UserAllData()
            // {
            //     User = user,
            //     Tests = tests,
            //     Paradigms = paradigms
            // };
            return Ok(true);
        }

    }
}