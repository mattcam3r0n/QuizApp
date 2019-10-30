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
        private readonly AppDbContext _dbContext;
        public QuizRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Quiz Add(Quiz entity)
        {
            _dbContext.Quizzes.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Quiz Get(int id)
        {
            return _dbContext.Quizzes
                .Include(a => a.QuizQuestions)
                .ThenInclude(a => a.Question)
                .ThenInclude(a => a.Answers)
                .FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Quiz> GetAll()
        {
            return _dbContext.Quizzes
                .Include(a => a.QuizQuestions)
                .ThenInclude(a => a.Question)
                .ThenInclude(c => c.Answers)
                .ToList();
        }

        public void Remove(Quiz entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Quiz Update(Quiz entity)
        {
            var existingQuiz = _dbContext.Quizzes.Find(entity.Id);
            if (existingQuiz == null) return null;
            _dbContext.Entry(existingQuiz).CurrentValues.SetValues(entity);
            _dbContext.Quizzes.Update(existingQuiz);
            _dbContext.SaveChanges();
            return existingQuiz;
        }
    }
}
