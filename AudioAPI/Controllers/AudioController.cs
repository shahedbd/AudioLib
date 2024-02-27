using Microsoft.AspNetCore.Mvc;

namespace AudioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : Controller
    {
        private readonly string _audioFolderPath;
        public AudioController()
        {
            _audioFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "audio");
        }
        [HttpGet("{fileName}")]
        public IActionResult GetAudio(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_audioFolderPath, fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }

                var _FileStream = new FileStream(filePath, FileMode.Open);
                return File(_FileStream, "audio/mpeg");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
                throw;
            }
        }
    }
}
