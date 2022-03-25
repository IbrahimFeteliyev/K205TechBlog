using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]
    public class BlogController : Controller
    {

        private readonly IBlogManager _blogManager;
        private readonly ICategoryManager _categoryManager;

        public BlogController(IBlogManager blogManager, ICategoryManager categoryManager)
        {
            _blogManager = blogManager;
            _categoryManager = categoryManager;
        }

        // GET: BlogController
        public IActionResult Index()
        {
            var blogs = _blogManager.GetAll();
            return View(blogs);
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _categoryManager.GetAll(); 
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
