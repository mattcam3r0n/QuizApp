using System;
using System.Collections.Generic;

namespace QuizApp.Core.Models
{

    public class Question 
    {
        int Id { get; set; }
        string QuestionType { get; set; }
        string Prompt { get; set; }
        ICollection<Answer> Answers { get; set; }
        ICollection<QuizQuestion> QuizQuestions { get; set; }


    }
}
    