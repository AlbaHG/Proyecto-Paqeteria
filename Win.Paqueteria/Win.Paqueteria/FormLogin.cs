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
    public partial class FormLogin : Form
    {

        private bool _autenticado;
        SegridadBL _seguridad;


        public FormLogin()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            textBox1.Focus();

            _seguridad = new SegridadBL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usuario;
            string contraseña;


            usuario = textBox1.Text;
            contraseña = textBox2.Text;

            button1.Enabled = false;
            button1.Text = "Verificando...";
            Application.DoEvents();

            var resultado = _seguridad.Autorizar(usuario, contraseña);

            if (resultado == true)
            {
                this.Close();
            }
            else
            {
                if (usuario == "user" && contraseña == "456")
                {
                    _autenticado = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña invalida");

                }
            }
        
        
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)

        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.Focus();
        
            }
        }
    }
}





