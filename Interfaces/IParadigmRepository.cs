using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Paradigm;
using api.Models;

namespace api.Interfaces
{
    public interface IParadigmRepository
    {
        Task<List<Paradigm>> GetAllAsync();
        Task<Paradigm?> GetByIdAsync(int id); //First or default

        Task<Paradigm> CreateAsync(Paradigm paradigmModel);

        Task<Paradigm?> DeleteAsync(int id);

        Task<Paradigm?> UpdateAsync(int id,UpdateParadigmRequestDto paradigmDto);
    }
}