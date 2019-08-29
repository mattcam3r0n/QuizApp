using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuestionRepository :IQuestionRepository
    {
        // TODO: inherit and implement the IQuestionRepository interface
        private readonly AppDbContext _DbContext;

        public QuestionRepository(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Question Add(Question question)
        {
            _DbContext.Questions.Add(question);
            _DbContext.SaveChanges();
            return question;
        }

        public Question Get(int id)
        {
            return _DbContext.Questions
                .SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _DbContext.Questions
                .ToList();
        }

        public Question Update(Question updatedQuestion)
        {
            var currentQuestion = _DbContext.Questions.Find(updatedQuestion.Id);

            // return null if todo to update isn't found
            if (currentQuestion == null) return null;

            _DbContext.Entry(currentQuestion)
                .CurrentValues
                .SetValues(updatedQuestion);

            // update the todo and save
            _DbContext.Questions.Update(currentQuestion);
            _DbContext.SaveChanges();
            return currentQuestion;
        }

        public void Remove(Question question)
        {
            _DbContext.Questions.Remove(question);
            _DbContext.SaveChanges();
        }

    }
}
