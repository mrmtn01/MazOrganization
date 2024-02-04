using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.ViewModels.Dashboard
{
	public class UploadViewModel
	{

		[Required(ErrorMessage = "لطفا عنوان فایل را وارد کنید")]
		[Display(Name = "عنوان فایل")]
		public string FileTittle { get; set; }

		[Required(ErrorMessage = "لطفا فایل را انتخاب کنید")]
		public IFormFile formFile { get; set; }
	}
}
