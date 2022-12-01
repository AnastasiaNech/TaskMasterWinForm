using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMasterTutorial.Model;

[Table("Statuses")]
public class Status
{
    [Key]
    public int Id { get; set; }  
    public string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
