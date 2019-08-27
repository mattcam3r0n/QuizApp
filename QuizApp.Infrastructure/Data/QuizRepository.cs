using System;
using System.Collections.Generic;
using QuizApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuizRepository : IQuizRepository
    {
        // TODO: inherit and implement the IQuizRepository interface
        private readonly AppDbContext _DbContext;
        public QuizRepository(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }



        public Quiz Add(Quiz quiz)
        {
            _DbContext.Quiz.Add(quiz);
            _DbContext.SaveChanges();
            return quiz;
        }

        public Quiz Get(int id)
        {
            return _DbContext.Quiz
               .SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<Quiz> GetAll()
        {
            return _DbContext.Quiz
                .ToList();
        }

        public void Remove(Quiz quiz)
        {
            _DbContext.Quiz.Remove(quiz);
            _DbContext.SaveChanges();
        }

        public Quiz Update(Quiz updatedQuiz)
        {
            var currentQuiz = _DbContext.Quiz.Find(updatedQuiz.Id);

            // return null if todo to update isn't found
            if (currentQuiz == null) return null;


            _DbContext.Entry(currentQuiz)
                .CurrentValues
                .SetValues(updatedQuiz);

            // update the todo and save
            _DbContext.Quiz.Update(currentQuiz);
            _DbContext.SaveChanges();
            return currentQuiz;
        }
    }
}
