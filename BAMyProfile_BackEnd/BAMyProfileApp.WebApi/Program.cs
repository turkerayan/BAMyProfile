using BAMyProfileApp.BackgroundJob.Extensions;
using BAMyProfileApp.Business.Extensions;
using BAMyProfileApp.DataAccess.EFCore.Extensions;
using BAMyProfileApp.DataAccess.Extentesions;
using BAMyProfileApp.Dtos.EMailConfigs;
using BAMyProfileApp.WebApi.Extensions;
using Hangfire;
using System.Globalization;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataAccessServices(builder.Configuration)
    .AddEFCoreServices(builder.Configuration)
    .AddBusinessServices().AddIdentityConfiguration(builder.Configuration)
    .AddBackgroundJobServices(builder.Configuration)
    .AddFluentValidationWithAssemblies();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenConfiguration();

builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder => builder
        .Cache()
        .With(c => c.HttpContext.Request.Path.StartsWithSegments("/student"))
        .Tag("tag-student"));
       
});


builder.Services.AddLocalization();
var localizationOptions = new RequestLocalizationOptions();
var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("tr-TR") }; // Desteklenen kültürler
localizationOptions.SupportedCultures = supportedCultures;
localizationOptions.SupportedUICultures = supportedCultures;
localizationOptions.SetDefaultCulture("tr-TR");// Varsayýlan kültür
localizationOptions.ApplyCurrentCultureToResponseHeaders=true;
builder.Services.Configure<EmailOption>(builder.Configuration.GetSection("EmailOption"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();
app.UseCors("AllowAllOrigin");
app.UseRequestLocalization(localizationOptions);
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHangfireDashboard(); //Hangfire UI
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseOutputCache();

app.UseAuthorization();

app.MapControllers();

app.Run();
