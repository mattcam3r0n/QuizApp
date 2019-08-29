using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp.ApiModels;
using QuizApp.Core.Models;
using QuizApp.Core.Services;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {

        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionservice)
        {
            _questionService = questionservice;
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
        public IActionResult Get(int id)
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
        public IActionResult Add(Question question)
        {
            try
            {
                return Ok(_questionService.Add(question));
            }
            catch (Exception)
            {
                ModelState.AddModelError("AddQuestion", "Not Implemented!");
                return NotFound(ModelState);
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Question question)
        {
            try
            {
                return Ok(_questionService.Update(question).ToApiModel());
            }
            catch (Exception)
            {
                ModelState.AddModelError("UpdateQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }

        
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            try
            {
                var Q = _questionService.Get(id);
                if (Q == null) return NotFound();
                _questionService.Remove(Q.Id);
                return NoContent();
            }
            catch (Exception)
            {
                ModelState.AddModelError("RemoveQuestion", "Not Implemented!");
                return BadRequest(ModelState);
            }
        }
    }
}
