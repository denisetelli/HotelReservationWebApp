using AutoMapper;
using Business.Services;
using Commom.DTOs;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Business.UnitTests
{
    public class ClientServiceTests
    {
        [Fact]
        public void GetAll_ReturnEmptyListClients()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();

            List<Client> clients = new List<Client>();
            clientRepositoryMock.Setup(_ => _.GetAll()).Returns(clients);

            List<ClientDTO> clientsDTOs = new List<ClientDTO>();
            mapperMock.Setup(_ => _.Map<List<ClientDTO>>(clients)).Returns(clientsDTOs);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = clientService.GetAll();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAll_ReturnClients()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            var id = 7;
            Client client = new Client
            {
                ClientId = id
            };
            ClientDTO clientDTO = new ClientDTO
            {
                ClientId = id
            };

            List<Client> clients = new List<Client>();
            clients.Add(client);
            clientRepositoryMock.Setup(_ => _.GetAll()).Returns(clients);

            List<ClientDTO> clientsDTOs = new List<ClientDTO>();
            clientsDTOs.Add(clientDTO);
            mapperMock.Setup(_ => _.Map<List<ClientDTO>>(clients)).Returns(clientsDTOs);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = clientService.GetAll();

            //Assert
            Assert.True(result.Any());
        }

        [Fact]
        public void Add_ClientDTOAsParameter_ShouldCallAddOnce()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            var id = 7;
            Client client = new Client
            {
                ClientId = id
            };
           
            clientRepositoryMock.Setup(_ => _.Add(It.IsAny<Client>()));

            ClientDTO clientDTO = new ClientDTO
            {
                ClientId = id
            };
            mapperMock.Setup(_ => _.Map<ClientDTO>(client)).Returns(clientDTO);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            clientService.Add(clientDTO);

            //Assert
            clientRepositoryMock.Verify(_ => _.Add(It.IsAny<Client>()), Times.Once);           
        }

        [Fact]
        public void Delete_ExistingClient_ReturnTrue()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;

            clientRepositoryMock.Setup(_ => _.Delete(It.IsAny<int>())).Returns(true);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = clientService.Delete(id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_NotExistingClient_ReturnFalse()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;

            clientRepositoryMock.Setup(_ => _.Delete(It.IsAny<int>())).Returns(false);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = clientService.Delete(id);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void Edit_ClientDTOAsParameter_ShouldCallEditOnce()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;

            Client client = new Client
            {
                ClientId = id
            };
            clientRepositoryMock.Setup(_ => _.Edit(It.IsAny<Client>()));

            ClientDTO clientDTO = new ClientDTO
            {
                ClientId = id
            };
            mapperMock.Setup(_ => _.Map<ClientDTO>(client)).Returns(clientDTO);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            clientService.Edit(clientDTO);

            //Assert
            clientRepositoryMock.Verify(_ => _.Edit(It.IsAny<Client>()), Times.Once);    
        }

        [Fact]
        public void FindById_ClientIdAsParameter_ReturnClient()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;

            Client client = new Client
            {
                ClientId = id
            };
            clientRepositoryMock.Setup(_ => _.FindById(It.IsAny<int>())).Returns(client);

            ClientDTO clientDTO = new ClientDTO
            {
                ClientId = id
            };
            mapperMock.Setup(_ => _.Map<ClientDTO>(client)).Returns(clientDTO);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = clientService.FindById(id);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void FindByName_NameAsParameter_ReturnEmptyListClients()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            string name = "Tony";

            List<Client> client = new List<Client>();
            clientRepositoryMock.Setup(_ => _.FindByName(It.IsAny<string>())).Returns(client);

            List<ClientDTO> clientDto = new List<ClientDTO>();
            mapperMock.Setup(_ => _.Map<List<ClientDTO>>(client)).Returns(clientDto);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = clientService.FindByName(name);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void FindByName_NameAsParameter_ReturnClients()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            string name = "Tony";
            Client client = new Client
            {
                FirstName = name
            };
            ClientDTO clientDTO = new ClientDTO
            {
                FirstName = name
            };

            List<Client> clients = new List<Client>();
            clients.Add(client);
            clientRepositoryMock.Setup(_ => _.FindByName(It.IsAny<string>())).Returns(clients);

            List<ClientDTO> clientsDto = new List<ClientDTO>();
            clientsDto.Add(clientDTO);
            mapperMock.Setup(_ => _.Map<List<ClientDTO>>(clients)).Returns(clientsDto);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = clientService.FindByName(name);

            //Assert
            Assert.True(result.Any());
        }
        

        [Fact]
        public void IsDocAlreadyRegistered_ClientDTOAsParameter_ReturnTrue()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;

            Client client = new Client
            {
                ClientId = id
            };
            clientRepositoryMock.Setup(_ => _.IsDocAlreadyRegistered(It.IsAny<string>(), It.IsAny<int>())).Returns(true);

            ClientDTO clientDTO = new ClientDTO
            {
                ClientId = id
            };
            mapperMock.Setup(_ => _.Map<ClientDTO>(client)).Returns(clientDTO);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);
            
            //Act
            var result = clientService.IsDocAlreadyRegistered(clientDTO);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsDocAlreadyRegistered_ClientDTOAsParameter_ReturnFalse()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();
            int id = 7;

            Client client = new Client
            {
                ClientId = id
            };
            clientRepositoryMock.Setup(_ => _.IsDocAlreadyRegistered(It.IsAny<string>(), It.IsAny<int>())).Returns(false);

            ClientDTO clientDTO = new ClientDTO
            {
                ClientId = id
            };
            mapperMock.Setup(_ => _.Map<ClientDTO>(client)).Returns(clientDTO);

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = clientService.IsDocAlreadyRegistered(clientDTO);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void GetTypes_ReturnClientTypes()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var mapperMock = new Mock<IMapper>();

            ClientService clientService = new ClientService(clientRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = clientService.GetTypes();

            //Assert
            Assert.True(result.Any());
        }
    }
}
