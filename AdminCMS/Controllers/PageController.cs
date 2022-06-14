using AdminCMS.Core.Models;
using AdminCMS.Core.Models.Domains;
using AdminCMS.Core.Service;
using AdminCMS.Core.ViewModels;
using AdminCMS.Persistence.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;

namespace AdminCMS.Controllers
{
    [Authorize]
    public class PageController : Controller
    {
        private IPageService _pageService;
        private ICategoryService _categoryService;
        private readonly INlogService _logger;

        public PageController(IPageService pageService, ICategoryService categoryService, INlogService logger)
        {
            _pageService = pageService;
            _categoryService = categoryService;
            _logger = logger;
        }


        public IActionResult Pages()
        {
            var userId = User.GetUserId();

            var pages = _pageService.Get(userId);
            var categories = _categoryService.GetCategories();

            var vm = new PagesViewModel
            {
                FilterPages = new FilterPages(),
                Pages = pages,
                Categories = categories
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Pages(PagesViewModel viewModel)
        {
            var userId = User.GetUserId();

            var pages = _pageService.Get(
                userId,
                viewModel.FilterPages.IsActive,
                viewModel.FilterPages.CategoryId,
                viewModel.FilterPages.Title);

            return PartialView("_PagesTable", pages);
        }


        public IActionResult Page(int id = 0)
        {
            var userId = User.GetUserId();

            var page = id == 0 ?
                new Page
                {
                    Id = 0,
                    UserId = userId,
                    CreatedDate = DateTime.Now,
                    CreatedUser = userId
                } : _pageService.Get(id, userId);

            var vm = new PageViewModel
            {
                Page = page,
                Heading = id == 0 ? "Add new subpage" : "Edit subpage",
                Categories = _categoryService.GetCategories()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Page(Page page)
        {
            var userId = User.GetUserId();
            page.UserId = userId;

            if (!ModelState.IsValid)
            {
                var vm = new PageViewModel
                {
                    Page = page,
                    Heading = page.Id == 0 ? "Add new subpage" : "Edit subpage",
                    Categories = _categoryService.GetCategories()
                };

                return View("Page", vm);

            }

            if (page.Id == 0)
                _pageService.Add(page);
            else
                _pageService.Update(page);

            return RedirectToAction("Pages");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _pageService.Delete(id, userId);
            }
            catch (Exception ex)
            {
                _logger.Error("Controller: Page, Method: Delete: " + ex.Message);
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Active(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _pageService.Active(id, userId);
            }
            catch (Exception ex)
            {
                _logger.Error("Controller: Page, Method: Active: " + ex.Message);
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Hide(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _pageService.Hide(id, userId);
            }
            catch (Exception ex)
            {
                _logger.Error("Controller: Page, Method: Hide: " + ex.Message);
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }

    }
}
