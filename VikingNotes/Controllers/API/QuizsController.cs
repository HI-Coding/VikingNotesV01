using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using VikingNotes.Models;

namespace VikingNotes.Controllers.API
{
    // step 41c:
    [Authorize]
    public class QuizsController : ApiController
    {
        private ApplicationDbContext _context; // getting the context from the database

        public QuizsController() // initializing the constructor
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();

            var quiz = _context.Guizzes.Single(m => m.Id == id && m.AuthorId == userId); // getting the quiz related to only the creator user.
            quiz.Cancel = true; // call cancel
            _context.SaveChanges(); // save to the database

            return Ok();
        }
    }
}
