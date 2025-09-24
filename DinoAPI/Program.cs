using Dino.Common.Repositories;
using DEntities = Dino.DAL.Entities;
using BEntities = Dino.BLL.Entities;
using DServices = Dino.DAL.Services;
using BServices = Dino.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDinoRepository<DEntities.Dino>, DServices.DinoService>();
builder.Services.AddScoped<IDinoRepository<BEntities.Dino>, BServices.DinoService>();

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
