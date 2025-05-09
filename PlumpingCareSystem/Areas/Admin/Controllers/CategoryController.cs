﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Category;
using PlumpingCareSystem.Service.Filters.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Areas.Admin.Controllers
{
	[Authorize(Policy = "AdminObserver")]
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IValidator<CategoryAddVM> _addValidator;
		private readonly IValidator<CategoryUpdateVM> _updateValidator;
		public CategoryController(ICategoryService categoryService, IValidator<CategoryAddVM> addValidator, IValidator<CategoryUpdateVM> updateValidator)
		{
			_categoryService = categoryService;
			_addValidator = addValidator;
			_updateValidator = updateValidator;
		}
		public async Task<IActionResult> GetCategoryList()
		{
			var categoryList = await _categoryService.GetAllListAsync();
			return View(categoryList);
		}
		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddCategory(CategoryAddVM request)
		{
			var validation = await _addValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _categoryService.AddCategoryAsync(request);
				return RedirectToAction("GetCategoryList", "Category", new { Area = ("Admin") });
			}
			validation.AddToModelState(this.ModelState);
			return View();
		}

		[ServiceFilter(typeof(GenericNotFoundFilter<Category>))]
		[HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var category = await _categoryService.GetCategoryById(id);
			return View(category);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(CategoryUpdateVM request)
		{
			var validation = await _updateValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _categoryService.UpdateCategoryAsync(request);
				return RedirectToAction("GetCategoryList", "Category", new { Area = ("Admin") });
			}
			validation.AddToModelState(this.ModelState);
			return View();
		}

		[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return RedirectToAction("GetCategoryList", "Category", new { Area = ("Admin") });
		}
	}
}