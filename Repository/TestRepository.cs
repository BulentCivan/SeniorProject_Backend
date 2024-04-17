using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Test;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDBContext _context;
        public TestRepository(ApplicationDBContext context){
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
            if (testModel == null){
                return null;
            }

            _context.Tests.Remove(testModel);
            await _context.SaveChangesAsync();
            return testModel;
        }

        public async Task<List<Test>> GetAllAsync()
        {
            return await _context.Tests.Include(c => c.Questions).ToListAsync();
        }

        public async Task<Test?> GetByIdAsync(int id)
        {
            return await _context.Tests.Include(c => c.Questions).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> TestExist(int id)
        {
            return _context.Tests.AnyAsync(s => s.Id == id);
        }

        public async Task<Test?> UpdateAsync(int id, UpdateTestRequestDto testDto)
        {
            var existingTest = await _context.Tests.FirstOrDefaultAsync(x=> x.Id == id);
            if(existingTest == null){
                return null;
            }

            existingTest.Name = testDto.Name;

            await _context.SaveChangesAsync();

            return existingTest;
        }
    }
}