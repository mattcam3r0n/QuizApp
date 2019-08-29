<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    public class QuizzesController : Controller
    {

        private readonly IQuizService _quizService;

        // Done: create a constructor and inject quiz service
        public QuizzesController(IQuizService quizService)
        {
            this._quizService = quizService;
        }

        
      

        [HttpGet()]
        public IActionResult GetQuizzes(IQuizService quizService)
        {
            // Done: replace the following code with a complete implementation
            // that will return quizzes from the database.
            try
            {
                return (_quizService.GetAll());
            }
            catch (Exception)
            {
                ModelState.AddModelError("GetQuizzes", "Not Implemented!");
                return BadRequest(ModelState);
            }  
        }
        

        [HttpGet("{id}")]
        public IActionResult GetQuiz(int id)
        {
            // Done: replace the following code with a complete implementation
            // that will return a single quiz
            try
            {
                return (_quizService.Get(id));
            }
            catch (Exception)
            {
                ModelState.AddModelError("GetQuiz", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }
    }
}



