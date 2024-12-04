using Domain.Interfaces;
using Domain.Interfaces.Generic;
using Domain.Services;
using Impar.Infra.IoC;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Description = "Api para realizar todas as operações do desafio Ímpar!",
    });

});


#region ConfigServices

builder.Services.AddDbContext<ContextBase>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#endregion

builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(c => c
.AllowAnyOrigin()
.AllowAnyMethod().
AllowAnyHeader());

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();
