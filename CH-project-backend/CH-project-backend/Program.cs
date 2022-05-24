using CH_project_backend.Auth;
using CH_project_backend.Domain;
using CH_project_backend.Environment;
using CH_project_backend.Helpers;
using CH_project_backend.Repository.BlogRepo;
using CH_project_backend.Repository.MenuRepo;
using CH_project_backend.Repository.RecipiesRepo;
using CH_project_backend.Repository.UserRepo;
using CH_project_backend.Services.UserServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var AdminCorsRules = "AdminCors";

builder.Services.AddCors(options =>
{
    //options.AddPolicy(name: UserCorsRules, builder =>
    //{
    //    builder.WithOrigins("164.68.120.109")
    //            .WithMethods("GET","PATCH","POST")
    //            .AllowAnyHeader();
    //});
    options.AddPolicy(name: AdminCorsRules, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();

    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddControllers()
        .AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    // configure DI for application services
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IUserRepo, UserRepo>();
}

//builder.Services.AddScoped<IBlogRepo, BlogRepo>();
builder.Services.AddScoped<IMenuRepo, MenuRepo>();
//builder.Services.AddScoped<IRecipesRepo, Recipes>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    var testUser = new User
    {
        FirstName = "Test",
        LastName = "User",
        UserName = "test",
        Email = "test@Test.com",
        Password = BCrypt.Net.BCrypt.HashPassword("test")
    };
    context.User.Add(testUser);
    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
