using LinkedInWebApi.Application.Handlers;
using LinkedInWebApi.Application.Handlers.MessageHandler;
using LinkedInWebApi.Application.Handlers.UserHandler;
using LinkedInWebApi.Application.Services;
using LinkedInWebApi.Application.Services.UserService;
using LinkedInWebApi.Core;
using LinkedInWebApi.Middlewares;
using LinkedInWebApi.Reposirotry.Commands;
using LinkiedInWebApi.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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

//Handlers
builder.Services.AddScoped<IAdvertisementHandler, AdvertisementHandler>();
builder.Services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
builder.Services.AddScoped<IContactRequestHandler, ContactRequestHandler>();
builder.Services.AddScoped<IMessageHandler, MessageHandler>();
builder.Services.AddScoped<IPostHandler, PostHandler>();
builder.Services.AddScoped<IUserHandler, UserHandler>();
builder.Services.AddScoped<IGlobalConstantsHandler, GlobalConstantsHandler>();

//Services
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IContactRequestService, ContactRequestService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserValidationServices, UserValidationsServices>();
builder.Services.AddScoped<IGlobalConstantsServices, GlobalConstantsServices>();


//Commands
builder.Services.AddScoped<IAdvertisementInserCommands, AdvertisementInserCommands>();
builder.Services.AddScoped<IAdvertisemenReadCommands, AdvertisementReadCommands>();
builder.Services.AddScoped<IAdvertisementUpdateCommands, AdvertisementUpdateCommands>();
builder.Services.AddScoped<IContactRequestInsertCommands, ContactRequestInsertCommands>();
builder.Services.AddScoped<IContactRequestReadCommands, ContactRequestReadCommands>();
builder.Services.AddScoped<IContactRequestUpdateCommands, ContactRequestUpdateCommands>();
builder.Services.AddScoped<IMessageInsertCommands, MessageInsertCommands>();
builder.Services.AddScoped<IMessageReadCommands, MessageReadCommands>();
builder.Services.AddScoped<IContactRequestInsertCommands, ContactRequestInsertCommands>();
builder.Services.AddScoped<IContactRequestReadCommands, ContactRequestReadCommands>();
builder.Services.AddScoped<IContactRequestUpdateCommands, ContactRequestUpdateCommands>();
builder.Services.AddScoped<IUserInsertCommands, UserInsertCommands>();
builder.Services.AddScoped<IUserReadCommands, UserReadCommands>();
builder.Services.AddScoped<IUserUpdateCommands, UserUpdateCommands>();
builder.Services.AddScoped<IGlobalConstantsReadCommands, GlobalConstantsReadCommands>();

builder.Services.AddScoped<IPostInsertCommands, PostInsertCommands>();
builder.Services.AddScoped<IPostReadCommands, PostReadCommands>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddCors();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});


// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LinkedInWebApi", Version = "v1" });

});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LinkedInWebApi v1"));

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