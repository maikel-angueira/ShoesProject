using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.DataServices
{
    public class Services
    {
        private readonly ColorServices colorServices;

        public Services()
        {
            this.colorServices = new ColorServices();
        }

        public ColorServices ColorServices
        {
            get
            {
                return this.colorServices;
            }
        }
    }
}
