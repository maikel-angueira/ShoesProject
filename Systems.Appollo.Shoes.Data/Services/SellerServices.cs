using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class SellerServices
    {
        private readonly ShoesDBEntities shoesDataEntities;

        public SellerServices()
        {
            this.shoesDataEntities = new ShoesDBEntities();
        }


        public void InsertSeller(string name, String address, byte[] photo)
        {
            var newSeller = new Seller { Name = name, Address = address, Photo = photo };
            shoesDataEntities.Sellers.Add(newSeller);
            SaveChanges();
        }

        private void SaveChanges()
        {
            shoesDataEntities.SaveChanges();
        }

        public List<SellerDto> GetAllSellers()
        {
            return shoesDataEntities.Sellers
                .Select(s => new SellerDto
                {
                    SellerId = s.Id,
                    Address = s.Address,
                    Name = s.Name,
                    Photo = s.Photo
                }).ToList();
        }

        public bool ExistSellerByName(string sellerName)
        {
            return shoesDataEntities.Sellers.Any(s => s.Name == sellerName);
        }

        public void UpdateSeller(SellerDto sellerDto)
        {
            Seller currentSeller = FindSellerById(sellerDto.SellerId);
            if (currentSeller != null)
            {
                currentSeller.Address = sellerDto.Address;
                currentSeller.Name = sellerDto.Name;
                currentSeller.Photo = sellerDto.Photo;
                SaveChanges();
            }
        }

        private Seller FindSellerById(int sellerId)
        {
            return shoesDataEntities.Sellers.Where(s => s.Id == sellerId).SingleOrDefault();
        }

        public void RemoveSeller(int sellerId)
        {
            var deletedSeller = FindSellerById(sellerId);
            if (deletedSeller != null)
            {
                shoesDataEntities.Sellers.Remove(deletedSeller);
                SaveChanges();
            }
        }

    }
}
