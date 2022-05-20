using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VenoX.Data.Database.Models;

public class DatabaseZombiesUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UID { get; set; }
    public int Kills { get; set; }
    public int PlayerKills { get; set; }
    public int Deaths { get; set; }
}