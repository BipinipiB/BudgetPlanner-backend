using BudgetPlanner.DataAccess;
using BudgetPlanner.DataAccess.Repository;
using BudgetPlanner.Service.Service;
using BudgetPlanner.Service.ServiceInterface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//register ApplicationDbContext
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//register Repositories
builder.Services.AddScoped<IExpenseRepo, ExpenseRepo>();

//register Services
builder.Services.AddScoped<IExpenseService, ExpenseService> ();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
