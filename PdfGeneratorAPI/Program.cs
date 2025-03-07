using Azure.Storage.Blobs;
using BLL.Services;
using PdfGeneratorAPI.BLL.Services;
using PdfGeneratorAPI.Repository.Interfaces;
using Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorageConnectionString")));


builder.Services.AddControllers();
builder.Services.AddSingleton<IPdfGeneratorService, PdfGeneratorService>();
builder.Services.AddSingleton<IBlobService, BlobService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
