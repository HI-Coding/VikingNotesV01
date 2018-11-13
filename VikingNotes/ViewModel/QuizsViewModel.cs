using System.Collections.Generic;
using VikingNotes.Models;

namespace VikingNotes.ViewModel
{
    public class QuizsViewModel
    {
        public IEnumerable<Quiz> RecentQuizzes { get; set; }

        public bool ShowActions { get; set; }

        public string Heading { get; set; }
    }
}