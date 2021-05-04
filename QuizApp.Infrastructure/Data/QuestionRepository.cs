using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Infrastructure.Data
{
    public class QuestionRepository : IQuestionRepository
    {
        private AppDbContext _dbContext;
        
        public QuestionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Question Add(Question entity)
        {
            _dbContext.Questions.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public Question Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question Update(Question entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Question entity)
        {
            throw new NotImplementedException();
        }
    }
}
