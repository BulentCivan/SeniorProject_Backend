using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserParadigmsRepository
    {
        Task<List<Paradigm>> GetUserParadigms(AppUser user);
        Task<UserParadigm> CreateAsync (UserParadigm userParadigm);
        Task<UserParadigm> DeleteAsync (AppUser appUser, int paradigmId);
    }
}