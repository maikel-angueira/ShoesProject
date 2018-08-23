using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Data.DataModels
{
    public class ModelDto
    {
        public int ModelId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public byte[] Photo
        {
            get; set;
        }
    }
}
