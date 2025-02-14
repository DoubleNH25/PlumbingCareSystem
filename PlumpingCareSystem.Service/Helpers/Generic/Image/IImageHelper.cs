using Microsoft.AspNetCore.Http;
using PlumpingCareSystem.Core.Enumerators;
using PlumpingCareSystem.Core.Models;

namespace PlumpingCareSystem.Service.Helpers.Generic.Image
{
	public interface IImageHelper
	{
		Task<ImageUploadModel> ImageUpload(IFormFile imageFile, ImageType imageType, string? folderName);
		string DeleteImage(string imageName);
	}
}