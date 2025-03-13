using BetaApi.Interfaces;
using BetaApi.Models;

namespace BetaApi.Implementations;

public class DataService : IDataService
{
    private readonly List<Data> _data = new();

    public List<Data> GetAll() => _data;

    public Data? GetById(int id) => _data.FirstOrDefault(d => d.Id == id);

    public void Add(Data data)
    {
        var newId = _data.Any() ? _data.Max(d => d.Id) + 1 : 1;
        var newData = data with { Id = newId };
        _data.Add(newData);
    }

    public void Update(Data updatedData)
    {
        var existingData = _data.FirstOrDefault(d => d.Id == updatedData.Id);
        if (existingData != null)
        {
            _data.Remove(existingData);
            _data.Add(updatedData);
        }
    }

    public void Delete(int id)
    {
        var data = _data.FirstOrDefault(d => d.Id == id);
        if (data != null)
        {
            _data.Remove(data);
        }
    }
}