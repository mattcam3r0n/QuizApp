using System;
namespace QuizApp.ApiModels
{
    public class AnswerModel
    {
        public int Id {get; set; }
        public string Content {get; set;}
        public bool IsCorrect {get; set;}
        public int QuestionId {get; set;}
        public Question Question {get; set;}
        // TODO: create answer model props
    }
}
