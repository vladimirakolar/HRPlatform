using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISkillRepository
    {
        Task<Skill> GetSkillByIdAsync(int id);
        Task<IList<Skill>> GetSkillsAsync();
        Task CreateSkillAsync(Skill skill);
        Task DeleteSkillAsync(Skill skill);
    }
}
