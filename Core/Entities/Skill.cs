
using System.Collections.Generic;

namespace Core.Entities
{
    public class Skill : BaseEntiti
    {

        public Skill()
        {
            Candidates = new List<Candidate>();
        }

        public string Name { get; set; }

        public IList<Candidate> Candidates { get; set; }
    }
}
