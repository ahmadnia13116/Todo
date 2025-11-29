using Kangaro.TodoApp.Application.ba.Service.Category;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()    // اجازه همه Originها
            .AllowAnyHeader()    // اجازه همه هدرها
            .AllowAnyMethod();   // اجازه همه متدها (GET, POST, DELETE, ...)
    });
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddScoped<ICategoryServicee, CategoryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();        
    app.MapScalarApiReference();   
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
