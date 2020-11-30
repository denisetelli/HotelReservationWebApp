using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAll();

        void Add(Client client);

        Client FindById(int? id);

        bool Delete(int? clientId);

        bool Edit(Client client);

        IEnumerable<Client> FindByName(string name);

        bool IsDocAlreadyRegistered(string govNumber, int id);
    }
}
