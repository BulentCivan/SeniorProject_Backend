using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Mood;
using api.Models;

namespace api.Mappers
{
    public static class MoodMapper
    {
        public static MoodDto ToMoodDto(this Mood moodModel){
            return new MoodDto{
                Id = moodModel.Id,
                Content = moodModel.Content,
                mood = moodModel.mood
            };
        }

        public static Mood ToMoodFromCreate(this CreateMoodDto moodDto){
            return new Mood
            {

                mood = moodDto.mood,
                Content = moodDto.Content

            };
        }

        public static Mood ToMoodFromUpdate(this UpdateMoodDto moodDto){
            return new Mood
            {

                mood = moodDto.mood,
                Content = moodDto.Content

            };
        }
    }
}