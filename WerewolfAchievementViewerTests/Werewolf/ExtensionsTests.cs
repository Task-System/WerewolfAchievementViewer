using System.Collections;
using System.Text;
using System.Text.Json;

namespace WerewolfAchievementViewer.Werewolf.Tests;

[TestClass]
public class ExtensionsTests
{
    [TestMethod]
    public void SetTest()
    {
        var result = new BitArray(200)
            .Set(AchievementId.Inconspicuous)
            .Set(AchievementId.IHelped)
            .Set(AchievementId.Firefighter)
            .ToBase64String();

        //if (BitConverter.IsLittleEndian)
        //    Array.Reverse(bytes);

        var url = $"https://localhost:7024/achs/{result}";
        Console.WriteLine(url);
    }
}