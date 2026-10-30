using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Day3_NguyenMinhHai.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Models.Category> _categories = new List<Models.Category>()
        {
            new Models.Category() { Id = 1, Name = "Category 1" },
            new Models.Category() { Id = 2, Name = "Category 2" },
            new Models.Category() { Id = 3, Name = "Category 3" }
        };
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_categories);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categories.FirstOrDefault(category => category.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError(nameof(category.Name), "Name is required.");
                return View(category);
            }

            category.Id = _categories.Max(category => category.Id) + 1;
            _categories.Add(category);

            return RedirectToAction(nameof(Index));
        }
        // GET: Category/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categories.FirstOrDefault(category => category.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Models.Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                ModelState.AddModelError(nameof(category.Name), "Name is required.");
                return View(category);
            }

            var existingCategory = _categories.FirstOrDefault(item => item.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}