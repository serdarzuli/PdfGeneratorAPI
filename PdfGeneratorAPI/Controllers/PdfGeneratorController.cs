using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;


namespace PdfGeneratorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfGeneratorController : ControllerBase
    {
        private readonly IPdfGeneratorService _pdfGeneratorService;
        public PdfGeneratorController(IPdfGeneratorService pdfGeneratorService)
        {
            _pdfGeneratorService = pdfGeneratorService;
        }

        [HttpPost("generate-file")]
        public async Task<IActionResult> GeneratePdfFromUrl(IFormFile fileUrl)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                await fileUrl.CopyToAsync(stream);
                stream.Position = 0;
                string DocumentUri = await _pdfGeneratorService.GeneratePdfFromMemoryStream(stream);
                return Ok(DocumentUri);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
