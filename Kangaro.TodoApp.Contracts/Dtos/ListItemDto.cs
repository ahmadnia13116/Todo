namespace Kangaro.TodoApp.Contracts.Dtos
{
    public class ListItemDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        // تسک‌های داخل این لیست
        public List<TaskItemDto> Tasks { get; set; } = new();
    }
}
