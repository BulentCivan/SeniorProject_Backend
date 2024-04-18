using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Question;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDBContext _context;
        public QuestionRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<Question> CreateAsync(Question questionModel)
        {
            await _context.Questions.AddAsync(questionModel);
            await _context.SaveChangesAsync();
            return questionModel;
        }

        public async Task<Question?> DeleteAsync(int id)
        {
            var questionModel = await _context.Questions.FirstOrDefaultAsync(x => x.Id == id);
            if (questionModel == null){
                return null;
            }
            _context.Questions.Remove(questionModel);
            await _context.SaveChangesAsync();
            return questionModel;
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
            
        }

        public Task<Question?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<Question?> UpdateAsync(int id, UpdateQuestionRequestDto questionDto)
        {
            var existingQuestion = await _context.Questions.FindAsync(id);

            if (existingQuestion == null)
            {
                return null;
            }

            existingQuestion.Content=questionDto.Content;
            existingQuestion.Type=questionDto.Type;
            
            await _context.SaveChangesAsync();

            return existingQuestion;

        }

        
    }
}