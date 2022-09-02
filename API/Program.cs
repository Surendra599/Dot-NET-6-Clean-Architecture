using Application.DependencyInjection;
using Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureApplicationServices()
      .ConfigureInfrastructureServices(builder.Configuration, builder.Configuration.GetConnectionString("AppDbContextConnection"));



var app = builder.Build();

// Configure the HTTP request pipeline.

//Custome Middleware

// app.UseErrorHandling(); //1. Way 1 to Handle Global Error Handling

// app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthentication(); // JWT Bearer Authentication

app.UseAuthorization();

app.MapControllers();

app.Run();