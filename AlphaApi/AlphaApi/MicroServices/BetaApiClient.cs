using AlphaApi.Models;

namespace AlphaApi.MicroServices;

public class BetaApiClient(HttpClient httpClient)
{
    public async Task<string> GetDataFromBetaApi()
    {
        var response = await httpClient.GetAsync("http://localhost:5267/betaApi/data");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
    
    public async Task<string> PostDataToBetaApi(Data data)
    {
        var response = await httpClient.PostAsJsonAsync("http://localhost:5267/betaApi/data", data);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
    
    public async Task<string> PutDataToBetaApi(int id, Data data)
    {
        var response = await httpClient.PutAsJsonAsync($"http://localhost:5267/betaApi/data/{id}", data);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
    
    public async Task<string> DeleteDataFromBetaApi(int id)
    {
        var response = await httpClient.DeleteAsync($"http://localhost:5267/betaApi/data/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}