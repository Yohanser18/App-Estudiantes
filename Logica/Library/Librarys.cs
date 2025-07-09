using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logica.Library
{
    public class Librarys : Conexion
    {
        public Uplodimagen uplodimagen = new Uplodimagen(); // Instancia de la clase Uplodimagen para usar sus métodos y propiedades//
        public TextBoxEvent textBoxEvent = new TextBoxEvent(); // Instancia de la clase TextBoxEvent para usar sus métodos y propiedades//
    }
}
