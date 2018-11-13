using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VikingNotes.Models
{
    public class Quiz // step 1: Creating Models
    {
        public int Id { get; set; } // unique id

        // assoiciating the user with the AplicationUser class that represents the VikingNotes
        //[Required] // step 7b: Overriding convention
        public ApplicationUser Author { get; set; } // Who is performing it

        [Required] // step 14: moved from the Author to FK, making sure the FK is set to this, not Author.
        public string AuthorId { get; set; } // string as in the ApplicationUser, Identity, the ID property, which is key is defined as string.

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(Int32.MaxValue)]
        public string Description { get; set; } // Quiz Description text

        public DateTime Creation { get; set; } // when is it happening

        // [Required]
        public Genre Genre { get; set; } // what genre is it

        public IEnumerable Genres { get; set; }

        [Required] // step 14: moved from Genre to GenreId, setting FK to this.
        public int GenreId { get; set; }


        // step 40: deleting a quiz
        public bool Cancel  { get; set; }
    }
}




// Author and Genre are navigation properties, for it allowing us to navigate into different entities in the domain model.
// giving them a FK property each (AuthorID, GenreID), will address the issue of querying for Author and Genre in the QuizsController.cs for the 
// target action. This way setting their value without querying a complet application user object.