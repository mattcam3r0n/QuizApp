using System;
namespace QuizApp.ApiModels
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        string Content { get; set; }
        bool IsCorrect { get; set; }
    }
}
