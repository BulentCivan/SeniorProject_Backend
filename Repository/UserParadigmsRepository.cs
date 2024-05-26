using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserParadigmsRepository : IUserParadigmsRepository
    {
        private readonly ApplicationDBContext _context;
        public UserParadigmsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<UserParadigm> CreateAsync(UserParadigm userParadigm)
        {
            await _context.UserParadigms.AddAsync(userParadigm);
            await _context.SaveChangesAsync();
            return userParadigm;
        }


        public async Task<UserParadigm> DeleteAsync(AppUser appUser, int paradigmId)
        {
            var userParadigmModel = await _context.UserParadigms.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.Paradigm.Id == paradigmId);

            if (userParadigmModel == null)
            {
                return null;
            }

            _context.UserParadigms.Remove(userParadigmModel);
            _context.SaveChanges();

            return userParadigmModel;

        }

        public async Task<List<Paradigm>> GetUserParadigms(AppUser user)
        {
            return await _context.UserParadigms.Where(p => p.AppUserId == user.Id)
            .Select(paradigm => new Paradigm
            {
                Id = paradigm.ParadigmId,
                Title = paradigm.Paradigm.Title,
                Content = paradigm.Paradigm.Content,
                Result = paradigm.Paradigm.Result
            }).ToListAsync();
        }

        public async Task<List<Paradigm>> GetUserParadigmsByEmail(string email)
        {
            return await _context.UserParadigms.Where(p => p.AppUser.Email == email)
            .Select(paradigm => new Paradigm
            {
                Id = paradigm.ParadigmId,
                Title = paradigm.Paradigm.Title,
                Content = paradigm.Paradigm.Content,
                Result = paradigm.Paradigm.Result
            }).ToListAsync();
        }
    }
}