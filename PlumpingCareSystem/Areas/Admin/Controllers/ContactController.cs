﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Contact;
using PlumpingCareSystem.Service.Filters.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Areas.Admin.Controllers
{
	[Authorize(Policy = "AdminObserver")]
	[Area("Admin")]
		public class ContactController : Controller
		{
			private readonly IContactService _contactService;
			private readonly IValidator<ContactAddVM> _addValidator;
			private readonly IValidator<ContactUpdateVM> _updateValidator;

			public ContactController(IContactService contactService, IValidator<ContactAddVM> addValidatior, IValidator<ContactUpdateVM> updateValidator)
			{
				_contactService = contactService;
				_addValidator = addValidatior;
				_updateValidator = updateValidator;
			}
			public async Task<IActionResult> GetContactList()
			{
				var contactList = await _contactService.GetAllListAsync();
				return View(contactList);
			}

			[ServiceFilter(typeof(GenericAddPreventationFilter<Contact>))]
			[HttpGet]
			public IActionResult AddContact()
			{
				return View();
			}
			[HttpPost]
			public async Task<IActionResult> AddContact(ContactAddVM request)
			{
				var validation = await _addValidator.ValidateAsync(request);
				if (validation.IsValid)
				{
					await _contactService.AddContactAsync(request);
					return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
				}
				validation.AddToModelState(this.ModelState);
				return View();
			}

			[ServiceFilter(typeof(GenericNotFoundFilter<Contact>))]
			[HttpGet]
			public async Task<IActionResult> UpdateContact(int id)
			{
				var contact = await _contactService.GetContactById(id);
				return View(contact);
			}
			[HttpPost]
			public async Task<IActionResult> UpdateContact(ContactUpdateVM request)
			{
				var validation = await _updateValidator.ValidateAsync(request);
				if (validation.IsValid)
				{
					await _contactService.UpdateContactAsync(request);
					return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
				}
				validation.AddToModelState(this.ModelState);
				return View();
			}

			[Authorize(Roles = "SuperAdmin")]
			public async Task<IActionResult> DeleteContact(int id)
			{
				await _contactService.DeleteContactAsync(id);
				return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
			}
		}
	}
