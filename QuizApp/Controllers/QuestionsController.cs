using System;
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

        public QuestionsController(IQuestionService questionservice)
        {
            _questionService = quesitonService;
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult GetAll()
        {
            try
            {
                var allQuestions = _questionService
                    .GetAll()
                    .ToApiModels();
                return Ok(allQuestions);
            }
            catch (Exception)
            {
                ModelState.AddModelError("GetQuestions", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get()
        {
            try
            {
                var question = _questionService.Get(id);
                if (question == null) return NotFound();
                return Ok(question.ToApiModel());
            }
            catch (Exception)
            {
                ModelState.AddModelError("GetQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }

        
        [HttpPost]
        public IActionResult Add()
        {
            try
            {

            }
            catch (Exception)
            {
                ModelState.AddModelError("AddQuestion", "Not Implemented!");
                return NotFound(ModelState);
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuestionModel questionModel)
        {
            try
            {
                return Ok(_questionService.Update(updatedQuestion).ToApiModel());
            }
            catch (Exception)
            {
                ModelState.AddModelError("UpdateQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }

        
        [HttpDelete]
        public IActionResult Remove()
        {
            try
            {
                _questionService.Remove(question);
            }
            catch (Exception)
            {
                ModelState.AddModelError("RemoveQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }
    }
}
