using API.RequestModels;
using API.Validators;
using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillsController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<Skill>>> GetAllSkillAysinc()
        {
            var skills = await _skillService.GetSkillsAsync();

            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkillByIdAysinc(int id)
        {
            var skill = await _skillService.GetSkillAsync(id);

            if (skill == null)
            {
                return BadRequest("Skill with given id is not found!");
            }

            return Ok(skill);
        }

        [HttpPost("")]
        public async Task<ActionResult<Skill>> CreateSkillAsync([FromBody] CreateSkillModel model)
        {
            var validator = new CreateSkillModelValidator();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var skillToCreate = _mapper.Map<CreateSkillModel, Skill>(model);

            var newSkill = await _skillService.CreateSkillAsync(skillToCreate);

            return Ok(newSkill);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteSkillAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var skill = await _skillService.GetSkillAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            await _skillService.DeleteSkillAsync(skill);

            return NoContent();
        }
    }
}
