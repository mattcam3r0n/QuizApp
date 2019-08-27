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
            _DbContext.Question.Add(question);
            _DbContext.SaveChanges();
            return question;
        }

        public Question Get(int id)
        {
            return _DbContext.Question
                .SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _DbContext.Question
                .ToList();
        }

        public Question Update(Question question)
        {
            var currentQuestion = _DbContext.Question.Find(updatedQuestion.Id);

            // return null if todo to update isn't found
            if (currentQuestion == null) return null;

            _DbContext.Entry(currentQuestion)
                .CurrentValues
                .SetValues(updatedQuestion);

            // update the todo and save
            _DbContext.Question.Update(currentQuestion);
            _DbContext.SaveChanges();
            return currentQuestion;
        }

        public void Remove(Question question)
        {
            _DbContext.Question.Remove(question);
            _DbContext.SaveChanges();
        }

    }
}
