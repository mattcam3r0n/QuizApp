using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuestionService : IQuestionService
    {
        // TODO: Inherit and implement the IQuestionService interface
        private IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        Question IQuestionService.Add(Question newQuestion)
        {
            _questionRepository.Add(newQuestion);
            return newQuestion;
        }

        Question IQuestionService.Get(int id)
        {
            var question = _questionRepository.Get(id);
            return question;
        }

        IEnumerable<Question> IQuestionService.GetAll()
        {
            return _questionRepository.GetAll();
        }

        void IQuestionService.Remove(int id)
        {
            var question = _questionRepository.Get(id);
            _questionRepository.Remove(question);
        }

        Question IQuestionService.Update(Question updatedQuestion)
        {
            var question = _questionRepository.Update(updatedQuestion);
            return question;
        }
    }
}
