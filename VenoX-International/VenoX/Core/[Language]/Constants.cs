using System.Collections.Generic;
using AltV.Net;
using VenoX.Core._Language_.Models;

namespace VenoX.Core._Language_;
public class Constants
{
    public enum Languages
    {
        German = 0,
        English = 1,
        French = 2,
        Polish = 3,
        Spanish = 4,
        Turkish = 5,
        Russian = 6,
        Swedish = 7,
        Serbian = 8,
        Chinese = 9,
        Farsi = 10,
        Italian = 11
    }

    public static readonly List<string> LanguagePathFolders = new()
    {
            Alt.Server.Resource.Path + "/Languages/language-fr/",
            Alt.Server.Resource.Path + "/Languages/language-de/",
            Alt.Server.Resource.Path + "/Languages/language-pl/",
            Alt.Server.Resource.Path + "/Languages/language-es/",
            Alt.Server.Resource.Path + "/Languages/language-tr/",
            Alt.Server.Resource.Path + "/Languages/language-ru/",
            Alt.Server.Resource.Path + "/Languages/language-sv/",
            Alt.Server.Resource.Path + "/Languages/language-sr/",
            Alt.Server.Resource.Path + "/Languages/language-zh-cn/",
            Alt.Server.Resource.Path + "/Languages/language-fa/",
            Alt.Server.Resource.Path + "/Languages/language-it/",
    };


    private const string LanguageParents_Account = "Account";
    private const string LanguageParents_Lobby = "Lobby";
    private const string LanguageParents_House = "House";
    private const string LanguageParents_Environment = "Environment";
    public const string LanguageParents_Unknown = "Unknown";
    public static readonly List<string> LanguageParents = new()
    {
        LanguageParents_Account,
        LanguageParents_Lobby,
        LanguageParents_House,
        LanguageParents_Environment,
        LanguageParents_Unknown,
    };


    public static readonly List<string> LanguagePaths = new()
    {
        Alt.Server.Resource.Path + "/Languages/language-fr.json",
        Alt.Server.Resource.Path + "/Languages/language-de.json",
        Alt.Server.Resource.Path + "/Languages/language-pl.json",
        Alt.Server.Resource.Path + "/Languages/language-es.json",
        Alt.Server.Resource.Path + "/Languages/language-tr.json",
        Alt.Server.Resource.Path + "/Languages/language-ru.json",
        Alt.Server.Resource.Path + "/Languages/language-sv.json",
        Alt.Server.Resource.Path + "/Languages/language-sr.json",
        Alt.Server.Resource.Path + "/Languages/language-zh-cn.json",
        Alt.Server.Resource.Path + "/Languages/language-fa.json",
        Alt.Server.Resource.Path + "/Languages/language-it.json"
    };

    public static readonly Dictionary<string, LanguageModel> LanguagePackFr = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackDe = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackPl = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackEs = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackTr = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackRu = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackSv = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackSr = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackCn = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackFa = new();
    public static readonly Dictionary<string, LanguageModel> LanguagePackIt = new();
}