using fi_group.Application.Interface;
using fi_group.Application.Main;
using fi_group.Domain.Core;
using fi_group.Domain.Interface;
using fi_group.InfraStructure.Interface;
using fi_group.InfraStructure.Repository;
using fi_group.InfraStructure.Repository.Persistence;
using fi_group.Services.WebAPIRest.Helpers;
using fi_group.Transversal.Logging;
using fi_group.Transversal.Mapper;
using i_group.Transversal.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });

var appSettingsSection = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);

//configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();

var cnnString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskDbContext>(opt =>
{
    opt.UseSqlServer(cnnString);
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();

builder.Services.AddScoped<ITaskApplication, TaskApplication>();
builder.Services.AddScoped<ITaskDomain, TaskDomain>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var IsSuer = appSettings.IsSuer;
var Audience = appSettings.Audience;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();