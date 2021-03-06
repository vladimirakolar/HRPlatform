using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ISkillService
    {
        Task<Skill> GetSkillAsync(int id);
        Task<IList<Skill>> GetSkillsAsync();
        Task<Skill> CreateSkillAsync(Skill skill);
        Task DeleteSkillAsync(Skill skill);
       
    }
}
