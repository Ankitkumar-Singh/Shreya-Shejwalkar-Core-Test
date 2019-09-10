using Microsoft.AspNetCore.Mvc;

namespace CandidateQualifications.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}