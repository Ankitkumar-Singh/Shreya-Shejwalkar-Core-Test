using CandidateQualifications.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CandidateQualifications.Repositories
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetAllCandidates();

        Candidate GetCandidateDetails(int Id);

        Candidate SaveCandidateDetails(Candidate candidate);

        Candidate DeleteCandidate(int Id);

        List<SelectListItem> GetQualificationList();
    }
}
