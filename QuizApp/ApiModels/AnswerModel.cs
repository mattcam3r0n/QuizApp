using QuizApp.Core.Models;
using System;
namespace QuizApp.ApiModels
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public string Question { get; set; }
    }
}
