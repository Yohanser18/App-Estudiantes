using System;
using System.Collections.Generic;
using System.Drawing;// Para usar el tipo Color
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Datos;
using LinqToDB;
using Logica.Library;

namespace Logica
{
    //Aqui estamos utilizando los campos del formulario para integralor a la clase estudientes para utilizarlo aqui esta es la logica//
    public class Estudiantes : Librarys // Clase que hereda de Librarys para usar sus métodos y propiedades
    {
        Conexion db = new Conexion(); // Instancia de la clase Conexion para interactuar con la base de datos
        private int _reg_por_pagina = 2, _num_pagina = 1; // Variables para la paginación, donde _reg_por_pagina es el número de registros por página y _num_pagina es el número de la página actual
        private List<estudiantes> listaestudiante; // Lista de estudiantes que se utilizará para almacenar los datos de los estudiantes obtenidos de la base de datos

        private List<TextBox> textBoxes; // Lista de TextBox que se utilizarán para validar los campos del formulario
        private List<Label> listaLabel; // Lista de Label que se utilizarán para mostrar mensajes de validación
        private PictureBox image; // PictureBox para mostrar la imagen del estudiante
        private Bitmap _imagBitmap; // Bitmap para almacenar la imagen del estudiante
        private DataGridView _dataGridView; // DataGridView para mostrar la lista de estudiantes (aunque no se utiliza en este contexto)
        private NumericUpDown _numericUpDown; // NumericUpDown para la paginación (aunque no se utiliza en este contexto)
        private Paginador<estudiantes> _paginador; // Instancia de la clase Paginador para manejar la paginación de estudiantes

        public Estudiantes(List<TextBox> textBoxes, List<Label> listaLabel, object[] objects) // Constructor que recibe una lista de TextBox
        {
            this.textBoxes = textBoxes; // Asigna la lista de TextBox a la propiedad de la clase
            this.listaLabel = listaLabel; // Asigna la lista de Label a la propiedad de la clase
            image = (PictureBox)objects[0]; // Asigna el PictureBox del arreglo de objetos a la propiedad de la clase
           _imagBitmap = (Bitmap)objects[1];//Aqui estamos asignando la imagen por defecto al Bitmap //
           _dataGridView = (DataGridView)objects[2]; // Asigna el DataGridView del arreglo de objetos a la propiedad de la clase
           _numericUpDown = (NumericUpDown)objects[3]; // Asigna el NumericUpDown del arreglo de objetos a la propiedad de la clase
            LimpiarCampos(); // Llama al método LimpiarCampos para limpiar los campos del formulario al iniciar la clase
        }

        public void Registro() // Método para validar los campos del formulario antes de registrar un estudiante
        {
            if (textBoxes[0].Text == "")// Aqui estamos diciendo que si el campo esta vacio que muestre un mensaje que diga el campo es obligatorio// //
            {
                listaLabel[0].Text = "NiD es requerido";//este es el mensaje que va presentar//
                listaLabel[0].ForeColor = Color.Red; // Cambia el color del texto del Label a rojo si el campo NiD está vacío
                textBoxes[0].Focus();//Esto es para que que sepamos el campo cual le estamos espicificando//
            }
            else
            {
                if (textBoxes[1].Text == "")// Aquí estamos verificando si el campo de Nombre está vacío
                {
                    listaLabel[1].Text = "Nombre es requerido"; // Mensaje que se mostrará si el campo Nombre está vacío
                    listaLabel[1].ForeColor = Color.Red; // Cambia el color del texto del Label a rojo si el campo Nombre está vacío
                    textBoxes[1].Focus(); // Establece el foco en el TextBox de Nombre para que el usuario pueda corregirlo
                }
                else
                {
                    if (textBoxes[2].Text == "")// Aquí estamos verificando si el campo de Apellidos está vacío
                    {
                        listaLabel[2].Text = "Apellidos es requerido"; // Mensaje que se mostrará si el campo Apellidos está vacío
                        listaLabel[2].ForeColor = Color.Red; // Cambia el color del texto del Label a rojo si el campo Apellidos está vacío
                        textBoxes[2].Focus(); // Establece el foco en el TextBox de Apellidos para que el usuario pueda corregirlo
                    }
                    else
                    {
                        if (textBoxes[3].Text == "")// Aquí estamos verificando si el campo de Email está vacío
                        {
                            listaLabel[3].Text = "Email es requerido"; // Mensaje que se mostrara si el campo Email esta vacio
                            listaLabel[3].ForeColor = Color.Red; // Cambia el color del texto del Label a rojo si el campo Email está vacío
                            textBoxes[3].Focus(); // Establece el foco en el TextBox de Email para que el usuario pueda corregirlo
                        }
                        else
                        {
                             if (textBoxEvent.ComprobarFormatoEmail(textBoxes[3].Text)) // Aquí estamos verificando si el campo Email es válido utilizando un método de la clase TextBoxEvent
                             {
                                  var usuario = db.GetTable<estudiantes>().Where(e => e.email == textBoxes[3].Text).ToList(); // Busca un estudiante en la base de datos por su email utilizando LinqToDB
                                     if (usuario.Count() == 0)
                                     {
                                         Guadar(); // Si el estudiante no existe, llama al método Guadar para guardar los datos del estudiante en la base de datos
                                     }
                                     else 
                                     {
                                          listaLabel[3].Text = "Ya este email heciste"; // Si el estudiante ya existe, muestra un mensaje de error en el TextBox de Email
                                          listaLabel[3].ForeColor = Color.Red; // Cambia el color del texto del Label a rojo si el email ya existe
                                          textBoxes[3].Focus(); // Establece el foco en el TextBox de Email para que el usuario pueda corregirlo
                                     }
                             }
                             else 
                             {
                                 listaLabel[3].Text = "Email no valido"; // Mensaje que se mostrara si el campo Email no es valido
                                 listaLabel[3].ForeColor = Color.Red; // Cambia el color del texto del Label a rojo si el campo Email no es válido
                                 textBoxes[3].Focus(); // Establece el foco en el TextBox de Email para que el usuario pueda corregirlo
                             }

                            /*_estudiantes.Value(e => e.nid, textBoxes[0].Text)
                            .Value(e => e.nombre, textBoxes[1].Text)
                            .Value(e => e.apellido, textBoxes[2].Text)
                            .Value(e => e.email, textBoxes[3].Text)
                            .Insert();*/
                        }
                    }
                }
            }
        }

        private void Guadar()// Aqui estamos guardando los datos del estudiante en la base de datos utilizando LinqToDB//
        {
            BeginTransactionAsync(); // Inicia una transacción asíncrona para realizar operaciones en la base de datos
            try
            {
                var imageArrays = uplodimagen.Imagenbytes(image.Image); // Converte la imagen del picturebox a un arreglo de bytes utilizando el método Imagenbytes de la clase Uplodimagen
               //Esta es una forma de agregar datos a formulario utilizando LinqToDB//
                db.Insert(new estudiantes()
                {
                    nid = textBoxes[0].Text,
                    nombre = textBoxes[1].Text,
                    apellido = textBoxes[2].Text,
                    email = textBoxes[3].Text,
                    image = imageArrays // Asigna el arreglo de bytes de la imagen al campo imagen del objeto estudiantes
                });

                CommitTransaction(); // Confirma la transacción asíncrona si todo sale bien
                LimpiarCampos(); // Llama al método LimpiarCampos para limpiar los campos del formulario después de guardar los datos
            }
            catch (Exception)
            {

                RollbackTransaction(); // Revierte la transacción asíncrona si ocurre un error
            }  
        }

        
        public void BuscarEstudiante(string campo)
        {
            List<estudiantes> query = new List<estudiantes>();// Creamos una lista de estudiantes para almacenar los resultados de la búsqueda
            int inicio = (_num_pagina - 1) * _reg_por_pagina; //Esto es nuestro paginador //
            if (campo == "")// Aqui estamos diciendo que si la varieble campos esta vacia ella no va entrar en la condicion//
            {
                query = db.GetTable<estudiantes>().ToList();// Obtiene todos los estudiantes de la base de datos y los almacena en la lista query
            }
            else
            {
                // Aqui estamos diciendo que si la varieble campo no esta vacia ella va entrar en la condicion//
                query = db.GetTable<estudiantes>().Where(e => e.nid.StartsWith(campo) || 
                e.nombre.StartsWith(campo) || e.apellido.StartsWith(campo)).ToList();

            }

            if (0 < query.Count)// Aqui vamos a mostrar los datos en le dataGridView //
            {
                _dataGridView.DataSource = query.Select(q => new {
                    q.Id, 
                    q.nid,
                    q.nombre,
                    q.apellido,
                    q.email
                }).Skip(inicio).Take(_reg_por_pagina).ToList();

                _dataGridView.Columns[0].Visible = false; // Oculta la columna Id en el DataGridView

                _dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke; // Cambia el color de fondo de la columna NiD a blanco humo
                _dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke; // Cambia el color de fondo de la columna Email a blanco humo
            }
            else
            {

                _dataGridView.DataSource = query.Select(q => new {
                    q.nid,
                    q.nombre,
                    q.apellido,
                    q.email
                }).ToList();// Aqui el datagridview mostrara una lista con los datos que pidamos si la condicion de arriba no se comple
            }
        }

        public void Paginador(string metodo)
        {
            switch (metodo)
            {
                case "Primero":
                  _num_pagina = _paginador.primero();
                    break;
                case "Anterior":
                    _num_pagina = _paginador.anterior();
                    break;
                case "Siguiente":
                    _num_pagina = _paginador.siguiente();
                    break;
                case "Ultimo":
                    _num_pagina = _paginador.ultimo();
                    break;
            }
            BuscarEstudiante(""); // Llama al método BuscarEstudiante para actualizar la lista de estudiantes mostrada en el DataGridView
        }

        private void LimpiarCampos()//Aqui vamos a limpiar los campos de texto cuando le demos al boton de agragar//
        {
            image.Image = _imagBitmap; // Asigna la imagen por defecto al PictureBox
            //Aqui vamos a limpiar los campos de texto cuando le demos al boton de agragar//
            listaLabel[0].Text = "NiD";
            listaLabel[1].Text = "Nombre";
            listaLabel[2].Text = "Apellidos";
            listaLabel[3].Text = "Email";
            //Aqui vamos agregar colores a los labels cuando limpiemos los campos//
            listaLabel[0].ForeColor = Color.LightSlateGray;
            listaLabel[1].ForeColor = Color.LightSlateGray;
            listaLabel[2].ForeColor = Color.LightSlateGray;
            listaLabel[3].ForeColor = Color.LightSlateGray;
            //Limpiamos los campos de texto//
            textBoxes[0].Text = "";
            textBoxes[1].Text = "";
            textBoxes[2].Text = "";
            textBoxes[3].Text = "";
            // Obtiene todos los estudiantes de la base de datos y los almacena en la lista listaestodiante
            listaestudiante = db.GetTable<estudiantes>().ToList();
            if (0 < listaestudiante.Count)
            {
                _paginador = new Paginador<estudiantes>(listaestudiante, 
                    listaLabel[4],
                    _reg_por_pagina);// Aquí estamos creando una nueva instancia de Paginador con la lista de estudiantes, la etiqueta para mostrar la paginación y el número de registros por página
            }
            //Aqui estamos llamado el  DataGridView y limpiado tambien//
            BuscarEstudiante(""); // Llama al método BuscarEtudiante con un campo vacío para mostrar todos los estudiantes en el DataGridView
        }
    }  
}
