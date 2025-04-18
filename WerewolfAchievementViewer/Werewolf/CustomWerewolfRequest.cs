using NewTsWw.Models.Werewolf;
using System.Net;

namespace WerewolfAchievementViewer.Werewolf;

public class CustomWerewolfRequest() : WerewolfRequest(
    new($"https://corsproxy.io/?url={WebUtility.UrlEncode("https://www.tgwerewolf.com/Stats")}"))
{

}
