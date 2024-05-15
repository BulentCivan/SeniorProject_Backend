using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Mood;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MoodRepository : IMoodRepository
    {
        private readonly ApplicationDBContext _context;

        public MoodRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<Mood> CreateAsync(Mood moodModel)
        {
            await _context.Moods.AddAsync(moodModel);
            await _context.SaveChangesAsync();
            return moodModel;
        }

        public async Task<Mood?> DeleteAsync(int id)
        {
            var moodModel = await _context.Moods.FirstOrDefaultAsync(x => x.Id == id);
            if (moodModel == null){
                return null;
            }
            _context.Moods.Remove(moodModel);
            await _context.SaveChangesAsync();
            return moodModel;
        }

        public async Task<List<Mood>> GetAllAsync()
        {
            return await _context.Moods.ToListAsync();
        }

       public async Task<List<Mood>> GetFromMonthAsync()
        {
            // Get the current date
            var currentDate = DateTime.Today;

            // Calculate the start and end dates for the current month
            var startOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            // Query the database for moods within the current month
            var moods = await _context.Moods
            .Where(m => m.CreatedOn >= startOfMonth && m.CreatedOn <= endOfMonth)
            .ToListAsync();

            return moods;
        }

        public async Task<Mood?> UpdateAsync(int id, UpdateMoodDto moodDto)
        {
            var existingMood = await _context.Moods.FindAsync(id);

            if (existingMood == null)
            {
                return null;
            }

            existingMood.Content=moodDto.Content;
            existingMood.mood=moodDto.mood;
            
            await _context.SaveChangesAsync();

            return existingMood;
        }

        public async Task<Mood?> GetByIdAsync(int id)
        {
            return await _context.Moods.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}