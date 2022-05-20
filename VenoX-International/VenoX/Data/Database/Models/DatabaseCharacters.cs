using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VenoX.Data.Database.Models;

public class DatabaseCharacters
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UID { get; set; }
    public string Username { get; set; }
    public float PosX { get; set; }
    public float PosY { get; set; }
    public float PosZ { get; set; }
    public float Rotation { get; set; }
    public int Money { get; set; }
    public int Bank { get; set; }
    public string SocialState { get; set; }
    public int Health { get; set; }
    public int Armor { get; set; }
    public int Sex { get; set; }
    public int Faction { get; set; }
    public int FactionRank { get; set; }
    public string Job { get; set; }
    public int Phone { get; set; }
    public int PlayTime { get; set; }
    public int IsDead { get; set; }
    public string SpawnPoint { get; set; }
    public int PrisonTime { get; set; }
    public int PrisonBail { get; set; }

}