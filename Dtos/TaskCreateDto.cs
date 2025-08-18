namespace TaskManager.API.Dtos
{
    public class TaskCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "To Do";
        public DateTime DueDate { get; set; }
    }
}