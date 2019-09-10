using CandidateQualifications.Models;
using CandidateQualifications.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CandidateQualifications.Controllers
{
    [Route("Candidate")]
    public class CandidateController : Controller
    {
        private readonly ICandidateRepository _candidateRepository;        
        readonly AppDbContext context;

        #region "Constructor"
        /// <summary>
        /// Constructor to implement ICandidateRepository Interface and AppDbContext
        /// </summary>
        /// <param name="context"></param>
        /// <param name="candidateRepository"></param>
        public CandidateController(AppDbContext context, ICandidateRepository candidateRepository)
        {
            this.context = context;
            _candidateRepository = candidateRepository;
        }
        #endregion

        #region "Index"
        /// <summary>
        /// List  Candidates
        /// </summary>
        /// <returns></returns>      
        [Route("Index")]
        public ViewResult Index() => View(_candidateRepository.GetAllCandidates());        
        #endregion

        #region "Details"
        /// <summary>
        /// Get Candidate Details by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Details")]
        public ViewResult Details(int id) =>  View(_candidateRepository.GetCandidateDetails(id));      
        #endregion

        #region "Add and Edit Candidate Details"
        /// <summary>
        /// Add and Edit Candiate Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("SaveCandidateDetails/{id?}")]
        [HttpGet]
        public ViewResult SaveCandidateDetails(int id)
        {
            ViewBag.QualificationId = _candidateRepository.GetQualificationList();
            var model = _candidateRepository.GetCandidateDetails(id);
            if (model == null)
                model = new Candidate();
            return View(model);
        }

        [Route("SaveCandidateDetails/{id?}")]
        [HttpPost]
        public IActionResult SaveCandidateDetails(Candidate candidate)
        {
            ViewBag.QualificationId = _candidateRepository.GetQualificationList();
            if (ModelState.IsValid)
            {
                _candidateRepository.SaveCandidateDetails(candidate);
                return RedirectToAction("Index");
            } 
            return View();
        }
        #endregion

        #region "Delete"
        /// <summary>
        /// Delete Candidate 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Delete/{id?}")]
        [HttpGet]
        public ViewResult Delete(int? id) => View(_candidateRepository.GetCandidateDetails(id ?? 1));

        [Route("Delete/{id?}")]
        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            _candidateRepository.DeleteCandidate(id);
           return  RedirectToAction("Index");
        } 
        #endregion      
    }
}