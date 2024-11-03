using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using BlogApp.DataAccess.Repository.Interfaces;
using BloggingApp.Models;
using System.Security.Claims;
using BlogApp.Models.Models;
using BlogApp.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BloggingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Article> articles = this._unitOfWork.Article.GetAll(includeProperties: "ApplicationUser")
                .OrderByDescending(a => a.Date);

            return View(articles);
        }

        public IActionResult Article(int articleId)
        {
            Article article = this._unitOfWork.Article.Get(a => a.Id == articleId, includeProperties: "ApplicationUser");

            string? userId = this._userManager.GetUserId(User);

            this.ViewBag.UserId = article.ApplicationUserId;
            this.ViewBag.UserIsAuthor = userId == article.ApplicationUserId;

            return View(article);
        }

        [Authorize]
        public IActionResult Upsert(int? id)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            this.ViewBag.UserId = userId;

            if (id == null || id == 0)
            {
                return View(new Article());
            }

            Article article = this._unitOfWork.Article.Get(a => a.Id == id);

            return View(article);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Upsert(Article article)
        {
            if (ModelState.IsValid)
            {
                DateTime date = DateTime.Now;
                DateTime.SpecifyKind(date, DateTimeKind.Utc);
                article.Date = date;

                if (article.Id == 0)
                {
                    this._unitOfWork.Article.Add(article);
                    this.TempData["success"] = "Article created successfully!";
                }
                else
                {
                    this._unitOfWork.Article.Update(article);
                    this.TempData["success"] = "Article updated successfully!";
                }

                this._unitOfWork.Save();

                return RedirectToAction("Article", new { articleId = article.Id });
            }

            return View(article);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(int? id)
        {
            Article? article = this._unitOfWork.Article.Get(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            this._unitOfWork.Article.Remove(article);
            this._unitOfWork.Save();

            this.TempData["success"] = "Article deleted successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult ApplicationUser(string id)
        {
            ApplicationUserViewModel userVm = new ApplicationUserViewModel();
            userVm.ApplicationUser = this._unitOfWork.ApplicationUser.Get(x => x.Id == id);
            userVm.Articles = this._unitOfWork.Article.GetAll(x => x.ApplicationUser == userVm.ApplicationUser);

            return View(userVm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region API calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Article> articles = this._unitOfWork.Article.GetAll(includeProperties: "ApplicationUser").ToList();

            return Json(articles);
        }

        #endregion
    }
}
