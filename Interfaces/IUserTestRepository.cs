using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserTestRepository
    {
        Task<List<Test>> GetUserTests(AppUser user);
        Task<UserTest> CreateAsync (UserTest userTest);
        Task<UserTest> DeleteAsync (AppUser appUser, int TestId);
        Task<List<Test>> GetUserTestResultAsync (AppUser user,string TestName);

    }
}