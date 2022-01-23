using Core.Entities;
using System.Collections.Generic;

namespace API.ViewModels
{
    public class CandidatesViewModel
    {
        public List<Candidate> Candidates { get; set; }

        public int Count { get; set; }
    }


}
