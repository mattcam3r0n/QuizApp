using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuestionService : IQuestionService
    {
        // TODO: Inherit and implement the IQuestionService interface
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public Question Add(Question question)
        {
            return _questionRepository.Add(question);
        }
        public Question Get(int id)
        {
            return _questionRepository.Get(id);
        }
        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }
        public Question Update(Question updatedQuestion)
        {
            return _questionRepository.Update(updatedQuestion);
        }
        public void Remove(int id)
        {
            var question=_questionRepository.Get(id);
            _questionRepository.Remove(question);


        }



    }
}
