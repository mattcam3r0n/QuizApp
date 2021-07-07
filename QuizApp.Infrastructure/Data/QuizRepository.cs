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
            // inject and store AppDbContext
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
            var quiz = _dbContext.Quizzes
                .Include(x => x.QuizQuestions)
                .ThenInclude(x => x.Question)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == id);
            if (quiz != null)
            {
                return quiz;
            }
            return null;
        }

        public IEnumerable<Quiz> GetAll()
        {
            return _dbContext.Quizzes
                .Include(x => x.QuizQuestions)
                .ThenInclude(x => x.Question)
                .ThenInclude(x => x.Answers)
                .ToList();
        }

        public void Remove(Quiz entity)
        {
            Quiz quiz = _dbContext.Quizzes.Find(entity);
            if (quiz != null)
            {
                _dbContext.Remove(quiz);
                _dbContext.SaveChanges();
            }
        }

        public Quiz Update(Quiz entity)
        {
            Quiz existingItem = _dbContext.Quizzes.Find(entity);
            if (existingItem != null)
            {
                _dbContext.Entry(existingItem)
                    .CurrentValues
                    .SetValues(entity);
                _dbContext.Quizzes.Update(existingItem);
                _dbContext.SaveChanges();
                return existingItem;
            }
            return null;
        }
    }
}
