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
    public class UserMoodRepository : IUserMoodRepository
    {
         private readonly ApplicationDBContext _context;
        public UserMoodRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<UserMood> CreateAsync(UserMood userMood)
        {
            await _context.UserMoods.AddAsync(userMood);
            await _context.SaveChangesAsync();
            return userMood;
        }

        public async Task<UserMood> DeleteAsync(AppUser appUser, int MoodId)
        {
            var userMoodModel = await _context.UserMoods.FirstOrDefaultAsync( x => x.AppUserId == appUser.Id && x.Mood.Id == MoodId);

            if (userMoodModel == null)
            {
                return null;
            }

            _context.UserMoods.Remove(userMoodModel);
            _context.SaveChanges();

            return userMoodModel;
        }

        public async Task<List<Mood>> GetUserMoods(AppUser user)
        {
             return await _context.UserMoods.Where(p => p.AppUserId == user.Id)
            .Select(mood => new Mood
            {
                Id = mood.MoodId,
                mood = mood.Mood.mood,
                Content=mood.Mood.Content,
            }).ToListAsync();
        }
    }
}