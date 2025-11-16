using Kangaro.TodoApp.Contracts.Dtos;

namespace Kangaro.TodoApp.Contracts.Interfaces;

public interface ITaskItemService
{
    Task<TaskItemDto> GetAsync(
       object id,
       CancellationToken cancellationToken = default);

    Task<IEnumerable<TaskItemDto>> GetListAsync(CancellationToken cancellationToken = default);

    Task CreateAsync(
        TaskItemDto item,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        object id,
        CancellationToken cancellationToken = default);
}


public interface ILocalStorage
{
    Task SetItemAsync<T>(string key, T value);
    Task<T?> GetItemAsync<T>(string key);
}