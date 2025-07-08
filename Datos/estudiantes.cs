using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;// es necesario para usar los atributos de mapeo de LinqToDB//

namespace Datos
{
    public class estudiantes
    {
        [PrimaryKey, Identity] // Atributos para indicar que esta propiedad es la clave primaria y se auto-incrementa//
        public int Id { get; set; } // Propiedad para el ID del estudiante
        public string nid { get; set; } // Campo privado para el NiD del estudiante
        public string nombre { get; set; } // Propiedad para el nombre del estudiante
        public string apellido { get; set; }// Propiedad para el apellido del estudiante
        public string email { get; set; } // Propiedad para el email del estudiante
    }
}
