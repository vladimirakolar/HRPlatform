using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetCandidateById(int id);
        Task<IList<Candidate>> GetCandidates();

    }
}
