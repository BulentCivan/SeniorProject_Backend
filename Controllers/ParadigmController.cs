using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Paradigm;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/paradigm")]
    [ApiController]
    public class ParadigmController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        
        private readonly IParadigmRepository _paradigmRepo;
        

        public ParadigmController(ApplicationDBContext context, IParadigmRepository paradigmRepo){
            _paradigmRepo = paradigmRepo;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(){

            var paradigms =await _paradigmRepo.GetAllAsync();

            var paradigmDto= paradigms.Select(s => s.ToParadigmDto());

            return Ok(paradigms);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var paradigm =await _paradigmRepo.GetByIdAsync(id);
            if(paradigm == null){
                return NotFound();
            }
            return Ok(paradigm.ToParadigmDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateParadigmRequestDto paradigmDto)
        {
            var paradigmModel = paradigmDto.ToParadigmFromCreate();
            await _paradigmRepo.CreateAsync(paradigmModel);
            return CreatedAtAction(nameof(GetById), new{id=paradigmModel.Id}, paradigmModel.ToParadigmDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateParadigmRequestDto updateDto)
        {
            var paradigmModel = await _paradigmRepo.UpdateAsync(id, updateDto);
            if(paradigmModel == null){
                return NotFound();
            }


            return Ok(paradigmModel.ToParadigmDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var testModel =await _paradigmRepo.DeleteAsync(id);
            if(testModel == null){
                return NotFound();
            }

            return NoContent();
        }
    }
}