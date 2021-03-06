﻿using System;
using System.Collections.Generic;
using System.Linq;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Services.Data
{
    public class SellerServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;

        public SellerServices(ShoesDBEntities shoesDataEntities1)
        {
            this._shoesDataEntities = shoesDataEntities1;
        }

        public void InsertSeller(string name, String address, byte[] photo)
        {
            var newSeller = new Seller { Name = name, Address = address, Photo = photo };
            _shoesDataEntities.Sellers.Add(newSeller);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }

        public List<SellerDto> GetAllSellers()
        {
            return _shoesDataEntities.Sellers
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
            return _shoesDataEntities.Sellers.Any(s => s.Name == sellerName);
        }

        public void UpdateSeller(SellerDto sellerDto)
        {
            var currentSeller = FindSellerById(sellerDto.SellerId);
            if (currentSeller == null) return;
            currentSeller.Address = sellerDto.Address;
            currentSeller.Name = sellerDto.Name;
            currentSeller.Photo = sellerDto.Photo;
            SaveChanges();
        }

        private Seller FindSellerById(int sellerId)
        {
            return _shoesDataEntities.Sellers.SingleOrDefault(s => s.Id == sellerId);
        }

        public void RemoveSeller(int sellerId)
        {
            var deletedSeller = FindSellerById(sellerId);
            if (deletedSeller == null) return;
            _shoesDataEntities.Sellers.Remove(deletedSeller);
            SaveChanges();
        }

    }
}
