using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Question;
using api.Models;

namespace api.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllAsync();
        Task<Question?> GetByIdAsync(int id); //First or default

        Task<Question> CreateAsync(Question questionModel);

        Task<Question?> DeleteAsync(int id);

        Task<Question?> UpdateAsync(int id,UpdateQuestionRequestDto questionDto);
    }
}