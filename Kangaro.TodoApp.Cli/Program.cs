// See https://aka.ms/new-console-template for more information
using Kangaro.TodoApp.Application.Services;
using Kangaro.TodoApp.Contracts.Interfaces;

Console.WriteLine("Welcome to todo app cli app!");


Console.WriteLine("Do you want create Task? give me list");
var categoryName = Console.ReadLine();

var httpClient = new HttpClient();
ICategoryService categoryService = new CategoryApiService(httpClient);

if (!string.IsNullOrEmpty(categoryName))
{
    await categoryService.CreateAsync(new Kangaro.TodoApp.Contracts.Dtos.ListItemDto { Id = Guid.NewGuid(), Name = categoryName });
}
