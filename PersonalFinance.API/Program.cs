using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PersonalFinance.Repository.Context;
using PersonalFinance.Repository.Entities;
using PersonalFinance.Repository.Repositories.AccountRepository;
using PersonalFinance.Repository.Repositories.ExpenditureCategoryRepository;
using PersonalFinance.Repository.Repositories.ExpenditureRepository;
using PersonalFinance.Repository.Repositories.IncomeCategoryRepository;
using PersonalFinance.Repository.Repositories.IncomeRepository;
using PersonalFinance.Service;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Middleware;
using PersonalFinance.Service.Services.AccountService;
using PersonalFinance.Service.Services.ExpenditureCategoryService;
using PersonalFinance.Service.Services.ExpenditureService;
using PersonalFinance.Service.Services.IncomeCategoryService;
using PersonalFinance.Service.Services.IncomeService;
using PersonalFinance.Service.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var authenticationSettings = new AuthenticationSettings();

builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});

builder.Services.AddDbContext<FinanceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceConnectionString")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddFluentValidationAutoValidation(conf => { conf.DisableDataAnnotationsValidation = true; });
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IIncomeCategoryRepository, IncomeCategoryRepository>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IExpenditureCategoryRepository, ExpenditureCategoryRepository>();
builder.Services.AddScoped<IExpenditureRepository, ExpenditureRepository>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IIncomeCategoryService, IncomeCategoryService>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IExpenditureCategoryService, ExpenditureCategoryService>();
builder.Services.AddScoped<IExpenditureService, ExpenditureService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
