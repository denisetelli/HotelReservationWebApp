using AutoMapper;
using Business.Services.Interfaces;
using Commom.DTOs;
using Commom.Enums;
using Commom.Extensions;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        private IMapper _mapper;

        public IEnumerable<ClientDTO> GetAll()
        {
            var clients = _clientRepository.GetAll();
            return _mapper.Map<List<ClientDTO>>(clients);
        }

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public void Add(ClientDTO client)
        {
            _clientRepository.Add(_mapper.Map<Client>(client));
        }

        public bool Delete(int? clientId)
        {
            if (_clientRepository.Delete(clientId))
            {
                return true;
            }

            return false;
        }

        public void Edit(ClientDTO client)
        {
            _clientRepository.Edit(_mapper.Map<Client>(client));
        }

        public ClientDTO FindById(int? id)
        {
            Client client = _clientRepository.FindById(id);
            return _mapper.Map<ClientDTO>(client);
        }

        public IEnumerable<ClientDTO> FindByName(string name)
        {
            var clients = _clientRepository.FindByName(name);
            var clientsDto = _mapper.Map<List<ClientDTO>>(clients);
            return clientsDto;
        }

        public bool IsDocAlreadyRegistered(ClientDTO client)
        {
            string docNumber = string.Empty;
            if (client.Type == ClientTypeEnum.Person)
            {
                docNumber = client.Cpf;
            }
            if (client.Type == ClientTypeEnum.Organization)
            {
                docNumber = client.Cnpj;
            }
            return _clientRepository.IsDocAlreadyRegistered(docNumber, client.ClientId);
        }

        public List<ClientType> GetTypes()
        {
            List<ClientType> typesOfClient = new List<ClientType>();

            foreach (ClientTypeEnum type in Enum.GetValues(typeof(ClientTypeEnum)))
            {
                typesOfClient.Add(new ClientType() { Name = type.ToString(), Description = type.GetDescription() });
            }
            return typesOfClient;
        }

        public IEnumerable<ClientDTO> GetOnlyPerson()
        {
            return GetAll().Where(_ => _.Type == ClientTypeEnum.Person);
        }

        public IEnumerable<ClientDTO> SearchClient(string searchLetters)
        {
            return FindByName(searchLetters)
                .ToList();
        }

        public IEnumerable<ClientDTO> SearchClientOnlyPerson(string searchLetters)
        {
            return FindByName(searchLetters)
                 .Where(_ => _.Type == ClientTypeEnum.Person)
                 .ToList();
        }
    }
}

