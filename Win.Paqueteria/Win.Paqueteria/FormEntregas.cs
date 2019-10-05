using BL.Entregas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Paqueteria
{
    public partial class FormEntregas : Form
    {
        EntregasBL _entregas;
        //ClientesBL _clientes;

        public FormEntregas()
        {
            InitializeComponent();

            _entregas = new EntregasBL();
            listaEntregasBindingSource.DataSource = _entregas.ObtenerEntregas();
            
          
            
         
        }
        
       



        private void toolStripTextBoxCancelar_Click(object sender, EventArgs e)
        {
            _entregas.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != " ")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }
        private  void Eliminar(int id)
        {
            var resultado = _entregas.EliminarEntrega(id);

            if (resultado == true)
            {
                listaEntregasBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
           }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar la entrega");
            }
            throw new NotImplementedException();
        }



       

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _entregas.AgregarEntrega();
            listaEntregasBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }
        private void DeshabilitarHabilitarBotones(bool valor)

        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripTextBoxCancelar.Visible = !valor;

        }

        private void entregasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaEntregasBindingSource.EndEdit();
            var entregas = (Entregas)listaEntregasBindingSource.Current;


            var resultado = _entregas.GuardarEntregas(entregas);

            if (resultado.Exitoso == true)
            {
                listaEntregasBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Entrega Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}

       