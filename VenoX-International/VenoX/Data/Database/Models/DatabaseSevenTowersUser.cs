using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VenoX.Data.Database.Models;

public class DatabaseSevenTowersUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UID { get; set; }
    public int Wins { get; set; }
}