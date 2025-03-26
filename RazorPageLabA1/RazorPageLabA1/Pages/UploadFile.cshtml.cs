using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace RazorPageLabA1.Pages
{
    public class UploadFileModel : PageModel
    {
        private readonly IWebHostEnvironment _environment; // Change to IWebHostEnvironment

        public UploadFileModel(IWebHostEnvironment environment) // Change to IWebHostEnvironment
        {
            _environment = environment;
        }

        [Required(ErrorMessage = "Please choose at least one file.")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }

        public async Task OnPostAsync()
        {
            if (FileUploads != null)
            {
                foreach (var FileUpload in FileUploads)
                {
                    var filePath = Path.Combine(_environment.ContentRootPath, "Images", FileUpload.FileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await FileUpload.CopyToAsync(fileStream);
                    }
                }
            }
        }
    }
}
