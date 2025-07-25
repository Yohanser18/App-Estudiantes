﻿using System;
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
        private Estudiantes estudiantes; // Instancia de la clase Estudiantes para usar sus métodos y propiedades

        public Form1()
        {
            InitializeComponent();

            var ListaCampos = new List<TextBox>(); // Lista de controles que se utilizarán para validar los campos del formulario
            ListaCampos.Add(txtNiD); // Agrega el TextBox txtNiD a la lista
            ListaCampos.Add(txtNombre); // Agrega el TextBox txtNombre a la lista
            ListaCampos.Add(txtApellidos); // Agrega el TextBox txtApellidos a la lista
            ListaCampos.Add(txtEmail); // Agrega el TextBox txtEmail a la lista

            var listaLabel = new List<Label>();// Aqui vamos crear una colleccion de label //
            listaLabel.Add(labelNiD);// Agrega el Label labelNiD a la lista
            listaLabel.Add(labelNombre);// Agrega el Label labelNombre a la lista
            listaLabel.Add(labelApellido);// Agrega el Label labelApellido a la lista
            listaLabel.Add(labelEmail);// Agrega el Label labelEmail a la lista
            listaLabel.Add(labelPaginas);// Agrega el Label labelPagina a la lista

            Object[] objects = { pictureImagen, Properties.Resources.images, dataGridView1, numericUpDown1 }; // Inicializa un arreglo de objetos vacío, aunque no se utiliza en este contexto
            estudiantes = new Estudiantes(ListaCampos, listaLabel, objects);//Aqui vamos utilizando los campos del formulario para integralor a la clase estudientes para utilizarlo aqui esta es la logica//
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

        private void btnAgregar_Click(object sender, EventArgs e)// Aqui estamos invacando el evento del boton agregar //
        {
            estudiantes.Registro();// Aqui estamos llamado el metodo que creamos en la clase estudiante que es el que no va a mostrar la validacion del primer campo//
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) // Aqui estamos haciendo el filtrado por en el campo de busqueda
        {
            estudiantes.BuscarEstudiante(txtBuscar.Text);//Aqui estamos pasando el metodo nos hace esa funcion de busqueda
        }

        private void btnPrimero_Click(object sender, EventArgs e)//Este evento del boton primero
        {
            estudiantes.Paginador("Primero");// esto es el metodo que no va a mover ala primera pagina de la lista de estudiantes//
        }

        private void btnAnterior_Click(object sender, EventArgs e)//Este evento del boton anterior
        {
            estudiantes.Paginador("Anterior");// esto es el metodo que no va a mover ala pagina anterior de la lista de estudiantes//
        }

        private void btnSiguiente_Click(object sender, EventArgs e)// Este evento del boton siguiente
        {
            estudiantes.Paginador("Siguiente");// esto es el metodo que no va a mover ala pagina siguiente de la lista de estudiantes//
        }

        private void btnUltimo_Click(object sender, EventArgs e)// Este evento del boton ultimo
        {
            estudiantes.Paginador("Ultimo");// esto es el metodo que no va a mover ala ultima pagina de la lista de estudiantes//
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)// Este evento del NumericUpDown para cambiar el numero de Registro//
        {
            estudiantes.Registro_Paginas();// Aqui estamos llamando el metodo que nos va a cambiar el numero de registro por pagina//
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)// Este evento del DataGridView para manejar el clic en una celda
        {
            if (dataGridView1.Rows.Count != 0 )// Aqui estamos diciendo que si el datagridview contiene datos entra la condicion//
            {
                estudiantes.GetEstudiante();
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)// Este evento del DataGridView para manejar la tecla liberada//
        {
            if (dataGridView1.Rows.Count != 0)// Aqui estamos diciendo que si el datagridview contiene datos entra la condicion//
            {
                estudiantes.GetEstudiante();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)// este metodo es para cancelar cual quier accion que se este realizando en el formulario//
        {
            estudiantes.LimpiarCampos();// Aqui llamos al metodo que nos limpia los campos del formulario y los labels de validacion//
        }

        private void button1_Click(object sender, EventArgs e)//Aqui estaremos haciendo la accion de eliminar //
        {
            estudiantes.Eliminar();// Aqui estamos llamando al metodo que nos elimina el registro del estudiante seleccionado en el DataGridView//
        }
    }
}
