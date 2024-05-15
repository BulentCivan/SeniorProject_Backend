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

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signInManager;
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

                var appUser = new AppUser{
                    
                    UserName = registerDto.UserName,
                    UserSurname = registerDto.UserSurname,
                    Email = registerDto.Email,
                    Age = (int)registerDto.Age,
                    Income = (int)registerDto.Income,
                    Gender = registerDto.Gender,
                    IsMarried = registerDto.IsMarried,
                    Department = registerDto.Department,
                    Class = registerDto.Class,
                    Accomodation = registerDto.Accomodation,
                    HasUnease = registerDto.HasUnease,
                    HasUneaseMedicine = registerDto.HasUneaseMedicine,
                    HasPsychologicalDisorder =  registerDto.HasUneaseMedicine,
                    HasPsychologicalDisorderMedicine= registerDto.HasPsychologicalDisorderMedicine,
                    HasPsychologicalTreatment = registerDto.HasUneaseMedicine,
                    ProgressLevel = 1
                    

                };

                var createdUser = await _userManager.CreateAsync(appUser,registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded){
                        return Ok(
                            new NewUserDto{
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser),
                                ProgressLevel = appUser.ProgressLevel
                            }
                        );
                    }else{
                        return StatusCode(500, roleResult.Errors);
                    }
                }else{
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                
                return StatusCode(500,e);
            }
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.UserMail.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password,false);

            if (!result.Succeeded){
                return Unauthorized("User not found");
            }

            return Ok(
                new NewUserDto{
                    
                    Token = _tokenService.CreateToken(user),
                    Email = user.Email,
                    UserName = user.UserName,
                    ProgressLevel = user.ProgressLevel,
                    Gender = user.Gender,
                    IsMarried = user.IsMarried,
                    Department=user.Department,
                    Class = user.Class,
                    Accomodation = user.Accomodation,
                    HasUnease = user.HasUnease,
                    HasUneaseMedicine = user.HasUneaseMedicine,
                    HasPsychologicalDisorder =  user.HasUneaseMedicine,
                    HasPsychologicalDisorderMedicine= user.HasPsychologicalDisorderMedicine,
                    HasPsychologicalTreatment = user.HasUneaseMedicine,
                }
            );
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateDto)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var userName=User.GetUsername();
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null) return Unauthorized("User not found");

            user.UserName=updateDto.UserName;
            user.Gender=updateDto.Gender;
            user.IsMarried=updateDto.IsMarried;
            user.Department=updateDto.Department;
            user.Class=updateDto.Class;
            user.Accomodation=updateDto.Accomodation;
            user.HasUnease=updateDto.HasUnease;
            user.HasUneaseMedicine=updateDto.HasUneaseMedicine;
            user.HasPsychologicalDisorder=updateDto.HasPsychologicalDisorder;
            user.HasPsychologicalDisorderMedicine=updateDto.HasPsychologicalDisorderMedicine;
            user.HasPsychologicalTreatment=updateDto.HasPsychologicalTreatment;
            user.Income=updateDto.Income;

            var result = await _userManager.UpdateAsync(user);

            return Ok(result);
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

    }
}