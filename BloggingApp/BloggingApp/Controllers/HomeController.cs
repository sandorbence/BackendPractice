using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using BlogApp.DataAccess.Repository.Interfaces;
using BloggingApp.Models;
using BlogApp.Models;

namespace BloggingApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfWork _unitOfWork;

		public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
		{
			this._logger = logger;
			this._unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			IEnumerable<Article> articles = this._unitOfWork.Article.GetAll();

			return View(articles);
		}

		public IActionResult Article(int articleId)
		{
			Article article = this._unitOfWork.Article.Get(a => a.Id == articleId);

			return View(article);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
