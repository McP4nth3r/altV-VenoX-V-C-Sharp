using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VenoX.Data.Database.Models;

public class DatabaseAccount
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public ulong HardwareId { get; set; }
    public ulong HardwareIdEx { get; set; }
    public ulong SocialClubId { get; set; }
    public string Email { get; set; }
    public string Language { get; set; }
    public int Sex { get; set; }
    public int AdminLevel { get; set; }
    public int PlayTime { get; set; }
    public int ForumUID { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastLogin { get; set; }
    public int Coins { get; set; }
    public int VIP_Level { get; set; }
    public DateTime VIP_Expire { get; set; }
    public DateTime VIP_BuyDate { get; set; }
}