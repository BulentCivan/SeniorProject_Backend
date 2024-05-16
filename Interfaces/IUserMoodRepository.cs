using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserMoodRepository
    {
        Task<List<Mood>> GetUserMoods(AppUser user);
        Task<UserMood> CreateAsync (UserMood userMood);
        Task<UserMood> DeleteAsync (AppUser appUser, int MoodId); 
    }
}