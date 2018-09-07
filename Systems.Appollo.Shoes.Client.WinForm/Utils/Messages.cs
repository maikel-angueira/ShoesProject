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
        public const string ELEMENT_INSERT_SUCESS = "Nuevo {0} insertado correctamente {1}";
        public const string ELEMENT_DELETED_SUCESS = "{0} eliminado correctamente: '{1}'";
        public const string DO_YOU_WANT_TO_DELETED = "¿Estas seguro que quieres borrar el elemento seleccionado: '{0}'?";
        public const string ElEMENT_NAME_REQUIRED = "Nombre del {0} no puede ser vacio";
        public const string ELEMENT_UPDATED_SUCCESS = "{0} actualizado correctamente.";
        public const string ELEMENT_EXISTS = "El elemento seleccionado ya exist en la base de datos";
        public const string SELECTED_COLOR_REQUIRED = "Selecciona el color del modelo de zapato";
        public const string SELECTED_MODEL_REQUIRED = "Selecciona el modelo de zapato";
        public const string NEW_PRODUCT_CREATED_SUCESSS = "Nueva entrada al almacén creada correctamente";
        public const string SELECTED_SUPPLIER_REQUIRED = "Selecciona el proveedor de los zapatos";
    }
}
