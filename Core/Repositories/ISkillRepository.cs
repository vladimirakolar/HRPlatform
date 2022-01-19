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
        Task<Skill> GetSkillById(int id);
        Task<IList<Skill>> GetSkills();
    }
}
