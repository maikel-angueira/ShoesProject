using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class StoreServices
    {
        private readonly ShoesDBEntities shoesDataEntities;

        public StoreServices()
        {
            this.shoesDataEntities = new ShoesDBEntities();
        }

        public void InsertStore(string name, string address, int sellerId)
        {
            var newStore = new Store
            {
                Name = name,
                Address = address,
                SellerId = sellerId
            };

            shoesDataEntities.Stores.Add(newStore);
            SaveChanges();
        }

        public bool ExistStoreByName(string storeName)
        {
            return shoesDataEntities.Stores.Any(s => s.Name == storeName);
        }

        public Store FindStoreById(int storeId)
        {
            return shoesDataEntities.Stores.Where(s => s.Id == storeId).SingleOrDefault();
        }

        public void UpdateStore(StoreDto storeDto)
        {
            var updatedStore = FindStoreById(storeDto.StoreId);
            if (updatedStore != null)
            {
                updatedStore.Name = storeDto.Name;
                updatedStore.Address = storeDto.Address;
                updatedStore.SellerId = storeDto.SellerId;
                SaveChanges();
            }
        }

        public List<StoreDto> GetAllStores()
        {
            return shoesDataEntities.Stores.Select(
                s => new StoreDto
                {
                    StoreId = s.Id,
                    Name = s.Name,
                    Address = s.Name,
                    SellerId = s.SellerId
                }).ToList();
        }

        public void RemoveStore(int storeId)
        {
            var deletedStore = FindStoreById(storeId);
            if (deletedStore != null)
            {
                shoesDataEntities.Stores.Remove(deletedStore);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            this.shoesDataEntities.SaveChanges();
        }
    }
}
