using BetaApi.Models;

namespace BetaApi.Interfaces;

public interface IDataService
{
    List<Data> GetAll();
    Data? GetById(int id);
    void Add(Data data);
    void Update(Data data);
    void Delete(int id);
}