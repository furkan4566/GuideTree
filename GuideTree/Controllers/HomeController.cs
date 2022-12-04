using Business.Abstarct;
using Entities;
using GuideTree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GuideTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        public HomeController(ILogger<HomeController> logger, IArticleService articleService, ICategoryService categoryService)
        {
            _logger = logger;
            this._articleService = articleService;
            this._categoryService = categoryService;
        }

        public IActionResult Index(string category)
        {
            var articleViewModel = new ArticleListViewModel()
            {
                Articles = _articleService.GetArticleByCategory(category),
            };
            return View(articleViewModel);
        }
        public IActionResult ArticleDetails(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            //var article = _articleService.GetArticleDetails(url);
            var article = _articleService.GetArticleDetailDtos(url);
            return View(new ArticleDetailModel
            {
                ArticleDetail = article,
            });
        }
        public IActionResult Search(string q)
        {
            var result = _articleService.GetSearchResult(q);
            if (result.Success == true)
            {
                var articleViewModel = new ArticleListViewModel()
                {
                    Articles = result
                };
                return View(articleViewModel);
            }
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
