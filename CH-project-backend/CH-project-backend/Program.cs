using CH_project_backend.Auth;
using CH_project_backend.Domain;
using CH_project_backend.Environment;
using CH_project_backend.Helpers;
using CH_project_backend.Repository.BlogRepo;
using CH_project_backend.Repository.MenuRepo;
using CH_project_backend.Repository.RecipiesRepo;
using CH_project_backend.Repository.UserRepo;
using CH_project_backend.Services.BolgServices;
using CH_project_backend.Services.MenuServices;
using CH_project_backend.Services.RecipesServices;
using CH_project_backend.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var AdminCorsRules = "AllowAllCors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AdminCorsRules, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

//helpers for JwtToken
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddScoped<IJwtUtils, JwtUtils>();

//services 
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

//builder.Services.AddScoped<IBlogService, BlogService>();
//builder.Services.AddScoped<IBlogRepo, BlogRepo>();

//builder.Services.AddScoped<IMenuService, MenuService>();
//builder.Services.AddScoped<IMenuRepo, MenuRepo>();

//builder.Services.AddScoped<IRecipesService, RecipesService>();
//builder.Services.AddScoped<IRecipesRepo, RecipesRepo>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/AdminCorsRules",
        context => context.Response.WriteAsync("AdminCorsRules"))
            .RequireCors(AdminCorsRules);

    endpoints.MapControllers()
        .RequireCors(AdminCorsRules);

    endpoints.MapSwagger();
});

app.Run();