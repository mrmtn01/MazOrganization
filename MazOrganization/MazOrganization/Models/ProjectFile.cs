using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MazOrganization.Models
{
    public class ProjectFile
    {
        [Key]
        public int FileId { get; set; }

        [Required]
        [Display(Name = "پروژه")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "لطفا عنوان فایل را وارد کنید")]
        [Display(Name = "عنوان فایل")]
        public string FileTittle { get; set; }

		[Required]
		public string typeFile { get; set; }

		public ICollection<Project> projects { get; set; }
    }
}
