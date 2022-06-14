using AdminCMS.Core.Models;
using AdminCMS.Core.Models.Domains;
using AdminCMS.Core.Service;
using AdminCMS.Core.ViewModels;
using AdminCMS.Persistence;
using AdminCMS.Persistence.Extensions;
using AdminCMS.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCMS.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Categories()
        {
            var categories = _categoryService.GetCategories();

            var vm = new CategoriesViewModel
            {
                Heading = "Categories list",
                FilterCategories = new FilterCategories(),
                Categories = categories
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Categories(CategoriesViewModel viewModel)
        {
            var userId = User.GetUserId();

            var categories = _categoryService.Get(userId,
                viewModel.FilterCategories.Title);

            return PartialView("_CategoriesTable", categories);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _categoryService.Delete(id, userId);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }

        public IActionResult Category(int id = 0)
        {
            var userId = User.GetUserId();

            var category = id == 0 ?
                new Category
                {
                    Id = 0,
                    UserId = userId,
                    CreatedDate = DateTime.Now,
                    CreatedUser = userId

                } : _categoryService.Get(id, userId);

            var categories = _categoryService.GetCategories();

            var vm = new CategoryViewModel
            {
                Category = category,
                Heading = id == 0 ? "Add new Category" : "Edit category",
                Categories = categories
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Category(Category category)
        {
            var userId = User.GetUserId();
            category.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = new CategoryViewModel
                {
                    Category = category,
                    Heading = category.Id == 0 ? "Add new Category" : "Edit category"
                };
                return View("Category", vm);
            }

            if (category.Id == 0)
                _categoryService.Add(category);
            else
                _categoryService.Update(category);

            return RedirectToAction("Categories");

        }

    }
}
