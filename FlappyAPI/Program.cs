using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FlappyAPI.Data;
using FlappyAPI.Models;
using Microsoft.AspNetCore.Identity;
using FlappyAPI.Modelss;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FlappyAPIContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlappyAPIContext") ?? throw new InvalidOperationException("Connection string 'FlappyAPIContext' not found."));
    options.UseLazyLoadingProxies();
});
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<FlappyAPIContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});
// Add services to the container.

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
