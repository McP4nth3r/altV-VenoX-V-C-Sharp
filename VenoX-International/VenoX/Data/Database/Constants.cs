using System.Collections.Generic;
using VenoX.Data.Database.Models;

namespace VenoX.Data.Database;

public class Constants
{
    public static List<DatabaseAccount> Accounts = new();
    public static List<DatabaseAccountSettings> AccountSettings = new();
    public static List<DatabaseCharacters> Characters = new();
    public static List<DatabaseJobLevels> JobLevels = new();
    public static List<DatabaseQuestLevels> QuestLevels = new();
    public static List<DatabaseSevenTowersUser> SevenTowersUsers = new();
    public static List<DatabaseTacticsUser> TacticsUsers = new();
    public static List<DatabaseZombiesUser> ZombiesUsers = new();
}