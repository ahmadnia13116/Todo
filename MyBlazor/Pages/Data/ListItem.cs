namespace MyBlazor.Pages.Data
{
    public class ListItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        // تسک‌های داخل این لیست
        public List<TaskItem> Tasks { get; set; } = new();
    }
}
    