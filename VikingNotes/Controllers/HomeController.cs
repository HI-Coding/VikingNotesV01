using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VikingNotes.Models;
using System.Data.Entity;
using VikingNotes.ViewModel;

namespace VikingNotes.Controllers
{
    public class HomeController : Controller
    {
        // step 29a: retrieving from database all the coming quizes
        private ApplicationDbContext _contex;

        // steop 29b: creating the contstructor
        public HomeController()
        {
            _contex = new ApplicationDbContext();
        }


        public ActionResult QuizsIndex()
        {
            // steop 29c: creating the model and returning it
            // include takes a string parameter. This would be the Author's name.
            // filter according to the creation dateTime
            var RecentQuizzes = _contex.Guizzes
                .Include(m => m.Author)
                .Include(g=> g.Genre)
                .Where(m => m.Creation > DateTime.Now);

            var viewModel = new QuizsViewModel
            {
                RecentQuizzes = RecentQuizzes,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Recent Quizzes"
            };

            return View("Quizs", viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}