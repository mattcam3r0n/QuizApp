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

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet()]
        public IActionResult Quizzes()
        {
            ModelState.AddModelError("GetQuizzes", "Not Implemented!");
            return ValidationProblem(ModelState);
            //var quizzes = _quizService.GetAll().ToList();
            //return quizzes.ToApiModels();
        }

        [HttpGet("{id}")]
        public IActionResult Quizzes(int id)
        {
            ModelState.AddModelError("GetQuiz", "Not Implemented!");
            return ValidationProblem(ModelState);
            //var quiz = _quizService.Get(id);
            //return quiz.ToApiModel();
        }

    }
}
