using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Question;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController :  ControllerBase
    {
        private readonly IQuestionRepository _questionRepo;
        private readonly ITestRepository _testRepo;

        public QuestionController(IQuestionRepository questionRepo, ITestRepository testRepository){
            _questionRepo = questionRepo;
            _testRepo = testRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var questions = await _questionRepo.GetAllAsync();

            var questionDto = questions.Select(x => x.ToQuestionDto());
            return Ok(questionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var question =await _questionRepo.GetByIdAsync(id);
            if(question == null){
                return NotFound();
            }
            return Ok(question.ToQuestionDto());
        }

        [HttpPost("{testId:int}")]
        public async Task<IActionResult> Create([FromRoute] int testId, CreateQuestionDto questionDto) {

            if(!await _testRepo.TestExist(testId)){
                return BadRequest("Test does not exist");
            }

            var questionModel = questionDto.ToQuestionFromCreate(testId);
            await _questionRepo.CreateAsync(questionModel);
            return CreatedAtAction(nameof(GetById),new {id = questionModel}, questionModel.ToQuestionDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var questionModel = await _questionRepo.DeleteAsync(id);

            if(questionModel == null){
                return NotFound ("Question not exist");
            }

            return Ok(questionModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update ([FromRoute] int id,[FromBody] UpdateQuestionRequestDto updateDto) {
            var question = await _questionRepo.UpdateAsync(id, updateDto);
            if(question == null){
                return NotFound ("Question not found");
            }

            return Ok(question.ToQuestionDto());
        }

        [HttpPut]
        [Route("solve/{id:int}")]
        public async Task<IActionResult> Solve ([FromRoute] int id, int answer) {
            var question = await _questionRepo.SolveAsync(id, answer);
            if(question == null){
                return NotFound ("Question not found");
            }

            return Ok(question.ToQuestionDto());
        }

        
    }
}