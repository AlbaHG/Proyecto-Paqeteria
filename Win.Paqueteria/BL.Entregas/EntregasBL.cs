using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class EntregasBL
    {
        Contexto _contexto;

        public BindingList<Entregas> ListaEntregas { get; set; }

        public EntregasBL()
        {
            _contexto = new Contexto();
            ListaEntregas = new BindingList<Entregas>();

        }
        public BindingList<Entregas> ObtenerEntregas()
        {
            _contexto.ingreso.Load();
            ListaEntregas = _contexto.Entregas.Local.ToBindingList();

            return ListaEntregas;
        }
        public BindingList<Entregas> ObtenerIngresos()
        {
            _contexto.Entregas.Load();
            ListaEntregas = _contexto.Entregas.Local.ToBindingList();

            return ListaEntregas;
        }

        //public void AgregarEntrega()
        //{
        //    var nuevaEntrega = new Entregas();
        //  _contexto.Entregas.Add(nuevaEntrega);
        //}




       // public bool EliminarEntrega(int id)
       // {

         //   foreach (var entrega in ListaEntregas.ToList())
           // {
             //   if (entrega.id == id)
               // {
                 //   ListaEntregas.Remove(entrega);
                   // _contexto.SaveChanges();
                   //
                    //return true; 

                //}
            //}

            //return false;
        //}
        private Resultado Validar(Entregas entregas)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (entregas == null)
            {

                resultado.Mensaje = "Agregue un producto valido";
                resultado.Exitoso = false;

                return resultado;
            }


            if (String.IsNullOrEmpty(entregas.Direccion) == true)
            {
                resultado.Mensaje = "Ingrese una Direccion";
                resultado.Exitoso = false;
            }
            return resultado;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        public Resultado GuardarEntregas(Entregas entregas)
        {
            var resultado = Validar(entregas);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarEntrega()
        {
            var nuevaentrega = new Entregas();
            //_contexto.Entregas.Add(nuevaentrega);
            // ListaEntregas.Add(nuevaentrega);
        }
        public bool EliminarEntrega(int codigo)
        {
            //foreach (var ingreso in ListaIngresos)
            foreach (var entrega in ListaEntregas.ToList())
            {
                if (entrega.id == codigo)
                {
                    ListaEntregas.Remove(entrega);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }


    public class Entregas
    {
        public int id { get; set; }
        public string Nombre { get; set; }
       // public int Id { get; set; }
        public string Direccion { get; set; }
        public double Precio { get; set; }
        public int Codigo { get; set; }
        public bool Activo { get; set; }


        public Entregas()
        {
            Activo = true;
        }

        public class Resultado
        {
            public bool Exitoso { get; set; }
            public string Mensaje { get; set; }
        }

    }
}