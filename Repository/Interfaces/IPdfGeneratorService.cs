namespace Repository.Interfaces
{
    public interface IPdfGeneratorService
    {
        Task<string> GeneratePdfFromMemoryStream(MemoryStream pdfStream);
    }
}
