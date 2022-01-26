using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamSpoatsPR.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StreamSpoatsPR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        [Route("save-file-to-physicallocation")]
        public async Task<ImageResult> SaveToPhysicalLocation([FromBody] SaveFile saveFile)
        {
            try
            {
                foreach (var file in saveFile.Files)
                {
                    string fileExtenstion = file.FileType.ToLower().Contains("png") ? "png" : "jpg";
                   // string fileName = $@"C:\Users\Faraz\source\repos\StreamSpoatsPR\Client\wwwroot\Data\{Guid.NewGuid()}.{fileExtenstion}";
                    
                    var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data");
                    string dbFileName= $@"{Guid.NewGuid()}.{fileExtenstion}";
                    string fileName = $@"{directoryPath}\{dbFileName}";
                    fileName = fileName.Replace("Server", "Client");
                    var fullPath = Path.Combine(directoryPath, fileName);




                    //using (var fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                    //{
                    //    // Copy the content to the new stream
                    //    await file.CopyToAsync(fileStream);
                    //}


                    using (var fileStream = System.IO.File.Create(fileName))
                    {
                        await fileStream.WriteAsync(file.Data);
                    }
                    ImageResult imageResult = new ImageResult();
                    imageResult.name = dbFileName;
                    return imageResult;
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
