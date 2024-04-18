using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Paradigm;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ParadigmRepository : IParadigmRepository
    {
        private readonly ApplicationDBContext _context;

        public ParadigmRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<Paradigm> CreateAsync(Paradigm paradigmModel)
        {
            await _context.Paradigms.AddAsync(paradigmModel);
            await _context.SaveChangesAsync();
            return paradigmModel;
        }

        public async Task<Paradigm?> DeleteAsync(int id)
        {
            var paradigmModel = await _context.Paradigms.FirstOrDefaultAsync(x => x.Id == id);
            if (paradigmModel == null){
                return null;
            }
            _context.Paradigms.Remove(paradigmModel);
            await _context.SaveChangesAsync();
            return paradigmModel;
        }

        public async Task<List<Paradigm>> GetAllAsync()
        {
            return await _context.Paradigms.ToListAsync();
        }

        public async Task<Paradigm?> GetByIdAsync(int id)
        {
            return await _context.Paradigms.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Paradigm?> UpdateAsync(int id, UpdateParadigmRequestDto paradigmDto)
        {
            var existingParadigm = await _context.Paradigms.FindAsync(id);

            if (existingParadigm == null)
            {
                return null;
            }

            existingParadigm.Content=paradigmDto.Content;
            
            await _context.SaveChangesAsync();

            return existingParadigm;
        }
    }
}