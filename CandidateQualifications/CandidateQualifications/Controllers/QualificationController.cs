using CandidateQualifications.Models;
using CandidateQualifications.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CandidateQualifications.Controllers
{
    [Route("Qualification")]
    public class QualificationController : Controller
    {
        private readonly IQualificationRepository _qualificationRepository;
        readonly AppDbContext context;

        #region "Constructor"
        /// <summary>
        /// Constructor to implement IQualificationRepository Interface and AppDbContext
        /// </summary>
        /// <param name="context"></param>
        /// <param name="qualificationRepository"></param>
        public QualificationController(AppDbContext context, IQualificationRepository qualificationRepository)
        {
            this.context = context;
            _qualificationRepository = qualificationRepository;
        }
        #endregion

        #region "Index"
        /// <summary>
        /// List Qualifications
        /// </summary>
        /// <returns></returns>
        [Route("Index")]
        public ViewResult Index(string search = null)
        {
            if (!string.IsNullOrEmpty(search))
                return View(_qualificationRepository.SearchTitle(search));
            return View(_qualificationRepository.GetAllQualifications());
        } 
        #endregion

        #region "Details"
        /// <summary>
        /// Get Qualification Details by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Details")]
        public ViewResult Details(int id) => View(_qualificationRepository.GetQualificationDetails(id));
        #endregion

        #region "Add and edit Qualifcation Details"
        /// <summary>
        /// Add and edit Qualification Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("SaveQualificationDetails/{id?}")]
        [HttpGet]
        public ViewResult SaveQualificationDetails(int id)
        {
            ViewBag.PassingYear = _qualificationRepository.GetPassingYearList();
            var model = _qualificationRepository.GetQualificationDetails(id);
            if (model == null)
                model = new Qualification();
            return View(model);
        }

        [Route("SaveQualificationDetails/{id?}")]
        [HttpPost]
        public IActionResult SaveQualificationDetails(Qualification qualification)
        {
            ViewBag.PassingYear = _qualificationRepository.GetPassingYearList();
            if (ModelState.IsValid) {
                _qualificationRepository.SaveQualificationDetails(qualification);
                return RedirectToAction("Index");
            } 
            return View();
        }
        #endregion

        #region "Delete"
        /// <summary>
        /// Delete Qualification by their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Delete/{id?}")]
        [HttpGet]
        public ViewResult Delete(int? id) => View(_qualificationRepository.GetQualificationDetails(id ?? 1));

        [Route("Delete/{id?}")]
        [HttpPost]
        public IActionResult Delete(int id) {
            _qualificationRepository.DeleteQualification(id);
           return  RedirectToAction("Index");
        }      
        #endregion
       
    }
}