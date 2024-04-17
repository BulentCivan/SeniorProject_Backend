using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Question;
using api.Models;

namespace api.Mappers
{
    public static class QuestionMapper
    {
        public static QuestionDto ToQuestionDto(this Question questionModel){
            return new QuestionDto{
                Id = questionModel.Id,
                Content = questionModel.Content,
                Type = questionModel.Type,
                Answer=questionModel.Answer,
                TestId = questionModel.TestId

            };
        }

        public static Question ToQuestionFromCreate(this CreateQuestionDto questionDto, int testId){
            return new Question
            {

                Content = questionDto.Content,
                Type = questionDto.Type,
                TestId = testId

            };
        }

        public static Question ToQuestionFromUpdate(this UpdateQuestionRequestDto questionDto){
            return new Question
            {
                Type = questionDto.Type,
                Content = questionDto.Content
            
            };
        }
    }
}