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
    /*public class TestQuestionsRepository : ITestQuestionRepository
    {
        private readonly ApplicationDBContext _context;
        public TestQuestionsRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<TestQuestion> CreateAsync(TestQuestion testQuestion)
        {
            await _context.TestQuestions.AddAsync(testQuestion);
            await _context.SaveChangesAsync();
            return testQuestion;
        }

        public async Task<TestQuestion> DeleteAsync(Test test, int questionId)
        {
            var testQuestionModel = await _context.TestQuestions.FirstOrDefaultAsync( x => x.TestId == test.Id && x.Question.Id == questionId); 

            if (testQuestionModel == null)
            {
                return null;
            }

            _context.TestQuestions.Remove(testQuestionModel);
            _context.SaveChanges();

            return testQuestionModel;
        }

        public async Task<List<Question>> GetTestQuestions(Test test)
        {
            return await _context.TestQuestions.Where(p => p.TestId == test.Id)
            .Select(question => new Question
            {
                Id = question.QuestionId,
                Content=question.Question.Content,
                Type = question.Question.Type,
                Answer = question.Question.Answer
            }).ToListAsync();
        }
    }*/
}