using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Test;
using api.Models;

namespace api.Mappers
{
    public static class TestMappers
    {
        public static TestDto ToTestDto(this Test testModel){
            return new TestDto
            {
                Id = testModel.Id,
                Name = testModel.Name,
                //Questions = testModel.Questions.Select(x => x.ToQuestionDto()).ToList()
            };
        }

        public static Test ToTestFromCreateDto(this CreateTestRequestDto testDto)
        {
            return new Test
            {
                Name = testDto.Name
            };
        }
    }
}