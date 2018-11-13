using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace VikingNotes.Models
{
    public class Attendance
    {
        public Quiz Quiz { get; set; }

        public ApplicationUser Attendee { get; set; }

        [Key]
        [Column(Order = 1)]
        public int QuizId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }




    }
}