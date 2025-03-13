using BetaApi.Models;

namespace BetaApi.MicroServices;

public class AlphaApiClient(HttpClient httpClient)
{
    public async Task<string> GetDataFromAlphaApi()
    {
        var response = await httpClient.GetAsync("http://alphaapi:80/alphaApi/data");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> PostDataToAlphaApi(Data data)
    {
        var response = await httpClient.PostAsJsonAsync("http://alphaapi:80/alphaApi/data", data);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> PutDataToAlphaApi(int id, Data data)
    {
        var response = await httpClient.PutAsJsonAsync($"http://alphaapi:80/alphaApi/data/{id}", data);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> DeleteDataFromAlphaApi(int id)
    {
        var response = await httpClient.DeleteAsync($"http://alphaapi:80/alphaApi/data/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}