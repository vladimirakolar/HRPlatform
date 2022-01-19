using API.ViwModels;
using AutoMapper;
using Core.Entities;

namespace API.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            
            CreateMap<Candidate, CandidateViwModel>();
            CreateMap<Skill, SkillViwModel>();

            CreateMap<CandidateViwModel, Candidate>();
            CreateMap<SkillViwModel, Skill>();

        }

    }
}
