﻿using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;

namespace ProductApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly RepositoryContext _context;

        public CategoryController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        

        [HttpGet]
        public IActionResult UpdateOneCategory(int id)
        {
            var category = _context.Categories
                .Where(c => c.CategoryId.Equals(id))
                .FirstOrDefault();

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOneCategory(Category category)
        {
            if (category is null)
                throw new Exception();

            if(ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
