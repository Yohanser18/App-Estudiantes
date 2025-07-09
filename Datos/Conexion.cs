using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using LinqToDB;
using LinqToDB.Data; // Asegúrate de tener la referencia a LinqToDB.Data en tu proyecto//

namespace Data
{
    public class Conexion : DataConnection
    {
        //Aqui es donde vamos a crear la conexion a la base de datos//
        public Conexion() : base("conexion")
        {

        }

        //Aqui estaremos creando una propiedad para acceder a la base de datos y el mapeo de la misma con los modelos//
        public ITable<estudiantes> _estudiantes  { get { return GetTable<estudiantes>(); } }

        //Este método es para obtener la tabla de estudiantes desde la base de datos//
        private ITable<T> GetTable<T>()
        {
            throw new NotImplementedException();
        }
    }
}

