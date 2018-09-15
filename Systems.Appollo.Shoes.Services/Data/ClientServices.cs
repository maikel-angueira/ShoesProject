using System;
using System.Collections.Generic;
using System.Linq;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Services.Data
{
    public class ClientServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;

        public ClientServices(ShoesDBEntities shoesDataEntities1)
        {
            this._shoesDataEntities = shoesDataEntities1;
        }

        public void InsertClient(string name, String address, byte[] photo)
        {
            var newSeller = new Client { Name = name, Address = address, Photo = photo };
            _shoesDataEntities.Clients.Add(newSeller);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }

        public List<ClientDto> GetAllClients()
        {
            return _shoesDataEntities.Clients
                .Select(s => new ClientDto
                {
                    ClientId = s.Id,
                    Address = s.Address,
                    Name = s.Name,
                    Photo = s.Photo
                }).ToList();
        }

        public bool ExistClientByName(string clientName)
        {
            return _shoesDataEntities.Clients.Any(s => s.Name == clientName);
        }

        public void UpdateClient(ClientDto clientDto)
        {
            var currentClient = FindClientById(clientDto.ClientId);
            if (currentClient == null) return;
            currentClient.Address = clientDto.Address;
            currentClient.Name = clientDto.Name;
            currentClient.Photo = clientDto.Photo;
            SaveChanges();
        }

        private Client FindClientById(int clientId)
        {
            return _shoesDataEntities.Clients.SingleOrDefault(s => s.Id == clientId);
        }

        public void RemoveClient(int clientId)
        {
            var deletedClient = FindClientById(clientId);
            if (deletedClient == null) return;
            _shoesDataEntities.Clients.Remove(deletedClient);
            SaveChanges();
        }
    }
}
