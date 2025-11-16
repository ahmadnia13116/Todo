using System.Net.Http.Json;
using Kangaro.TodoApp.Contracts.Dtos;
using Kangaro.TodoApp.Contracts.Interfaces;

namespace Kangaro.TodoApp.Application.Services;

public class TaskItemApiService : ITaskItemService
{
    private readonly HttpClient _httpClient;

    public TaskItemApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAsync(
        TaskItemDto item,
        CancellationToken cancellationToken = default)
    {
        await _httpClient.PostAsJsonAsync(
           "/create",
           item,
           cancellationToken);
    }

    public async Task DeleteAsync(object id, CancellationToken cancellationToken = default)
    {
        await _httpClient.DeleteAsync(
            $"/delete/{id}",
            cancellationToken);
    }

    public async Task<TaskItemDto> GetAsync(object id, CancellationToken cancellationToken = default)
    {
        var item = await _httpClient.GetFromJsonAsync<TaskItemDto>($"/get/{id}", cancellationToken);
        return item;
    }

    public async Task<IEnumerable<TaskItemDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var items = await _httpClient.GetFromJsonAsync<List<TaskItemDto>>("/getList", cancellationToken);
        return items;
    }
}