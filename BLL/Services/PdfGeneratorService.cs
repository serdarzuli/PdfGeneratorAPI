using PdfGeneratorAPI.Repository.Interfaces;
using Repository.Interfaces;
using Spire.Doc;

namespace BLL.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        private readonly IBlobService _blobService;
        public PdfGeneratorService(IBlobService blobService)
        {
            _blobService = blobService;
        }
        public async Task<string> GeneratePdfFromMemoryStream(MemoryStream pdfStream)
        {
            try
            {
                pdfStream.Position = 0;
                Document document = new();
                document.LoadFromStream(pdfStream, FileFormat.Docx);

                var temphFilePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

                ToPdfParameterList toPdf = new();
                toPdf.PdfConformanceLevel = PdfConformanceLevel.Pdf_A1B;

                document.SaveToFile(temphFilePath, toPdf);

                using (var fileStream = File.OpenRead(temphFilePath))
                {
                    string blobUri = await _blobService.UploadAsyncStream(fileStream, "documents");
                    return blobUri;
                }

            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Pdf Generator:" + ex.Message);
            }
        }
    }
}
