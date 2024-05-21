using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserTestRepository : IUserTestRepository
    {
        private readonly ApplicationDBContext _context;
        public UserTestRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<UserTest> CreateAsync(UserTest userTest)
        {
            await _context.UserTests.AddAsync(userTest);
            await _context.SaveChangesAsync();
            return userTest;
        }

        public async Task<UserTest> DeleteAsync(AppUser appUser, int TestId)
        {
            var userTestModel = await _context.UserTests.FirstOrDefaultAsync( x => x.AppUserId == appUser.Id && x.Test.Id == TestId);

            if (userTestModel == null)
            {
                return null;
            }

            _context.UserTests.Remove(userTestModel);
            _context.SaveChanges();

            return userTestModel;
        }

    
        public async Task<List<Test>> GetUserTestResultAsync(AppUser user, string testName)
{
    if (user == null)
    {
        throw new ArgumentNullException(nameof(user));
    }

    if (string.IsNullOrEmpty(testName))
    {
        throw new ArgumentNullException(nameof(testName));
    }

    return await _context.UserTests
                         .Where(p => p.AppUserId == user.Id && p.Test.Name.ToLower() == testName.ToLower())
                         .Select(test => new Test
                         {
                             Id = test.TestId,
                             Name = test.Test.Name,
                             Result = test.Test.Result,
                             Questions = test.Test.Questions,
                             Answers = test.Test.Answers
                         })
                         .ToListAsync();
}




        public async Task<List<Test>> GetUserTests(AppUser user)
        {
            return await _context.UserTests.Where(p => p.AppUserId == user.Id)
            .Select(test => new Test
            {
                Id = test.TestId,
                Name = test.Test.Name,
                Result = test.Test.Result,
                Questions=test.Test.Questions,
                Answers=test.Test.Answers
            }).ToListAsync();
        }

        
    }
}