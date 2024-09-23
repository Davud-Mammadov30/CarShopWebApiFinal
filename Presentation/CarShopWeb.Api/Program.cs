using CarShopWeb.Api.Registrations;
using CarShopWeb.Application.Automapper;
using CarShopWeb.Persistence.Registrations;
using CarShopWeb.Infrastructure.Registrations;
using Serilog.Context;
using FluentValidation.AspNetCore;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using Serilog.Events;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.ObjectModel;
using CarShopWeb.Api.Extensions;
using CarShopWeb.Application.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<CreateUserValidator>();
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices();

builder.Services.AddPresentationServices(builder.Configuration);

builder.Services.AddPersistanceServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(MappingProfile));
Logger? log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/mylog-{Date}.txt")
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("ConnectionDefault"), sinkOptions: new MSSqlServerSinkOptions
    {
        TableName = "CSWALog",
        AutoCreateSqlTable = true
    },
    null, null, LogEventLevel.Warning, null,
    columnOptions: new ColumnOptions
    {
        AdditionalColumns = new Collection<SqlColumn>
        {
            new SqlColumn(columnName:"User_Name",SqlDbType.NVarChar)
        }
    },
    null, null
    )
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();
Log.Logger = log;
builder.Host.UseSerilog(log);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "CarShop WebApi");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.ConfigureExceptionHandler();

app.UseAuthorization();
app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null == true ? context.User.Identity.Name : null;
    LogContext.PushProperty("User_Name", username);
    await next();
});

app.MapControllers();

app.Run();
