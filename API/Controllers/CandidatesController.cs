using API.ViwModels;
using AutoMapper;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidatesController(ICandidateService candidateService, IMapper mapper)
        {
             _candidateService = candidateService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IList<CandidateViwModel>>> GetAllCandidatesAysinc()
        {
            var candidates = _candidateService.GetCandidatesAsync();

            var result = _mapper.Map<IList<CandidateViwModel>>(candidates);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateViwModel>> GetCandidateByIdAysinc(int id)
        {
            var candidate = await _candidateService.GetCandidateAsync(id);
            var result = _mapper.Map<CandidateViwModel>(candidate);

            return Ok(result);
        }
    }
}
