using System;
namespace QuizApp.Core.Models
{
    public class QuizQuestion
    {
        int QuizId { get; set; }
        Quiz Quiz { get; set; }
        int QuestionId { get; set; }
        Question Question { get; set; }
    }
}
