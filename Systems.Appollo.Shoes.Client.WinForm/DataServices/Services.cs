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
        private readonly ModelServices modelServices;

        public Services()
        {
            this.colorServices = new ColorServices();
            this.modelServices = new ModelServices();
        }

        public ColorServices ColorServices
        {
            get
            {
                return this.colorServices;
            }
        }

        public ModelServices ModelServices
        {
            get
            {
                return this.modelServices;
            }
        }
    }
}
