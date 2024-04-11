using DCEWebAPI.Business.CustomerBusiness;
using DCEWebAPI.Business.Interface;
using DCEWebAPI.DataAccess.CustomerDataAccess;
using DCEWebAPI.DataAccess.Interface;
using DCEWebAPI.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DCEConnection");

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSingleton<ICustomerBusiness, CustomerBusiness>();
builder.Services.AddSingleton<ICustomerDataAccess>(provider => new CustomerDataAccess(connectionString));

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
