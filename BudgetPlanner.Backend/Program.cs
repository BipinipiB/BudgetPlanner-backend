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

//register OpenAIService
builder.Services.AddSingleton<IOpenAIService,OpenAIService>();



//Enable CORS
//CORS allows frontend origins
//Telling your security guard that its okay to let request from followin origin is safe
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowJSApp",
        builder => builder
            .WithOrigins("http://127.0.0.1:5500")
            .AllowAnyHeader()
            .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.UseHttpsRedirection();

app.UseCors("AllowJSApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
