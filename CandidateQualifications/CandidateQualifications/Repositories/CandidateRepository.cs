using CandidateQualifications.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CandidateQualifications.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext context;
        public CandidateRepository(AppDbContext context)
        {
            this.context = context;
        }

        #region "GetAllCandidates"
        /// <summary>
        /// Get List of Candidates
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Candidate> GetAllCandidates() => context.Candidate.Include(e => e.Qualification).ToList();
        #endregion

        #region "Get Candidate Details"
        /// <summary>
        /// Get Candidate Details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Candidate GetCandidateDetails(int Id) => context.Candidate.Include(e => e.Qualification).SingleOrDefault(e => e.Id == Id);
        #endregion

        #region "Add and edit Candidate Details"
        /// <summary>
        /// Add and edit Candidate Details
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public Candidate SaveCandidateDetails(Candidate candidate)
        {
            if (candidate != null)
            {
                if (candidate.Id == 0)
                    context.Candidate.Add(candidate);
                else
                    context.Entry(candidate).State = EntityState.Modified;
                context.SaveChanges();
            }
            return context.Candidate.Where(e => e.FirstName == candidate.FirstName).FirstOrDefault();
        }
        #endregion

        #region "Delete Candidate Details"
        /// <summary>
        /// Delete Candidate Details by their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Candidate DeleteCandidate(int Id)
        {
            Candidate candidate = context.Candidate.Find(Id);
            if (candidate != null)
            {
                context.Candidate.Remove(candidate);
                context.SaveChanges();
            }
            return candidate;
        }
        #endregion

        public List<SelectListItem> GetQualificationList()
        {
            return context.Qualification.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Title
            }).ToList();
        }

        #region "Search"
        /// <summary>
        /// Search candidate by its firstname or lastname
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<Candidate> SearchCandidate(string search) => context.Candidate.Where(p => p.FirstName.StartsWith(search) || p.LastName.StartsWith(search)).ToList();    
        #endregion
    }
}

