using RAPC9Y_SOF_2023241.MVC.Models;

namespace RAPC9Y_SOF_2023241.MVC.Data
{
    public interface ILoLRepository
    {
        void Create(Champion item);
        void Delete(string id);
        Champion? Read(string id);
        Champion? ReadByName(string name);
        IEnumerable<Champion> ReadAll();
        void Update(Champion item);
    }
}