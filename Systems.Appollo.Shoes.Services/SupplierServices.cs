using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class SupplierServices
    {
        private readonly ShoesDBEntities shoesDataEntities;
        

        public SupplierServices(ShoesDBEntities shoesDataEntities1)
        {
            this.shoesDataEntities = shoesDataEntities1;
        }

        public void InsertSupplier(string name, String address, byte[] photo)
        {
            var newSeller = new Supplier { Name = name, Address = address, Photo = photo };
            shoesDataEntities.Suppliers.Add(newSeller);
            SaveChanges();
        }

        private void SaveChanges()
        {
            shoesDataEntities.SaveChanges();
        }

        public List<SupplierDto> GetAllSuppliers()
        {
            return shoesDataEntities.Suppliers
                .Select(s => new SupplierDto
                {
                    SupplierId = s.Id,
                    Address = s.Address,
                    Name = s.Name,
                    Photo = s.Photo
                }).ToList();
        }

        public bool ExistSupplierByName(string supplierName)
        {
            return shoesDataEntities.Suppliers.Any(s => s.Name == supplierName);
        }

        public void UpdateSupplier(SupplierDto supplierDto)
        {
            Supplier currentSupplier = FindSupplierById(supplierDto.SupplierId);
            if (currentSupplier != null)
            {
                currentSupplier.Address = supplierDto.Address;
                currentSupplier.Name = supplierDto.Name;
                currentSupplier.Photo = supplierDto.Photo;
                SaveChanges();
            }
        }

        private Supplier FindSupplierById(int sellerId)
        {
            return shoesDataEntities.Suppliers.Where(s => s.Id == sellerId).SingleOrDefault();
        }

        public void RemoveSupplier(int supplierId)
        {
            var deletedSupplier = FindSupplierById(supplierId);
            if (deletedSupplier != null)
            {
                shoesDataEntities.Suppliers.Remove(deletedSupplier);
                SaveChanges();
            }
        }
    }
}
