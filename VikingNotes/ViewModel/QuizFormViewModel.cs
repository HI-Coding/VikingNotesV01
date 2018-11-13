using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using VikingNotes.Controllers;
using VikingNotes.Models;

namespace VikingNotes.Views.ViewModel
{
    public class QuizFormViewModel // step 10d : created ViewModel for presentation purpose
    {
        public int Rating = 5; // for rating in the Rating.html. referenced in the Creat.cshtml

        public int Id { get; set; }// step 37b: created Id to be used in Action property
        #region step 10
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public int Genre { get; set; } // step 10g: will be genre id when stored in the db

        public List<Genre> Genres { get; set; } // for the 2nd argument of the DropDownListFor in the Create.cshtml there is needed a source for it.
        
        // step 36b: creating Heading property to make the heading dynamic.
        public string Heading { get; set; }

        // step 37: implementing the Action.
        public string Action
        {
            get
            {
                // step: 39a: refactoring / return action name instead of hard coding update create
                Expression<Func<QuizsController, ActionResult>> update =
                                                  (c => c.Update(this) );

                Expression<Func<QuizsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create; // action variable is expression: depending on the value of the id, select one of the expressions and get the method name at run time
                var actionName = (action.Body as MethodCallExpression).Method.Name; // with the above expression extracting the method name at run time.

                return actionName;
                //return (Id != 0) ? "Update" : "Create"; // magic string !!
            }
        }

        #endregion step 10

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Creation}");
        }
    }
}