using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Core.Models
{
    public class Quiz 
    {
        [Key]
        public int Id { get; set; }
        
        [Required][MaxLength(200)]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Instructions { get; set; }
        
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
