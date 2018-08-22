using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Client.WinForm.Utils
{
    public class Messages
    {
        private Messages() { }

        public const string COLOR_NAME_EMPTY = "Nombre del color no puede ser vacio";
        public const string COLOR_NAME_EXIST = "El color ya existe en la base de datos.";
        public const string COLOR_INSERT_SUCESS = "Nuevo color insertado correctamente {0}";
        public const string COLOR_UPDATED_SUCESS = "El color fue actualizado correctamente";
    }
}
