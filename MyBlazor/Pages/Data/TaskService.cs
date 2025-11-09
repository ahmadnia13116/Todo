namespace MyBlazor.Pages.Data
{

    public class TaskService
    {
        private const string StorageKey = "todo_tasks";
        private readonly LocalStorageService _localStorage;
        private List<TaskItem> _tasks = new();

        public TaskService(LocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task InitializeAsync()
        {
            _tasks = await _localStorage.GetItemAsync<List<TaskItem>>(StorageKey) ?? new();
        }

        public IEnumerable<TaskItem> GetAll() => _tasks;

        public async Task AddAsync(TaskItem task)
        {
            _tasks.Add(task);
            await SaveAsync();
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

        public async Task DeleteAsync(Guid id)
        {
            _tasks.RemoveAll(x => x.Id == id);
            await SaveAsync();
        }

        private async Task SaveAsync() =>
            await _localStorage.SetItemAsync(StorageKey, _tasks);
    }
}
