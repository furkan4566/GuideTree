using Business.Abstarct;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        IArticleService _articleService;
        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_articleService.GetAll();
            if(result.Success)
            {
                return Ok(result);//status,durumu 200
            }
            return BadRequest(result);
            
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _articleService.GetById(productId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Article article)
        {
            var result = _articleService.Create(article);

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}