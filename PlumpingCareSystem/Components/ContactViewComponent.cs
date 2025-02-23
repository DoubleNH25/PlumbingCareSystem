using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Components
{
	public class ContactViewComponent : ViewComponent
	{
		private readonly IContactService _contactService;

		public ContactViewComponent(IContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var contactList = await _contactService.GetAllListForUIAsync();
			return View(contactList);
		}
	}
}