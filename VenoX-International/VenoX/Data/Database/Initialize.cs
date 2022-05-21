using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using VenoX.Data.Database.Models;

namespace VenoX.Data.Database
{
    public class Config
    {
        public const string Host = "127.0.0.1";
        public const string User = "VenoX_V";
        public const string Password = "dP3#w9w26l871qR*u8n8871W~al";
        public const string Table = "VenoX_V";
        public const string Port = "3306";
    }

    public class VenoXContext : DbContext
    {
        public virtual DbSet<DatabaseAccount> Accounts { get; set; }
        public virtual DbSet<DatabaseAccountSettings> AccountSettings { get; set; }
        public virtual DbSet<DatabaseCharacters> Characters { get; set; }
        public virtual DbSet<DatabaseJobLevels> JobLevels { get; set; }
        public virtual DbSet<DatabaseQuestLevels> QuestLevels { get; set; }
        public virtual DbSet<DatabaseSevenTowersUser> SevenTowersUsers { get; set; }
        public virtual DbSet<DatabaseTacticsUser> TacticsUsers { get; set; }
        public virtual DbSet<DatabaseZombiesUser> ZombiesUsers { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            //Lokal
            string connectionStr = $"server={Config.Host}; port={Config.Port}; user={Config.User}; password={Config.Password}; database={Config.Table}";
            optionsBuilder.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public static void OnResourceStart()
        {
            using VenoXContext db = new VenoXContext();
            Constants.Accounts = new List<DatabaseAccount>(db.Accounts);
            Constants.AccountSettings = new List<DatabaseAccountSettings>(db.AccountSettings);
            Constants.Characters = new List<DatabaseCharacters>(db.Characters);
            Constants.QuestLevels = new List<DatabaseQuestLevels>(db.QuestLevels);
            Constants.SevenTowersUsers = new List<DatabaseSevenTowersUser>(db.SevenTowersUsers);
            Constants.TacticsUsers = new List<DatabaseTacticsUser>(db.TacticsUsers);
            Constants.ZombiesUsers = new List<DatabaseZombiesUser>(db.ZombiesUsers);
            
            global::VenoX.Debug.ConsoleHandling.OutputDebugStringColored("-------- Loaded : [" + Constants.Accounts.Count + "] Accounts... --------", ConsoleColor.Cyan);
            global::VenoX.Debug.ConsoleHandling.OutputDebugStringColored("-------- Loaded : [" + Constants.AccountSettings.Count + "] AccountSettings... --------", ConsoleColor.Cyan);
            global::VenoX.Debug.ConsoleHandling.OutputDebugStringColored("-------- Loaded : [" + Constants.Characters.Count + "] Characters... --------", ConsoleColor.Cyan);
            global::VenoX.Debug.ConsoleHandling.OutputDebugStringColored("-------- Loaded : [" + Constants.QuestLevels.Count + "] QuestLevels... --------", ConsoleColor.Cyan);
            global::VenoX.Debug.ConsoleHandling.OutputDebugStringColored("-------- Loaded : [" + Constants.SevenTowersUsers.Count + "] SevenTowersUsers... --------", ConsoleColor.Cyan);
            global::VenoX.Debug.ConsoleHandling.OutputDebugStringColored("-------- Loaded : [" + Constants.TacticsUsers.Count + "] TacticsUsers... --------", ConsoleColor.Cyan);
            global::VenoX.Debug.ConsoleHandling.OutputDebugStringColored("-------- Loaded : [" + Constants.ZombiesUsers.Count + "] ZombiesUsers... --------", ConsoleColor.Cyan);

            //Debug.ConsoleHandling.OutputDebugStringColored("~~~~~~~ Loaded : [" + DatabasePlayers.Count + "] players... ~~~~~~~", ConsoleColor.Cyan);
            //Debug.ConsoleHandling.OutputDebugStringColored("~~~~~~~ DEBUG : [" + DatabasePlayers[0].Username + "] Username ... ~~~~~~~", ConsoleColor.Cyan);
            //Debug.ConsoleHandling.OutputDebugStringColored("~~~~~~~ DEBUG : [" + DatabasePlayers[0].PlayTime + "] PlayTime... ~~~~~~~", ConsoleColor.Cyan);

            /*db.HorizonDatabasePlayer.Update(new HorizonDatabasePlayer());
            db.SaveChanges();*/
        }

    }
    public class Initialize
    {

    }
}

