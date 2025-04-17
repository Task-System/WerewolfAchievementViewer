using NewTsWw.Models.Werewolf;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace WerewolfAchievementViewer.Werewolf;

public class CustomWerewolfRequest : IDisposable
{
    private readonly HttpClient _httpClient;

    public CustomWerewolfRequest()
    {
        _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(5),
            BaseAddress = new Uri("https://www.tgwerewolf.com/Stats")
        };
    }

    public Task<TValue?> GetEndpoint<TValue>(
        WerewolfRequestEndpoint endpoint, long userId)
            => _httpClient.GetFromJsonAsync<TValue>(
                $"https://corsproxy.io/?url={WebUtility.UrlEncode(_httpClient.BaseAddress + $"/{endpoint}/?pid={userId}&json=true")}");

    public async Task<AchievementInfo[]?> GetAchievements(long userId)
    {
        try
        {
            return await GetEndpoint<AchievementInfo[]>(WerewolfRequestEndpoint.PlayerAchievements, userId);
        }
        catch (HttpRequestException he)
        {
            return null;
        }
        catch (JsonException je)
        {
            return [];
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _httpClient.Dispose();
    }
}
