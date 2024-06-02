using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Paradigm;
using api.Models;

namespace api.Mappers
{
    public static class ParadigmMapper
    {
        public static ParadigmDto ToParadigmDto(this Paradigm paradigmModel){
            return new ParadigmDto{
                Id = paradigmModel.Id,
                Content = paradigmModel.Content,
                userMail = paradigmModel.PatientEmail,
                Result=paradigmModel.Result

            };
        }

        public static Paradigm ToParadigmFromCreate(this CreateParadigmRequestDto paradigmDto){
            return new Paradigm
            {

                Title = paradigmDto.userMail,
                Content = paradigmDto.Content


            };
        }

        public static Paradigm ToParadigmFromUpdate(this UpdateParadigmRequestDto paradigmDto){
            return new Paradigm
            {
                Content = paradigmDto.Content

            
            };
        }
    }
}