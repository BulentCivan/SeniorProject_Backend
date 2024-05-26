using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Test;
using api.Models;

namespace api.Mappers
{
    public static class TestAnswerMapper
    {
        public static TestAnswer ToTestAnswerFromTestAnswerDto(this TestAnswerDto testAnswerDto, Test test)
        {
            return new TestAnswer
            {
                Question = testAnswerDto.Question,
                Answer = testAnswerDto.Answer,
                TestId = test.Id
            };
        }

        public static TestAnswerDto ToTestDto(this TestAnswer testAnswer)
        {
            return new TestAnswerDto
            {
                Question = testAnswer.Question,
                Answer = testAnswer.Answer,
            };
        }
    }
}