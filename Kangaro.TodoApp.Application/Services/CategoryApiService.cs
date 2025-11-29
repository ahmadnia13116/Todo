using System.Net.Http.Json;
using Kangaro.TodoApp.Contracts.Dtos;
using Kangaro.TodoApp.Contracts.Interfaces;

namespace Kangaro.TodoApp.Application.Services;

public class CategoryApiService : ICategoryService
{
    private readonly HttpClient _httpClient;
    private const string _controllerName = "category";

    public CategoryApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAsync(ListItemDto item, CancellationToken cancellationToken = default)
    {
        await _httpClient.PostAsJsonAsync(
            $"{_controllerName}/create",
            item,
            cancellationToken);
    }

    public async Task DeleteAsync(object id, CancellationToken cancellationToken = default)
    {
        await _httpClient.DeleteAsync(
            $"{_controllerName}/delete/{id}",
            cancellationToken);
    }

    public async Task<ListItemDto> GetAsync(
        object id,
        CancellationToken cancellationToken = default)
    {
        var item = await _httpClient.GetFromJsonAsync<ListItemDto>($"{_controllerName}/get/{id}", cancellationToken);
        return item;
    }

    public async Task<IEnumerable<ListItemDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var items = await _httpClient.GetFromJsonAsync<List<ListItemDto>>($"{_controllerName}/getList", cancellationToken);
        return items;
    }
}
