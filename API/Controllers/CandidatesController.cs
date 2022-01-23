using API.RequestModels;
using API.Validators;
using API.ViewModels;
using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Route("api/candidates")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public CandidatesController(ICandidateService candidateService, IMapper mapper, ISkillService skillService)
        {
             _candidateService = candidateService;
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<CandidatesViewModel>> GetAllCandidatesAysinc()
        {
            var candidates = await _candidateService.GetCandidatesAsync();

            if (candidates == null || candidates.Count == 0)
            {
                return NotFound("No candidates in database!");
            }

            var candidatesViewModel = new CandidatesViewModel
            {
                Candidates = candidates.ToList(),
                Count = candidates.Count
            };

            return Ok(candidatesViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidateByIdAysinc(int id)
        {
            var candidate = await _candidateService.GetCandidateAsync(id);

            if (candidate == null)
            {
                return BadRequest("Candidate with given id is not found!");
            }
            
            return Ok(candidate);
        }

        [HttpGet("searchbyname/{name}")]
        public async Task<ActionResult<CandidatesViewModel>> SearchCandidatesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name is empty");
            }

            var candidates = await _candidateService.GetCandidatesByNameAsync(name);

            if (candidates == null || candidates.Count == 0)
            {
                return NotFound("No candidates with given name!");
            }

            var candidatesViewModel = new CandidatesViewModel
            {
                Candidates = candidates.ToList(),
                Count = candidates.Count
            };

            return Ok(candidatesViewModel);
        }

        [HttpGet("searchbyskill/{skillName}")]
        public async Task<ActionResult<CandidatesViewModel>> SearchCandidatesBySkillNameAsync(string skillName)
        {
            if (string.IsNullOrWhiteSpace(skillName))
            {
                return BadRequest("Skill name is empty");
            }

            var candidates = await _candidateService.GetCandidatesBySkillAsync(skillName);

            if (candidates == null || candidates.Count == 0)
            {
                return NotFound("No candidates with given skill!");
            }

            var candidatesViewModel = new CandidatesViewModel
            {
                Candidates = candidates.ToList(),
                Count = candidates.Count
            };

            return Ok(candidatesViewModel);
        }

        [HttpPost("")]
        public async Task<ActionResult<Candidate>> CreateCandidateAsync([FromBody] CreateCandidateModel model)
        {
            var validator = new CreateCandidateModelValidator();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var candidateToCreate = _mapper.Map<CreateCandidateModel, Candidate>(model);

            var newCandidate = await _candidateService.CreateCandidateAsync(candidateToCreate);

            return Ok(newCandidate);
        }

        [HttpPut("{candidateId}/addskill/{skillId}")]
        public async Task<ActionResult<Candidate>> AddSkillToCandidateAsync(int candidateId, int skillId) 
        {
            var candidate = await _candidateService.GetCandidateAsync(candidateId);

            if (candidate == null)
            {
                return BadRequest("Invalide candidate Id");
            }

            var skill = await _skillService.GetSkillAsync(skillId);

            if (skill == null)
            {
                return BadRequest("Invalide skill Id");
            }

            if (candidate.Skills.Contains(skill))
            {
                return BadRequest("Candidate alredy contains given skill!");
            }

            var updateCandidate = await _candidateService.AddSkillToCandidateAsync(candidateId, skillId);

            return Ok(updateCandidate);
        }

        [HttpPut("{candidateId}/removekill/{skillId}")]
        public async Task<ActionResult<Candidate>> RemoveSkillFromCandidateAsync(int candidateId, int skillId)
        {
            var candidate = await _candidateService.GetCandidateAsync(candidateId);

            if (candidate == null)
            {
                return BadRequest("Invalide candidate Id");
            }

            var skill = await _skillService.GetSkillAsync(skillId);

            if (skill == null)
            {
                return BadRequest("Invalide skill Id");
            }

            if (!candidate.Skills.Contains(skill))
            {
                return BadRequest("Candidate does not contain given skill!");
            }

            var updateCandidate = await _candidateService.RemoveSkillFromCandidateAsync(candidateId, skillId);

            return Ok(updateCandidate);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteCandidateAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var candidate = await _candidateService.GetCandidateAsync(id);

            if (candidate == null)
            {
                return NotFound();
            }

            await _candidateService.DeleteCandidateAsync(candidate);

            return NoContent();
        }
    }
}
