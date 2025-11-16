using Kangaro.TodoApp.Contracts.Dtos;
using Kangaro.TodoApp.Contracts.Interfaces;

namespace Kangaro.TodoApp.Application.Services;


public class TaskItemLocalStorageService : ITaskItemService
{
    private const string StorageKey = "todo_tasks";
    private readonly ILocalStorage _localStorage;
    private List<TaskItemDto> _tasks = new();

    public TaskItemLocalStorageService(ILocalStorage localStorage)
    {
        _localStorage = localStorage;
    }


    public async Task ToggleAsync(Guid id)
    {
        var t = _tasks.FirstOrDefault(x => x.Id == id);
        if (t != null)
        {
            t.IsCompleted = !t.IsCompleted;
            await SaveAsync();
        }
    }

    private async Task SaveAsync() =>
        await _localStorage.SetItemAsync(StorageKey, _tasks);

    public async Task<TaskItemDto> GetAsync(object id, CancellationToken cancellationToken = default)
    {
        _tasks = await _localStorage.GetItemAsync<List<TaskItemDto>>(StorageKey) ?? new();
        return _tasks.FirstOrDefault(x => x.Id == (Guid)id);
    }

    public async Task<IEnumerable<TaskItemDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        _tasks = await _localStorage.GetItemAsync<List<TaskItemDto>>(StorageKey) ?? new();
        return _tasks;
    }

    public async Task CreateAsync(
        TaskItemDto item,
        CancellationToken cancellationToken = default)
    {
        _tasks.Add(item);
        await SaveAsync();
    }

    public async Task DeleteAsync(object id, CancellationToken cancellationToken = default)
    {
        _tasks.RemoveAll(x => x.Id == (Guid)id);
        await SaveAsync();
    }
}
