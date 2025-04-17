// Ignore Spelling: achv

using NewTsWw.Models.Werewolf;
using System.Collections;

namespace WerewolfAchievementViewer.Werewolf;

public static partial class Extensions
{
    public static byte[] ToByteArray(this BitArray bits)
    {
        byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
        bits.CopyTo(ret, 0);
        return ret;
    }

    public static string ToBase64String(this BitArray bits) => Convert.ToBase64String(bits.ToByteArray());

    public static BitArray FromBase64String(this string base64) => new BitArray(Convert.FromBase64String(base64));

    public static IEnumerable<AchievementId> GetUniqueFlags(this BitArray flags)
    {
        for (var i = 0; i < flags.Length; i++)
        {
            if (flags.Get(i))
            {
                yield return (AchievementId)i;
            }
        }
    }

    public static bool HasFlag(this BitArray array, AchievementId achv)
    {
        return array[(int)achv];
    }

    public static BitArray Set(this BitArray array, AchievementId achv)
    {
        array[(int)achv] = true;
        return array;
    }

    public static BitArray Unset(this BitArray array, AchievementId achv)
    {
        array[(int)achv] = false;
        return array;
    }
}
