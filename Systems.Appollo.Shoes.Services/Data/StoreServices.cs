using System.Collections.Generic;
using System.Linq;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Services.Data
{
    public class StoreServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;
        

        public StoreServices(ShoesDBEntities shoesDataEntities1)
        {
            this._shoesDataEntities = shoesDataEntities1;
        }

        public void InsertStore(string name, string address, int sellerId)
        {
            var newStore = new Store
            {
                Name = name,
                Address = address,
                SellerId = sellerId
            };

            _shoesDataEntities.Stores.Add(newStore);
            SaveChanges();
        }

        public bool ExistStoreByName(string storeName)
        {
            return _shoesDataEntities.Stores.Any(s => s.Name == storeName);
        }

        private Store FindStoreById(int storeId)
        {
            return _shoesDataEntities.Stores.SingleOrDefault(s => s.Id == storeId);
        }

        public void UpdateStore(StoreDto storeDto)
        {
            var updatedStore = FindStoreById(storeDto.StoreId);
            if (updatedStore == null) return;
            updatedStore.Name = storeDto.Name;
            updatedStore.Address = storeDto.Address;
            updatedStore.SellerId = storeDto.SellerId;
            SaveChanges();
        }

        public List<StoreDto> GetAllStores()
        {
            return _shoesDataEntities.Stores.Select(
                s => new StoreDto
                {
                    StoreId = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                    SellerId = s.SellerId
                }).ToList();
        }

        public void RemoveStore(int storeId)
        {
            var deletedStore = FindStoreById(storeId);
            if (deletedStore == null) return;
            _shoesDataEntities.Stores.Remove(deletedStore);
            SaveChanges();
        }

        private void SaveChanges()
        {
            this._shoesDataEntities.SaveChanges();
        }
    }
}
