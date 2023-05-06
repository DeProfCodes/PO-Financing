using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PO_Financing.BusinessLogic;
using PO_Financing.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PO_Financing.Controllers
{
    public class UploadsController : Controller
    {
        private readonly IUserDataManagement _usersIO;
        public UploadsController(IUserDataManagement usersIO)
        {
            _usersIO = usersIO;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            int index = 0;
            var userId = (await _usersIO.GetUserByEmail(User.Identity.Name)).Id;
            
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = FilesHelper.GetFileFullPath(formFile.FileName, index++, userId);
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return RedirectToAction("Index","Dashboard");
        }
    }
}
