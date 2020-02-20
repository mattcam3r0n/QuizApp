using System;
using System.Collections.Generic;
using QuizApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuizRepository  : IQuizRepository
    {
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
                .Include(qq => qq.QuizQuestions)
                .ThenInclude(a => a.Answers)
                .ThenInclude(q => q.Questions)
                .ToList();
        }

        public IEnumerable<Quiz> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Quiz entity)
        {
            throw new NotImplementedException();
        }

        public Quiz Update(Quiz entity)
        {
            throw new NotImplementedException();
        }
    }
}
