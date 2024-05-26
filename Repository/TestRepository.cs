using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Test;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Dtos.Test;
using api.Mappers;

namespace api.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDBContext _context;




        public TestRepository(ApplicationDBContext context)
        {
            _context = context;


        }

        public async Task<Test> CreateAsync(Test testModel)
        {
            await _context.Tests.AddAsync(testModel);
            await _context.SaveChangesAsync();
            return testModel;
        }

        public async Task<Test?> DeleteAsync(int id)
        {
            var testModel = await _context.Tests.FirstOrDefaultAsync(x => x.Id == id);
            if (testModel == null)
            {
                return null;
            }

            _context.Tests.Remove(testModel);
            await _context.SaveChangesAsync();
            return testModel;
        }

        public async Task<List<Test>> GetAllAsync()
        {
            return await _context.Tests.ToListAsync();
        }

        //public Test GetById(int id)
        //{
        // return  _context.Tests.FirstOrDefault(i => i.Id == id);
        //}

        public async Task<Test?> GetByIdAsync(int id)
        {
            return await _context.Tests.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Test?> GetByTestTitleAsync(string Name)
        {
            return await _context.Tests.FirstOrDefaultAsync(i => i.Name == Name);
        }


        public async Task<Test?> SolveTestAsync(Test test, List<TestAnswerDto> answers)
        {
            var existingTest = await _context.Tests
            .Where(x => x.Name.ToLower().Equals(test.Name.ToLower()) && x.PatientEmail.Equals(test.PatientEmail))
            .FirstOrDefaultAsync();
            int testResult = 0;

            foreach (var answer in answers)
            {
                await CreateTestAnswerAsync(answer.ToTestAnswerFromTestAnswerDto(existingTest));
                testResult += answer.Answer;
            }

            existingTest.Result = testResult;
            return existingTest;

        }

        public Task<bool> TestExist(int id)
        {
            return _context.Tests.AnyAsync(s => s.Id == id);
        }

        public async Task<Test?> UpdateAsync(int id, UpdateTestRequestDto testDto)
        {
            var existingTest = await _context.Tests.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTest == null)
            {
                return null;
            }

            existingTest.Name = testDto.Name;

            await _context.SaveChangesAsync();

            return existingTest;
        }

        public async Task<TestAnswer> CreateTestAnswerAsync(TestAnswer testAnswer)
        {
            await _context.TestAnswers.AddAsync(testAnswer);
            await _context.SaveChangesAsync();
            return testAnswer;
        }

    }
}