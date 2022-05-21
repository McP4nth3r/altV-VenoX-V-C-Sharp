using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VenoX.Data.Database.Models;

public class DatabaseQuestLevels
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UID { get; set; }
}