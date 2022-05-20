using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VenoX.Data.Database.Models;

public class DatabaseAccountSettings
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UID { get; set; }
    public int ReallifeHud { get; set; }
    public int ShowATM { get; set; }
    public int ShowHouse { get; set; }
    public int ShowSpeedometer { get; set; }
    public int ShowQuests { get; set; }
    public int ShowNewsMessages { get; set; }
    public int ShowGlobalchat { get; set; }
}