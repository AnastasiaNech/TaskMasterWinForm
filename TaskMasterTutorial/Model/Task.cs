using System.ComponentModel.DataAnnotations;


namespace TaskMasterTutorial.Model;

public class Task
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? Date { get; set; }
    public int StatusId { get; set; }
    public Status Status { get; set; }
}
