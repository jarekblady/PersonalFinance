using Microsoft.EntityFrameworkCore;
using PersonalFinance.Repository.Context;
using PersonalFinance.Repository.Repositories.AccountRepository;
using PersonalFinance.Repository.Repositories.ExpenditureCategoryRepository;
using PersonalFinance.Repository.Repositories.ExpenditureRepository;
using PersonalFinance.Repository.Repositories.IncomeCategoryRepository;
using PersonalFinance.Repository.Repositories.IncomeRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<FinanceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceConnectionString")));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IIncomeCategoryRepository, IncomeCategoryRepository>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IExpenditureCategoryRepository, ExpenditureCategoryRepository>();
builder.Services.AddScoped<IExpenditureRepository, ExpenditureRepository>();



builder.Services.AddSwaggerGen();

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
