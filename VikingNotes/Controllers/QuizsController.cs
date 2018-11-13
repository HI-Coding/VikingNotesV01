using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.ApplicationInsights.Web;
using Microsoft.AspNet.Identity;
using VikingNotes.Models;
using VikingNotes.Views.ViewModel;

namespace VikingNotes.Controllers 
{
    public class QuizsController : Controller
    {
        // step 10h: retrieving list of genres from the database
        private ApplicationDbContext _context { get; set; }

        // initialize a constructor
        public QuizsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult MyQuiz() // step 33: creating new action
        {
            var userId = User.Identity.GetUserId();
            var quizs = _context.Guizzes
                .Where(m => m.AuthorId == userId && m.Creation > DateTime.Now)
                .Include(m =>m.Genre)
                .ToList();
            return View(quizs);
        }





        [Authorize] // step 11: prompting the user to be logged in
        public ActionResult Create() // step 9a: creating QuizsController
        {
            //step 10 I: create viewModel and set the genre
            var viewModel = new QuizFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Heading = "Add a Quiz"
            };
            return View("QuizForm", viewModel);

        }

       

 
        #region Create Quiz
        // step 13b: // httpPost to prompt this action being called only by a httpPost method
        // Implementing the Create action for the Target form in the Create.cshtml
        [Authorize, HttpPost]
        [ValidateAntiForgeryToken] // step 22b: 
        public ActionResult Create(QuizFormViewModel viewModel) // takes parameter of QuizFormViewModel -- the model behind the view. When posting the form will result this action
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("QuizForm", viewModel);
            }

            var userId = User.Identity.GetUserId();   // need to set the authorId, need an applicationUser object
            //var author = _context.Users.Single(u => u.Id == userId); // accessing when not using FK
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre); // accessing when not using FK

            // step 13c: creating new Quiz object and converting it to the viewModel object
            var quiz = new Quiz
            {
                // need to set the authorId, need an applicationUser object
                // Author = author,
                Creation = viewModel.GetDateTime(),
                //  Genre = genre,
                Title = viewModel.Title,
                Description = viewModel.Description,

                // step 14: Modified by adding the FK for Author and Genre. the above are uncommented.
                AuthorId = userId,
                GenreId = viewModel.Genre
            };

            // adding the object to the contex to be tracked by EF
            // Ef will generate a sql statment and execute it against the database.
            _context.Guizzes.Add(quiz);
            _context.SaveChanges();

            return RedirectToAction("QuizIndex", "Home"); // redirecting the user to the homepage --> later to the list of all the upcoming quizzes
        }
        #endregion


        #region Edit a Quiz
        // step 35b-c: 
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var quiz = _context.Guizzes.Single(m => m.Id == id && m.AuthorId == userId);
            var viewModel = new QuizFormViewModel
            {
                // initialize the genres dropdown list, quiz model's properties to be able to edit.
                // step 36c: adding Heading // in step 38b id initialized
                Heading = "Edit a Quiz",
                Id = quiz.Id,
                Genres = _context.Genres.ToList(),
                Creation = quiz.Creation,
                Genre = quiz.GenreId,
                Title = quiz.Title,
                Description = quiz.Description
            };
            return View("QuizForm", viewModel); // the vire "Create", already exist that renders to capture the view. reusing it.
        }
        #endregion

        #region Updaet a Quiz
        [Authorize, HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(QuizFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("QuizForm", viewModel);
            }

            var userId = User.Identity.GetUserId();

            // pulling out hte existing quiz and modifying it's property
            var quiz = _context.Guizzes.Single(m => m.Id == viewModel.Id && m.AuthorId == userId);

            // modifying / updating the quiz
            quiz.Title = viewModel.Title;
            quiz.Description = viewModel.Description;
            quiz.Creation = viewModel.Creation;
            quiz.GenreId = viewModel.Genre;

            _context.SaveChanges();

            return RedirectToAction("QuizIndex", "Home");
        }



        #endregion

    }
}