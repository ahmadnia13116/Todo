namespace MyBlazor.Pages.Data
{
    public class ListService
    {
        private const string StorageKey = "todo_lists";
        private readonly LocalStorageService _localStorage;
        private List<ListItem> _lists = new();

        public ListService(LocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task InitializeAsync()
        {
            _lists = await _localStorage.GetItemAsync<List<ListItem>>(StorageKey) ?? new();
        }

        public IEnumerable<ListItem> GetAll() => _lists;

        public async Task AddListAsync(ListItem list)
        {
            _lists.Add(list);
            await SaveAsync();
        }

        public async Task DeleteListAsync(Guid id)
        {
            _lists.RemoveAll(x => x.Id == id);
            await SaveAsync();
        }

        public async Task AddTaskToList(Guid listId, TaskItem task)
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
    }
}
