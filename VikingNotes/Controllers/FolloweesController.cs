using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VikingNotes.Models;

namespace VikingNotes.Controllers
{
    public class FolloweesController : Controller
    {
        private ApplicationDbContext _context;

        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var authors = _context.Relationships
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            return View(authors);
        }
    }
}