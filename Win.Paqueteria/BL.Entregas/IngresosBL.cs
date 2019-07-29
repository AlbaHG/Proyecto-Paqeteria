using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class IngresosBL
    {
        public BindingList<Ingreso> ListaIngresos { get; set; }

        public IngresosBL()
        {
            ListaIngresos = new BindingList<Ingreso>();

            var ingreso1 = new Ingreso();
            ingreso1.id = 1;
            ingreso1.Nombre = "Juan";
            ingreso1.Descripcion = "Zapatos";
            ingreso1.Precio = 2000;
            ingreso1.Codigo = 123;
            ingreso1.Activo = true;

            ListaIngresos.Add(ingreso1);

            var ingreso2 = new Ingreso();
            ingreso2.id = 2;
            ingreso2.Nombre = "Salma";
            ingreso2.Descripcion = "Telefonos";
            ingreso2.Precio = 3000;
            ingreso2.Codigo = 222;
            ingreso2.Activo = true;

            ListaIngresos.Add(ingreso2);
            
            var ingreso3 = new Ingreso();
            ingreso3.id = 3;
            ingreso3.Nombre = "Selena";
            ingreso3.Descripcion = "Ropa Marca Kalvin";
            ingreso3.Precio = 4000;
            ingreso3.Codigo = 333;
            ingreso3.Activo = true;

            ListaIngresos.Add(ingreso3);

        }
        public BindingList<Ingreso> ObtenerIngresos()
        {
            return ListaIngresos;
        }
    }
    public class Ingreso
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Codigo { get; set; }
        public bool Activo { get; set; }
    }
}
