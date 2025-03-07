namespace PdfGeneratorAPI.Repository.Interfaces
{
    public interface IBlobService
    {
        Task<string> UploadAsyncStream(Stream file, string container, string? filename = null, string? fileType = "application/pdf");
    }
}
