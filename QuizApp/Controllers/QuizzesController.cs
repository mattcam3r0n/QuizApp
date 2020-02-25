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

        [HttpGet]
        public IActionResult GetQuizzes()
        {
            try
            {
                var allQuizzes = _quizService
                                    .GetAll()
                                    .ToApiModels();

                if (allQuizzes == null) return NotFound();

                return Ok(allQuizzes);
            } catch
            {
                ModelState.AddModelError("GetQuiz", "Not Implemented!");
                return BadRequest(ModelState);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetQuiz(int id)
        {
            try
            {
                var quiz = _quizService.Get(id);

                if (quiz == null) return NotFound();

                return Ok(quiz.ToApiModel());
            }
            catch
            {
                ModelState.AddModelError("GetQuiz", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }

        // OPTIONAL - PUSH YOURSELF FURTHER
        // Implement a controller action that will return
        // a quiz containing five randomly selected questions.
    }
}