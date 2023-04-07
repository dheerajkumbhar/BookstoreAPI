using BookstoreAPI.Data;
using BookstoreAPI.Models.Authorization;
using BookstoreAPI.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<Bookstorecontext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDB")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<Bookstorecontext>()
    .AddDefaultTokenProviders();
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
