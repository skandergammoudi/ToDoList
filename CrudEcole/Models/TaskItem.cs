namespace CrudEcole.Models
{
    public class TaskItem
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public bool IsCompleted { get; set; }
        public DateTime? StartTime { get; set; } // Nullable pour indiquer que la tâche n'a pas encore commencé
        public DateTime? EndTime { get; set; } // Nullable pour indiquer que la tâche n'est pas encore finie
    }
}

