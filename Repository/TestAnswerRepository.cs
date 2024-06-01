using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Test;
using api.Interfaces;
using api.Mappers;

using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TestAnswerRepository : ITestAnswerRepository
    {
        private readonly ApplicationDBContext _context;

        public TestAnswerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TestAnswer> CreateAsync(TestAnswer testAnswer)
        {
            await _context.TestAnswers.AddAsync(testAnswer);
            await _context.SaveChangesAsync();
            return testAnswer;
        }

        public async Task<bool> SolveTest(List<TestAnswer> testAnswers)
        {

            try
            {
                foreach (var testAnswer in testAnswers)
                {
                    await CreateAsync(testAnswer);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return true;


        }

        public async Task<List<TestAnswerDto>> GetTestAnswersAsync(int testId)
        {
            try
            {
                var tests = await _context.TestAnswers.Where(x => x.TestId == testId).ToListAsync();

                return tests.Select(t => t.ToTestDto()).ToList();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}