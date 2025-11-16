using Kangaro.TodoApp.Contracts.Dtos;
using Kangaro.TodoApp.Contracts.Interfaces;

namespace Kangaro.TodoApp.Application.Services;

public class CategoryLocalStorageervice : ICategoryService
{
    private const string StorageKey = "todo_lists";
    private readonly ILocalStorage _localStorage;
    private List<ListItemDto> _lists = new();

    public CategoryLocalStorageervice(ILocalStorage localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task AddTaskToList(Guid listId, TaskItemDto task)
    {
        var list = _lists.FirstOrDefault(x => x.Id == listId);
        if (list != null)
        {
            list.Tasks.Add(task);
            await SaveAsync();
        }
    }

    public async Task ToggleTask(Guid listId, Guid taskId)
    {
        var list = _lists.FirstOrDefault(x => x.Id == listId);
        var task = list?.Tasks.FirstOrDefault(x => x.Id == taskId);
        if (task != null)
        {
            task.IsCompleted = !task.IsCompleted;
            await SaveAsync();
        }
    }

    public async Task DeleteTask(Guid listId, Guid taskId)
    {
        var list = _lists.FirstOrDefault(x => x.Id == listId);
        if (list != null)
        {
            list.Tasks.RemoveAll(x => x.Id == taskId);
            await SaveAsync();
        }
    }

    private async Task SaveAsync() =>
        await _localStorage.SetItemAsync(StorageKey, _lists);

    public Task<ListItemDto> GetAsync(object id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_lists.FirstOrDefault(x => x.Id == (Guid)id));
    }

    public async Task<IEnumerable<ListItemDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        _lists = await _localStorage.GetItemAsync<List<ListItemDto>>(StorageKey) ?? new List<ListItemDto>();
        return _lists;
    }

    public async Task CreateAsync(ListItemDto item, CancellationToken cancellationToken = default)
    {
        _lists.Add(item);
        await SaveAsync();
    }

    public async Task DeleteAsync(object id, CancellationToken cancellationToken = default)
    {
        _lists.RemoveAll(x => x.Id == (Guid)id);
        await SaveAsync();
    }
}