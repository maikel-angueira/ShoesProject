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

        public const string COLOR_NAME_REQUIRED = "Nombre del color no puede ser vacio";
        public const string COLOR_NAME_EXIST = "El color ya existe en la base de datos.";
        public const string COLOR_INSERT_SUCESS = "Nuevo color insertado correctamente {0}";
        public const string COLOR_UPDATED_SUCESS = "El color fue actualizado correctamente";
        public const string COLOR_DELETED_SUCESS = "Color eliminado correctamente: '{0}'";
        public const string DO_YOU_WANT_TO_DELETED = "¿Estas seguro que quieres borrar el color seleccionado: '{0}'?";
        public const string MODEL_NAME_REQUIRED = "Nombre del model no puede ser vacio";
        public const string MODEL_INSERTED_SUCCESS = "Modelo de zapato insertado correctamente.";
    }
}
