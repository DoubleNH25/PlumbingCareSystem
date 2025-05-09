﻿using PlumpingCareSystem.Entity.WebApplication.ViewModels.Service;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract
{
	public interface IServiceService
	{
		Task<List<ServiceListVM>> GetAllListAsync();
		Task AddServiceAsync(ServiceAddVM request);
		Task DeleteServiceAsync(int id);
		Task<ServiceUpdateVM> GetServiceById(int id);
		Task UpdateServiceAsync(ServiceUpdateVM request);
		Task<List<ServiceListForUI>> GetAllListForUIAsync();
	}
}
