using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization; // Make sure this line is here

namespace TaskManager.API.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "To Do";
        public DateTime DueDate { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore] // Make sure this line is here
        public User User { get; set; }
    }
}