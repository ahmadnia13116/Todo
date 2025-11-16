using System.Net.Http.Json;
using Kangaro.TodoApp.Contracts.Dtos;
using Kangaro.TodoApp.Contracts.Interfaces;

namespace Kangaro.TodoApp.Application.Services;

public class CategoryApiService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAsync(ListItemDto item, CancellationToken cancellationToken = default)
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

    public async Task<ListItemDto> GetAsync(
        object id,
        CancellationToken cancellationToken = default)
    {
        var item = await _httpClient.GetFromJsonAsync<ListItemDto>($"/get/{id}", cancellationToken);
        return item;
    }

    public async Task<IEnumerable<ListItemDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var items = await _httpClient.GetFromJsonAsync<List<ListItemDto>>("/getList", cancellationToken);
        return items;
    }
}