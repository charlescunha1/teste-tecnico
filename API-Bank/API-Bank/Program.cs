using API_Bank.Application.AppService;
using API_Bank.Application.AutoMapper;
using API_Bank.Application.Interface;
using API_Bank.Domain.IRepository;
using API_Bank.Infra.Data.Context;
using API_Bank.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBankAccountAppService, BankAccountAppService>();
builder.Services.AddScoped<IBalanceAppService, BalanceAppService>();
builder.Services.AddScoped<IBankAccountRepository ,BankAccountRepository>();
builder.Services.AddScoped<IBalanceRepository , BalanceRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Configuração do DbContext para usar o Pomelo MySQL

builder.Services.AddDbContext<BankAccountContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 23))));
//builder.Services.AddDbContext<BankAccountContext>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
