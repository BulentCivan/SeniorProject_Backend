using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Test;
using api.Models;

namespace api.Interfaces
{
    public interface ITestAnswerRepository
    {
        Task<bool> SolveTest(List<TestAnswer> testAnswers);
        Task<List<TestAnswerDto>> GetTestAnswersAsync(int testId);
    }
}