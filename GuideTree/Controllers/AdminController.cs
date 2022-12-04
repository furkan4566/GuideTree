using Business.Abstarct;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using Entities;
using GuideTree.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GuideTree.Controllers
{
    public class AdminController : Controller
    {
        private IArticleService _articleService;
        private ICategoryService _categoryService;
        private IContactDal _contactRepository;
        public AdminController(IArticleService articleService, ICategoryService categoryService, IContactDal contactRepository)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _contactRepository = contactRepository;
        }
        public IActionResult ArticleList()
        {
            return View(new ArticleListViewModel()
            {
                Articles = _articleService.GetAll(),

            });
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll(),
            });
        }
        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateArticle(ArticleModel model)
        {
            if (ModelState.IsValid)
            {
                var article = new Article()
                {
                    Title = model.Title,
                    Url = model.Url,
                    Description = model.Description,
                    IsHome = model.IsHome,
                };
                _articleService.Create(article);
                return RedirectToAction("ArticleList");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = model.Name,
                    Url = model.Url,
                };
                _categoryService.Create(category);
                return RedirectToAction("CategoryList");
            }
            return View(model);
        }
        [HttpGet]//data almayı saglar
        public IActionResult ArticleEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _articleService.GetbyIdWithCategories((int)id);
            if (entity == null)
            {
                return NotFound();
            }

            var model = new ArticleModel()
            {
                ArticleId = entity.Data.ArticleId,
                Title = entity.Data.Title,
                Url = entity.Data.Url,
                Description = entity.Data.Description,
                IsHome = entity.Data.IsHome,
                ImageUrl = entity.Data.ImageUrl,
                //SelectedCategories = entity.ArticleCategories.Select(i => i.Category).ToList(),
                Categories = _categoryService.GetAll(),
            };


            return View(model);
        }
        [HttpPost]//data vermeyi saglar
        public async Task<IActionResult> ArticleEdit(ArticleModel model, int[] categoryIds, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = _articleService.GetById(model.ArticleId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Data.Title = model.Title;
                entity.Data.Url = model.Url;
                entity.Data.Description = model.Description;
                entity.Data.IsHome = model.IsHome;
                if (file != null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.Data.ImageUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                //var msg = new AlertMessage()
                //{
                //    Message = $"{model.Title} Makale Güncellendi",
                //    AlertType = "success"
                //};
                //TempData["message"] = JsonConvert.SerializeObject(msg);
                   //_articleService.Update(entity, categoryIds);
                    return RedirectToAction("ArticleList");

            }
            model.Categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpGet]//data almayı saglar
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _categoryService.GetByWithArticle((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Url = entity.Url,
                Articles = entity.ArticleCategories.Select(i => i.Article).ToList(),//getbywitharticle metodu burdan bagımsız oldugundan böyle ulaşım oluyor
            };
            return View(model);
        }
        [HttpPost]//data vermeyi saglar
        public IActionResult CategoryEdit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _categoryService.GetById(model.CategoryId);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.Url = model.Url;

                _categoryService.Update(entity);
                var msg = new AlertMessage()
                {
                    Message = $"{model.Name} Makale Güncellendi",
                    AlertType = "success"
                };
                TempData["message"] = JsonConvert.SerializeObject(msg);
                return RedirectToAction("CategoryList");
            }
            return View(model);
        }
        public IActionResult DeleteArticle(int articleId)//deletearticle sayfası yok,deletearticle fonksiyon şeklinde kullanılır
        {
            var entity = _articleService.GetById(articleId);
            if (entity != null)
            {
                //_articleService.Delete(entity);
            }

            var msg = new AlertMessage()
            {
                Message = $"{entity.Data.Title} Makale Silindi",
                AlertType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("ArticleList");
        }
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            var msg = new AlertMessage()
            {
                Message = $"{entity.Name} Makale Silindi",
                AlertType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);
            return RedirectToAction("CategoryList");
        }
        public IActionResult DeleteFromCategory(int articleId, int categoryId)
        {
            _categoryService.DeleteFromCategory(articleId, categoryId);

            var msg = new AlertMessage()
            {
                Message = $"{categoryId} Makale Silindi",
                AlertType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);

            return RedirectToAction("CategoryList");
        }

        public IActionResult ContactList()
        {

            return View(new ContactListViewModel()
            {
                Contact = _contactRepository.GetAll(),
            });
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact()
                {
                    ContactId = model.ContactId,
                    Subject = model.Subject,
                    Description = model.Description,
                    Email = model.Email,
                    FirstLastName = model.FirstLastName,
                };
                _contactRepository.Create(contact);
            }
            return RedirectToAction("ContactList");
        }
        private void CreateMessage(string message, string alerttype)
        {
            var msg = new AlertMessage()
            {
                Message = message,
                AlertType = alerttype
            };
            TempData["message"] = JsonConvert.SerializeObject(msg);

        }
    }
}
