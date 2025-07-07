using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace App_Estudiantes
{
    public partial class Form1 : Form
    {
        private Estudiantes estudiantes = new Estudiantes(); // Instancia de la clase Estudiantes para usar sus métodos y propiedades

        public Form1()
        {
            InitializeComponent();

            var ListaCampos = new List<TextBox>(); // Lista de controles que se utilizarán para validar los campos del formulario
            ListaCampos.Add(txtNiD); // Agrega el TextBox txtNiD a la lista
            ListaCampos.Add(txtNombre); // Agrega el TextBox txtNombre a la lista
            ListaCampos.Add(txtApellidos); // Agrega el TextBox txtApellidos a la lista
            ListaCampos.Add(txtEmail); // Agrega el TextBox txtEmail a la lista
        }

        private void pictureImagen_Click(object sender, EventArgs e) // Este es el evento para cargar la imagen//
        {
            estudiantes.uplodimagen.CargarImagen(pictureImagen); // Llama al método CargarImagen de la clase Estudiantes, que hereda de Uplodimagen
        }

        private void txtNiD_TextChanged(object sender, EventArgs e) // Este es el evento para el TextBox txtNiD, que se activa cuando el texto cambia
        {
            //Aqui estaremos validando el texto del TextBox txtNiD si es necesario//
            if (txtNiD.Text == "")// Aqui estamos diciendo que si el campo de texto esta vacio que no muestre un lor rojo//
            {
                labelNiD.ForeColor = Color.Red;
            }
            else
            {
                labelNiD.ForeColor = Color.Green;
                labelNiD.Text = "NiD";
            }
        }

        private void txtNiD_KeyPress(object sender, KeyPressEventArgs e)// Este es el evento para el TextBox txtNiD, que se activa cuando se presiona una tecla
        {
            // Aquí puedes agregar lógica para validar la entrada del usuario si es necesario
            estudiantes.textBoxEvent.numberkeyPress(e); // Llama al método numberkeyPress de la clase TextBoxEvent para validar la entrada del usuario
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)// Este es el evento para el TextBox txtNombre, que se activa cuando el texto cambia
        {
            // Aqui estaremos validando el texto del TextBox txtNombre si es necesario//
            if (txtNombre.Text == "")
            {
                labelNombre.ForeColor = Color.Red;
            }
            else
            {
                labelNombre.ForeColor = Color.Green;
                labelNombre.Text = "Nombre";
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)// Este es el evento para el TextBox txtNombre, que se activa cuando se presiona una tecla
        {
            // Aquí puedes agregar lógica para validar la entrada del usuario si es necesario
            estudiantes.textBoxEvent.textkeyPress(e); // Llama al método textkeyPress de la clase TextBoxEvent para validar la entrada del usuario
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)// Este es el evento para el TextBox txtApellidos, que se activa cuando el texto cambia
        {
            // Aqui estaremos validando el texto del TextBox txtApellidos si es necesario//
            if (txtApellidos.Text == "") // Aqui estamos diciendo que si el campo de texto esta vacio que no muestre un lor rojo//
            {
               labelApellido.ForeColor = Color.Red;
            }
            else
            {
               labelApellido.ForeColor = Color.Green;
               labelApellido.Text = "Apellidos"; // Cambia el texto del label a "Apellidos" si el campo no está vacío
            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)// Este es el evento para el TextBox txtApellidos, que se activa cuando se presiona una tecla
        {
            // Aquí puedes agregar lógica para validar la entrada del usuario si es necesario
            estudiantes.textBoxEvent.textkeyPress(e); // Llama al método textkeyPress de la clase TextBoxEvent para validar la entrada del usuario
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)//método para el evento TextChanged del TextBox txtEmail
        {
            // Aqui estaremos validando el texto del TextBox txtEmail si es necesario//
            if (txtEmail.Text == "") // Aqui estamos diciendo que si el campo de texto esta vacio que no muestre un lor rojo//
            {
                labelEmail.ForeColor = Color.Red;
            }
            else
            {
                labelEmail.ForeColor = Color.Green;
                labelEmail.Text = "Email"; // Cambia el texto del label a "Email" si el campo no está vacío
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)// método para el evento KeyPress del TextBox txtEmail
        {

        }
    }
}
