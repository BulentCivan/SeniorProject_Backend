using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Test;
using api.Models;

namespace api.Interfaces
{
    public interface ITestRepository
    {
        Task<List<Test>> GetAllAsync();
        Task<Test?> GetByIdAsync(int id); //First or default
        Test GetById(int id);

        Task<Test> CreateAsync(Test testModel);

        Task<Test?> UpdateAsync(int id,UpdateTestRequestDto testDto);

        Task<Test?> DeleteAsync(int id);

        Task<bool> TestExist(int id);

    }
}