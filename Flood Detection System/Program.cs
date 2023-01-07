using Flood_Detection_System.IService;
using Flood_Detection_System.Models;
using Flood_Detection_System.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.ConfigureServices(
//    services =>
//        services.AddHostedService<Worker>()
//            .AddScoped<IMessageWriter, MessageWriter>());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<ILoginPreview, LoginPreview>();
//builder.Services.AddSingleton<ILoginPreview, LoginPreview>();
builder.Services.AddTransient<ILoginPreview, LoginPreview>();

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
