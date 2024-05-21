using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Test;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITestRepository _testRepo;
        public TestController(ApplicationDBContext context, ITestRepository testRepo){
            _testRepo = testRepo;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(){

            var tests =await _testRepo.GetAllAsync();

            var testDto= tests.Select(s => s.ToTestDto());

            return Ok(tests);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var test =await _testRepo.GetByIdAsync(id);
            if(test == null){
                return NotFound();
            }
            return Ok(test.ToTestDto());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTestRequestDto testDto)
        {
            var testModel = testDto.ToTestFromCreateDto();
            await _testRepo.CreateAsync(testModel);
            return CreatedAtAction(nameof(GetById), new{id=testModel.Id}, testModel.ToTestDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTestRequestDto updateDto)
        {
            var testModel = await _testRepo.UpdateAsync(id, updateDto);
            if(testModel == null){
                return NotFound();
            }


            return Ok(testModel.ToTestDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var testModel =await _testRepo.DeleteAsync(id);
            if(testModel == null){
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("solve")]
        public async Task<IActionResult> SolveTest([FromBody] SolveTestDto testDto)
        {
            var testModel = testDto.ToTestFromSolveDto();
            var solvedTest=await _testRepo.SolveTestAsync(testModel,testDto.Answers);
            return Ok(solvedTest);
        }
    }
}