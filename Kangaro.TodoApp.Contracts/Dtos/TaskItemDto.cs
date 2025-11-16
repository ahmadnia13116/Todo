namespace Kangaro.TodoApp.Contracts.Dtos
{

    public class TaskItemDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = "";

        public Guid ListId { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? DueDate { get; set; }
        public string DropZone { get; set; } = "Drop Zone 1";


        public List<SubTask> SubTasks { get; set; } = new List<SubTask>();

    }

    public class SubTask
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = "";
        public bool IsCompleted { get; set; }
    }

}
