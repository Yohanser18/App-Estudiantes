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
        private List<TextBox> textBoxes; // Lista de TextBox que se utilizarán para validar los campos del formulario
        private List<Label> listaLabel; // Lista de Label que se utilizarán para mostrar mensajes de validación
        private PictureBox image; // PictureBox para mostrar la imagen del estudiante
       // private Librarys librarys;// Instancia de la clase Librarys para usar sus métodos y propiedades
        public Estudiantes(List<TextBox> textBoxes, List<Label> listaLabel, object[] objects) // Constructor que recibe una lista de TextBox
        {
            this.textBoxes = textBoxes; // Asigna la lista de TextBox a la propiedad de la clase
            this.listaLabel = listaLabel; // Asigna la lista de Label a la propiedad de la clase
            image = (PictureBox)objects[0]; // Asigna el PictureBox del arreglo de objetos a la propiedad de la clase
            //librarys = new Librarys(); // Inicializa la instancia de la clase Librarys
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
                            /* if (textBoxEvent.ComprobarFormatoEmail(textBoxes[3].Text)) // Aquí estamos verificando si el campo Email es válido utilizando un método de la clase TextBoxEvent
                             {
                                 listaLabel[3].Text = "Email valido"; // Mensaje que se mostrara si el campo Email es valido
                                 listaLabel[3].ForeColor = Color.Green; // Cambia el color del texto del Label a verde si el campo Email es válido
                                 // Aquí puedes agregar la lógica para registrar al estudiante, como guardar los datos en una base de datos o en un archivo
                             }
                             else 
                             {
                                 listaLabel[3].Text = "Email no valido"; // Mensaje que se mostrara si el campo Email no es valido
                                 listaLabel[3].ForeColor = Color.Red; // Cambia el color del texto del Label a rojo si el campo Email no es válido
                                 textBoxes[3].Focus(); // Establece el foco en el TextBox de Email para que el usuario pueda corregirlo
                             }*/
                            var imageArrays = uplodimagen.Imagenbytes(image.Image); // Converte la imagen del picturebox a un arreglo de bytes utilizando el método Imagenbytes de la clase Uplodimagen
                            //Esta es una forma de agregar datos a formulario utilizando LinqToDB//
                             db.Insert(new estudiantes() {
                                 nid = textBoxes[0].Text,
                                 nombre = textBoxes[1].Text,
                                 apellido= textBoxes[2].Text,
                                 email = textBoxes[3].Text,
                                 image = imageArrays // Asigna el arreglo de bytes de la imagen al campo imagen del objeto estudiantes
                             });
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
    }
}
