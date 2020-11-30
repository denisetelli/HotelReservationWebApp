using Commom.DTOs;
using DataAccess.Models;
using System.Collections.Generic;

namespace Business.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAll();

        void Add(ClientDTO client);

        ClientDTO FindById(int? id);

        bool Delete(int? clientId);

        void Edit(ClientDTO client);

        IEnumerable<ClientDTO> FindByName(string name);

        bool IsDocAlreadyRegistered(ClientDTO client);

        List<ClientType> GetTypes();

        IEnumerable<ClientDTO> GetOnlyPerson();

        IEnumerable<ClientDTO> SearchClient(string searchLetters);

        IEnumerable<ClientDTO> SearchClientOnlyPerson(string searchLetters);
    }
}
