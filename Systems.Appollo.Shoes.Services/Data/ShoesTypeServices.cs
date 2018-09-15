using System.Collections.Generic;
using System.Linq;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.Dtos;

namespace Systems.Appollo.Shoes.Services.Data
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
            return shoesDataEntities.ShoesTypes
                        .OrderBy(st => st.Type)
                        .Select(sh =>
                                    new ShoesTypeDto
                                    {
                                        Id = sh.Id,
                                        Name = sh.Type,
                                        Description = sh.Description
                                    }).ToList();
        }
    }
}
