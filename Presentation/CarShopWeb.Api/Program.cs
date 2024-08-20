using CarShopWeb.Api.Registrations;
using CarShopWeb.Application.Automapper;
using CarShopWeb.Persistence.Registrations;
using CarShopWeb.Infrastructure.Registrations;
using Serilog.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices();

builder.Services.AddPresentationServices(builder.Configuration);

builder.Services.AddPersistanceServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(MappingProfile));
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

app.UseAuthorization();
app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null == true ? context.User.Identity.Name : null;
    LogContext.PushProperty("User_Name", username);
    await next();
});

app.MapControllers();

app.Run();
