using System;
namespace QuizApp.ApiModels
{
    public class AnswerModel
    {
        // : create answer model props
        int Id { get; set; }
        int QuestionId { get; set; }
        string Content { get; set; }
        bool IsCorrect { get; set; }
    }
}
