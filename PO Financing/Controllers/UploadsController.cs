using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PO_Financing.Controllers
{
    public class UploadsController : Controller
    {
        private string GetFilePath(int index, string filePath)
        {
            switch (index)
            {
                case 0: return $"Uploads\\Business Registrations\\{filePath}";
                case 1: return $"Uploads\\ID Documents\\{filePath}";
                case 2: return $"Uploads\\Purchase Orders\\{filePath}";
                case 3: return $"Uploads\\Quotations\\{filePath}";
                default: return string.Empty;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            int i = 0;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = $"{Directory.GetCurrentDirectory()}\\{GetFilePath(i++, $"helloWord.pdf")}";
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size });
        }
    }
}
