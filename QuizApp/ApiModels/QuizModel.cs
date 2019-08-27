﻿using System;
using System.Collections.Generic;

namespace QuizApp.ApiModels
{
    
    public class QuizModel
    {
      public int Id { get; set; }
     public string Title { get; set; }
    public string Description { get; set; }
    public string Instructions { get; set; }
    public IEnumerable<QuestionModel> Questions { get; set; }
        public QuizModel(int Id, string Title, string Description, string Instructions, IEnumerable<QuestionModel>Questions)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Instructions = Instructions;
            this.Questions = Questions;
        }
}
}
