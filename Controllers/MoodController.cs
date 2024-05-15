using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Mood;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class MoodController : ControllerBase
{
    private readonly IMoodRepository _moodRepository;

    public MoodController(IMoodRepository moodRepository)
    {
        _moodRepository = moodRepository;
    }

    // GET api/mood/frommonth
    [HttpGet("frommonth")]
    public async Task<ActionResult<List<Mood>>> GetMoodsFromMonth()
    {
        var moods = await _moodRepository.GetFromMonthAsync();
        return Ok(moods);
    }

    // GET api/mood
    [HttpGet]
    public async Task<ActionResult<List<Mood>>> GetMoods()
    {
        var moods = await _moodRepository.GetAllAsync();
        var moodDto= moods.Select(s => s.ToMoodDto());
        return Ok(moods);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id){
        var mood =await _moodRepository.GetByIdAsync(id);
        if(mood == null){
            return NotFound();
        }
        return Ok(mood.ToMoodDto());
    }

    // POST api/mood
    [HttpPost]
    public async Task<ActionResult<Mood>> CreateMood([FromBody] CreateMoodDto moodDto)
    {
        var moodModel = moodDto.ToMoodFromCreate();
        await _moodRepository.CreateAsync(moodModel);
        return CreatedAtAction(nameof(GetById), new { id = moodModel.Id }, moodModel);
    }


    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateMood([FromRoute] int id, [FromBody] UpdateMoodDto updateDto)
    {
        var moodModel = await _moodRepository.UpdateAsync(id, updateDto);
            if(moodModel == null){
                return NotFound();
            }


            return Ok(moodModel.ToMoodDto());
    }

    // DELETE api/mood/{id}
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteMood([FromRoute] int id)
    {
         var moodModel =await _moodRepository.DeleteAsync(id);
            if(moodModel == null){
                return NotFound();
            }

            return NoContent();
    }

}
}