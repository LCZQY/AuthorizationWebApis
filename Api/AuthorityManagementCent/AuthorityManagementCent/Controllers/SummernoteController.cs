using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Controllers
{

    /// <summary>
    /// 文件上传案例
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SummernoteController : Controller
    {

        public IHostingEnvironment hostingEnvironment { get; }
        public SummernoteController(IHostingEnvironment env)
        {
            this.hostingEnvironment = env;
        }


        /// <summary>
        /// Ajax的方式上传文件
        /// </summary>
        /// <param name="z"></param>
        /// <returns></returns>
        [HttpPost("UploadFilesAjax")]
        public async Task<IActionResult> UploadFilesAjax(string z)
        {
            long size = 0;
            var files = Request.Form.Files;
            string webRootPath = hostingEnvironment.WebRootPath;
            string contentRootPath = hostingEnvironment.ContentRootPath;
            string filename = "";
            foreach (var file in files)
            {
                filename = ContentDispositionHeaderValue
                               .Parse(file.ContentDisposition)
                               .FileName
                               .Trim('"');
                filename = webRootPath + "/upload/" + filename;
                if (System.IO.File.Exists(filename))
                {
                    // 如果该图片存在则不创建
                    continue;
                }
                size += file.Length;
                using (var stream = new FileStream(filename, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Json(filename);
        }




    }
}