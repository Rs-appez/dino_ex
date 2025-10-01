using Dino.Common.Repositories;
using DEntities = Dino.DAL.Entities;
using BEntities = Dino.BLL.Entities;
using DServices = Dino.DAL.Services;
using BServices = Dino.BLL.Services;

var MyAllowSpecificOrigins = "_myFrontendOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDinoRepository<DEntities.Dino>, DServices.DinoService>();
builder.Services.AddScoped<IDinoRepository<BEntities.Dino>, BServices.DinoService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5112");
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
