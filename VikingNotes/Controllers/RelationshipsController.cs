using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using VikingNotes.Models;
using System.Linq;
using Microsoft.ApplicationInsights.DependencyCollector;
using VikingNotes.Dtos;

namespace VikingNotes.Controllers
{
    [Authorize]
    public class RelationshipsController : ApiController
    {
        private ApplicationDbContext _context;

        public RelationshipsController()
        {
            _context = new ApplicationDbContext();
        }
        

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Relationships.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("Already following!");
            }

            var following = new Relationship()
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Relationships.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
