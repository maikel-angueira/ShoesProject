using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class ClientServices
    {
        private readonly ShoesDBEntities shoesDataEntities;

        public ClientServices()
        {
            this.shoesDataEntities = new ShoesDBEntities();
        }

        public void InsertClient(string name, String address, byte[] photo)
        {
            var newSeller = new Client { Name = name, Address = address, Photo = photo };
            shoesDataEntities.Clients.Add(newSeller);
            SaveChanges();
        }

        private void SaveChanges()
        {
            shoesDataEntities.SaveChanges();
        }

        public List<ClientDto> GetAllClients()
        {
            return shoesDataEntities.Clients
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
            return shoesDataEntities.Clients.Any(s => s.Name == clientName);
        }

        public void UpdateClient(ClientDto clientDto)
        {
            Client currentClient = FindClientById(clientDto.ClientId);
            if (currentClient != null)
            {
                currentClient.Address = clientDto.Address;
                currentClient.Name = clientDto.Name;
                currentClient.Photo = clientDto.Photo;
                SaveChanges();
            }
        }

        private Client FindClientById(int clientId)
        {
            return shoesDataEntities.Clients.Where(s => s.Id == clientId).SingleOrDefault();
        }

        public void RemoveClient(int clientId)
        {
            var deletedClient = FindClientById(clientId);
            if (deletedClient != null)
            {
                shoesDataEntities.Clients.Remove(deletedClient);
                SaveChanges();
            }
        }
    }
}
