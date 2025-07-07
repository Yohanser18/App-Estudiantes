using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica.Library;

namespace Logica
{
    //Aqui estamos utilizando los campos del formulario para integralor a la clase estudientes para utilizarlo aqui esta es la logica//
    public class Estudiantes : Librarys // Clase que hereda de Librarys para usar sus métodos y propiedades
    {
        private List<TextBox> textBoxes; // Lista de TextBox que se utilizarán para validar los campos del formulario

        public Estudiantes(List<TextBox> textBoxes) // Constructor que recibe una lista de TextBox
        {
            this.textBoxes = textBoxes; // Asigna la lista de TextBox a la propiedad de la clase
        }
    }
}
