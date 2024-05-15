using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ITestQuestionRepository
    {
        Task<List<Question>> GetTestQuestions(Test test);
        Task<TestQuestion> CreateAsync (TestQuestion testQuestion);
        Task<TestQuestion> DeleteAsync (Test test, int questionId);
    }
}