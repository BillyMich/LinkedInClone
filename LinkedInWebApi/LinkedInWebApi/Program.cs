using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Application.Handlers.UserHandler;
using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Application.Services.UserService;
using LinkedInWebApi.Application.Services.ValidationServices;
using LinkedInWebApi.Core;
using LinkedInWebApi.Middlewares;
using LinkedInWebApi.Reposirotry.Commands;
using LinkiedInWebApi.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<LinkedInDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // The number of times to retry before failing
            maxRetryDelay: TimeSpan.FromSeconds(1), // The maximum delay between retries
            errorNumbersToAdd: null); // SQL error numbers to consider as transient
    }));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(jwtSettings.GetSection("securityKey").Value))
    };
    options.IncludeErrorDetails = true;

});

builder.Services.AddScoped<JwtHandler>();


builder.Services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IUserReadCommands, UserReadCommands>();
builder.Services.AddScoped<IUserInsertCommands, UserInsertCommands>();
builder.Services.AddScoped<IUserValidationServices, UserValidationsServices>();
builder.Services.AddScoped<IUserHandler, UserHandler>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddCors();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions()
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
//    RequestPath = new PathString("/Resources")
//});
app.UseCors("AllowAngularApp");


app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseExceptionMiddleware();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Logger.LogInformation("Starting the BackendService!");
app.Run();