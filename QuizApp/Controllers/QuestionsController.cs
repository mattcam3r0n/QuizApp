using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {

        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        [AllowAnonymous]
        [HttpGet()]
        public IActionResult GetAll()
        {
            // TODO: replace the following code with a complete implementation
            // that will return all questions
            ModelState.AddModelError("GetQuestions", "Not Implemented!");
            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // TODO: replace the following code with a complete implementation
            // that will return a single question based on id
            try
            {
                var quiz = _questionService.Get(id);

                if (quiz == null) return NotFound();

                return Ok(quiz.ToApiModel());

            } catch
            {
                ModelState.AddModelError("GetQuestion", "Not Implemented!");
                            return BadRequest(ModelState);
            }
            
        }

        // TODO: only authenticated users can call this action
        [HttpPost]
        public IActionResult Add()
        {
            // TODO: replace the following code with a complete implementation
            // that will add a new question 
            ModelState.AddModelError("AddQuestion", "Not Implemented!");
            return NotFound(ModelState);
        }

        // TODO: only authenticated users can call this action
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuestionModel questionModel)
        {
            // TODO: replace the following code with a complete implementation
            // that will update a question
            try
            {
                return Ok(_questionService.Update(questionModel).ToApiModel());

            } catch
            {
                ModelState.AddModelError("UpdateQuestion", "Not Implemented!");
                            return BadRequest(ModelState);
            }
            
        }

        // TODO: only authenticated users can call this action
        [HttpDelete]
        public IActionResult Remove()
        {
            // TODO: replace the following code with a complete implementation
            // that will delete a question
            ModelState.AddModelError("RemoveQuestion", "Not Implemented!");
            return BadRequest(ModelState);
        }
    }
}
