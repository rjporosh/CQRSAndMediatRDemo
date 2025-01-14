using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Repositories.Interfaces;
using CQRSAndMediatRDemo.Repositories;
using MediatR;
using System.Reflection;
using CQRSAndMediatRDemo.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(typeof(CreateStudentCommand).Assembly);
//builder.Services.AddMediatR(typeof(UpdateStudentCommand).Assembly);
//builder.Services.AddMediatR(typeof(DeleteStudentCommand).Assembly);

builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddControllers();
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
