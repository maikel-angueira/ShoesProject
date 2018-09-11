using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.Dtos;

namespace Systems.Appollo.Shoes.Services
{
    public class ShoesTypeServices
    {
        private readonly ShoesDBEntities shoesDataEntities;

        public ShoesTypeServices(ShoesDBEntities shoesDataEntities)
        {
            this.shoesDataEntities = shoesDataEntities;
        }

        public List<ShoesTypeDto> GetAllShoesType()
        {
            return shoesDataEntities.ShoesTypes.Select(sh =>
                    new ShoesTypeDto
                    {
                        Id = sh.Id,
                        Name = sh.Type,
                        Description = sh.Description
                    }).ToList();
        }
    }
}
