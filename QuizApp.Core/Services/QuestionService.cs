using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionService _questionService;

        public QuestionService(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public Question Add(Question newQuestion)
        {
            return _questionService.Add(newQuestion);
        }

        public Question Get(int id)
        {
            return _questionService.Get(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionService.GetAll();
        }

        public void Remove(int id)
        {
            _questionService.Remove(id);
        }

        public Question Update(Question updatedQuestion)
        {
            return _questionService.Update(updatedQuestion);
        }
    }
}
