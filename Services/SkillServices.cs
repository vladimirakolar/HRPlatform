using Core.Entities;
using Core.Repositories;
using Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class SkillServices : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillServices(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<Skill> GetSkill(int id)
        {
            return await _skillRepository.GetSkillById(id);
        }

        public async Task<IList<Skill>> GetSkills()
        {
            return await _skillRepository.GetSkills();
        }
    }
}
