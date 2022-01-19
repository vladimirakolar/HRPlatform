﻿using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly HRPlatformDbContext _context;

        public CandidateRepository(HRPlatformDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate> GetCandidateByIdAsync(int id)
        {
            return await _context.Candidates.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IList<Candidate>> GetCandidatesAsync()
        {
            return await _context.Candidates.ToListAsync();
        }
    }
}