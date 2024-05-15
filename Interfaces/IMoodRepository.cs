using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Mood;
using api.Models;

namespace api.Interfaces
{
    public interface IMoodRepository
    {
        Task<List<Mood>> GetAllAsync();
        Task<List<Mood>> GetFromMonthAsync();

        Task<Mood> CreateAsync(Mood moodModel);

        Task<Mood?> DeleteAsync(int id);

        Task<Mood?> GetByIdAsync(int id);

        Task<Mood?> UpdateAsync(int id,UpdateMoodDto moodDto);
    }
}