using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Client.WinForm.Utils
{
    public static class Messages
    {
        public const string ELEMENT_INSERT_SUCESS = "Nuevo {0} insertado correctamente {1}";
        public const string ELEMENT_DELETED_SUCESS = "{0} eliminado correctamente: '{1}'";
        public const string DO_YOU_WANT_TO_DELETED = "¿Estas seguro que quieres borrar el elemento seleccionado: '{0}'?";
        public const string ElEMENT_NAME_REQUIRED = "Nombre del {0} no puede ser vacio";
        public const string ELEMENT_UPDATED_SUCCESS = "{0} actualizado correctamente.";
        public const string ELEMENT_EXISTS = "El elemento existe en la base de datos";
        public const string SELECTED_COLOR_REQUIRED = "Selecciona el color del modelo de zapato";
        public const string SELECTED_MODEL_REQUIRED = "Selecciona el modelo de zapato";
        public const string NEW_PRODUCT_CREATED_SUCESSS = "Nueva entrada al almacén creada correctamente";
        public const string SELECTED_SUPPLIER_REQUIRED = "Selecciona el proveedor de los zapatos";
        public const string STORE_SUPPIER_VALUES_REQUIRED = "Error abasteciendo tienda, falta informacion (Modelo, Color, Numero, Cantidad)";
        public const string SALE_FOR_ClIENT_CREATED_SUCCCESS = "Venta creada correctamente para el cliente: {0}, por un total de venta igual a {1}";
        public const string SALE_FOR_STORE_CREATED_SUCCCESS = "Venta creada correctamente en la tienda: {0}, por un total de venta igual a {1}";
        public const string SALE_CREATED_SUCCCESS = "Venta creada correctamente por un total de venta igual a {0}";
        public const string SALE_PRODUCT_PRICE_EQUAL_CERO = "Estás adicionando un producto con precio de venta igual a 0. Estás seguro de continuar?";
        public const string REMOVE_PRODUCT_FROM_SALE = "Estás seguro de eliminar el producto seleccionado de la Venta?";
        public const string REMOVE_ALL_PRODUCT_FROM_SALE = "Estás seguro de eliminar todos los productos de la Venta?";
        public const string NO_AVAILABLES_MODEL_ON_THE_STORE = "No hay zapatos disponibles en la tienda seleccionada: {0}";
    }
}
