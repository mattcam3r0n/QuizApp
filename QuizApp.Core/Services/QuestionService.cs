using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public Question Add(Question newQuestion)
        {
            if(newQuestion.Answers.Count == 0)
            {
                throw new ApplicationException("A question must have an answer.");
            }
            else if(newQuestion.Answers.Count > 1)
            {
                throw new ApplicationException("A question can only have 1 answer.");
            }
            return _questionRepository.Add(newQuestion);
        }

        public Question Get(int id)
        {
            return _questionRepository.Get(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }

        public void Remove(int id)
        {
            var removedQuestion = _questionRepository.Get(id);
            _questionRepository.Remove(removedQuestion);
        }

        public Question Update(Question updatedQuestion)
        {
            if (updatedQuestion.Answers.Count == 0)
            {
                throw new ApplicationException("A question must have an answer.");
            }
            else if (updatedQuestion.Answers.Count > 1)
            {
                throw new ApplicationException("A question can only have 1 answer.");
            }
            return _questionRepository.Update(updatedQuestion);
        }
    }
}
