using ArabCoders.SecondLayerOfModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArabCoders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpludeFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpludeFileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<FormatData> post([FromForm] ImageSecondLayer obj)
        {
            FormatData json = new FormatData();
            try
            {
                if (obj.file.Length > 0)
                {
                    

                    var FillFilePath = _webHostEnvironment.WebRootPath + "\\images\\";
                    if (!Directory.Exists(FillFilePath))
                    {
                        Directory.CreateDirectory(FillFilePath);
                    }

                    using (var stream = new FileStream(FillFilePath + Path.GetFileName(obj.file.FileName), FileMode.Create))
                    {
                        await obj.file.CopyToAsync(stream);
                        json.data = new { massage = " The request was successful ", data = $"/images/{Path.GetFileName(obj.file.FileName)}" };
                        return json;
                    }
                }
               
            }
            catch (Exception ex)
            {
                json.data = new { massage = ex.Message };
                return json;
            }

            json.data = new { massage = " The request fail" };
            return json;
        }

    }
}
