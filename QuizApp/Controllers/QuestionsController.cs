using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {

        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        // TODO: anonymous users can still call this action
        [AllowAnonymous]
        [HttpGet()]
        public IActionResult GetAll()
        {
            // TODO: replace the following code with a complete implementation
            // that will return all questions
            try 
            {
                return Ok(_questionService.GetAll());
            }
            catch
            {
                ModelState.AddModelError("GetQuestions", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }

        // TODO: anonymous users can still call this action
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get()
        {
            // TODO: replace the following code with a complete implementation
            // that will return a single question based on id
            try 
            {
                var question = _questionService.Get(id);
                if (question == null) return NotFound();
                return Ok (question);
            }
            catch
            {
                ModelState.AddModelError("GetQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }

        // TODO: only authenticated users can call this action
        [Authorize]
        [HttpPost]
        public IActionResult Add([FromBody] QuestionModel question) 
        {
            // TODO: replace the following code with a complete implementation
            // that will add a new question 
            try 
            {
                return Ok(_questionService.Add(question.ToDomainModel()));
            }
            catch
            {
                ModelState.AddModelError("AddQuestion", "Not Implemented!");
                return NotFound(ModelState);
            }
        }

        // TODO: only authenticated users can call this action
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuestionModel questionModel)
        {
            // TODO: replace the following code with a complete implementation
            // that will update a question
            try
            {
                return Ok(_questionService.Update(questionModel.ToDomainModel()));
            }
            catch
            {
                ModelState.AddModelError("UpdateQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }

        // TODO: only authenticated users can call this action
        [Authorize]
        [HttpDelete]
        public IActionResult Remove()
        {
            // TODO: replace the following code with a complete implementation
            // that will delete a question
            try
            {
                _questionService.Remove(id);
                    return NoContent();
            }
            catch
            {
                ModelState.AddModelError("RemoveQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }
    }
}
