using System;
using System.Collections.Generic;

namespace QuizApp.Core.Models
{
    public class Quiz 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instuctions { get; set; }
        ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
    
}

