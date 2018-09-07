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
        private readonly ShoesDBEntities _shoesDataEntities;


        public SupplierServices(ShoesDBEntities shoesDataEntities1)
        {
            this._shoesDataEntities = shoesDataEntities1;
        }

        public void InsertSupplier(string name, string address, byte[] photo)
        {
            var newSeller = new Supplier {Name = name, Address = address, Photo = photo};
            _shoesDataEntities.Suppliers.Add(newSeller);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }

        public List<SupplierDto> GetAllSuppliers()
        {
            return _shoesDataEntities.Suppliers
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
            return _shoesDataEntities.Suppliers.Any(s => s.Name == supplierName);
        }

        public void UpdateSupplier(SupplierDto supplierDto)
        {
            var currentSupplier = FindSupplierById(supplierDto.SupplierId);
            if (currentSupplier == null) return;
            currentSupplier.Address = supplierDto.Address;
            currentSupplier.Name = supplierDto.Name;
            currentSupplier.Photo = supplierDto.Photo;
            SaveChanges();
        }

        private Supplier FindSupplierById(int sellerId)
        {
            return _shoesDataEntities.Suppliers.SingleOrDefault(s => s.Id == sellerId);
        }

        public void RemoveSupplier(int supplierId)
        {
            var deletedSupplier = FindSupplierById(supplierId);
            if (deletedSupplier == null) return;
            _shoesDataEntities.Suppliers.Remove(deletedSupplier);
            SaveChanges();
        }
    }
}