using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    /*[Route("api/testQuestion")]
    [ApiController]
    public class TestQuestionController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ITestQuestionRepository _testQuestionRepository;
        public TestQuestionController(ITestRepository testRepo,IQuestionRepository questionRepo,ITestQuestionRepository testQuestionRepo){
            _testRepository = testRepo;
            _questionRepository = questionRepo;
            _testQuestionRepository = testQuestionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestQuestions(int testId)
        {
            var existingTest= await _testRepository.GetByIdAsync(testId);
            var TestQuestions = await _testQuestionRepository.GetTestQuestions(existingTest);
            return Ok(TestQuestions);
        }

        [HttpPost]
        public async Task<IActionResult> AddTestQuestion(int TestId,int QuestionId)
        {
            
            var Test = _testRepository.GetByIdAsync(TestId);
            var Question = _questionRepository.GetByIdAsync(QuestionId);


            if (Test == null)
            {
                return BadRequest("Test not found");
            }

            if (Question == null)
            {
                return BadRequest("Question not found");
            }

            //var userParadigms = await _userParadigmsRepository.GetUserParadigms(appUser);

            var testQuestiionModel = new TestQuestion
            {
                TestId = Test.Id,
                QuestionId = Question.Id
            };

            await _testQuestionRepository.CreateAsync(testQuestiionModel);

            if (testQuestiionModel== null)
            {
                return StatusCode(500,"Could not create.");
            }
            else{
                return Created();
            }

            
        }

        
    }*/
}