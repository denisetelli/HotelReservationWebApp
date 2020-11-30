using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly HotelContext _appDbContext;
        private IQueryable<Client> _clientQueryAsNoTracking => _appDbContext?.Clients.AsNoTracking();

        public ClientRepository(HotelContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientQueryAsNoTracking.Where(_ => !_.IsDeleted);
        }

        public void Add(Client client)
        {
            _appDbContext.Add(client);
            _appDbContext.SaveChanges();
        }

        public bool Delete(int? clientId)
        {
            Client client = FindById(clientId);

            if (client != null)
            {
                client.IsDeleted = true;
                _appDbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Edit(Client client)
        {
            if (client != null)
            {
                _appDbContext.Attach(client);
                _appDbContext.Update(client);
                return _appDbContext.SaveChanges() == 1;
            }
            return false;
        }

        public Client FindById(int? id)
        {
            return _appDbContext.Clients.Where(_ => !_.IsDeleted).FirstOrDefault(_ => _.ClientId == id);
        }

        public IEnumerable<Client> FindByName(string name)
        {
            List<Client> listOfClients = new List<Client>();

            if (!String.IsNullOrEmpty(name))
            {
                listOfClients = GetAll().Where(_ => (_.FirstName ?? "").Contains(name, StringComparison.InvariantCultureIgnoreCase)
                                   || (_.LastName ?? "").Contains(name, StringComparison.InvariantCultureIgnoreCase)
                                   || (_.TradeName ?? "").Contains(name, StringComparison.InvariantCultureIgnoreCase))
                                   .ToList();
            }
            return listOfClients;
        }

        public bool IsDocAlreadyRegistered(string docNumber, int id = -1)
        {
            var isNumberRegistered = _appDbContext.Clients.Any(_ => !_.IsDeleted &&
                       _.ClientId != id && (_.Cpf == docNumber || _.Cnpj == docNumber));
            return isNumberRegistered;
        }
    }
}
