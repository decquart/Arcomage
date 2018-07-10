using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : Controller
    {
        private readonly IScoreService _scoreService;

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                var scores = _scoreService.GetTotalAverageScore();
                return Ok(scores);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("create")]
        public  IActionResult Create([FromBody] ScoreModel scoreModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _scoreService.AddScore(scoreModel.UserId, scoreModel.GameId, scoreModel.Value);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }           
        }
    }
} 