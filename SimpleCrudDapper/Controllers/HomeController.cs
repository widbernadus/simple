using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCrudDapper.DAO;
using SimpleCrudDapper.Models;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace SimpleCrudDapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeDAO HomeDAO;

        public HomeController(ILogger<HomeController> logger)
        {
            HomeDAO = new HomeDAO();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetBookData()
        {
            List<object> list = HomeDAO.GetAllData();
            return Json(new ResponseModel
            {
                data = list,
                response = "Ok",
                description = "Data is loaded"
            });
        } 

        public IActionResult AddForm() 
        {
            List<SelectListItem> genres = HomeDAO.GetAllGenres();
            ViewBag.Genres = genres;
            return View();
        }

        [ValidateAntiForgeryToken]
        public IActionResult Create(BookViewModel book) {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            DbResponse insert = HomeDAO.InsertBook(book);
            if (insert.response == "Ok")
            {
                TempData["success_message"] = "Data is successfully created";
            }
            else
            {
                TempData["error_message"] = "Data is failed to create";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            BookViewModel book = HomeDAO.GetDataById(id);
            
            List<SelectListItem> genres = HomeDAO.GetAllGenres();
            genres.Where(x => x.Value == book.id.ToString()).First().Selected = true;
            
            ViewBag.Genre = genres;
            return View(book);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Update(BookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            DbResponse update = HomeDAO.UpdateBook(book);
            if (update.response == "Ok")
            {
                TempData["success_message"] = "Update successfully";
            }
            else
            {
                TempData["error_message"] = "Failed to update";
            }
            return Redirect("/Home/Edit/" + book.id);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            DbResponse delete = HomeDAO.DeleteBook(id);

            return Ok(new ResponseModel
            {
                response = "Oke",
                description = "Successfully deleting data"
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}