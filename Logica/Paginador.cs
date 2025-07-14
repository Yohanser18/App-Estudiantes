using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class Paginador<T>
    {
        private List<T> _dataList;// Lista de datos a paginar
        private Label _label;// Etiqueta para mostrar información de paginación

        private static int maxReg, _reg_por_pagina, pageCount, numPagi = 1;// Variables estáticas para controlar la paginación
        public Paginador(List<T> dataList, Label label, int reg_por_pagina)
        {
            _dataList = dataList;// Inicializa la lista de datos
            _label = label;// Inicializa la etiqueta para mostrar información de paginación
            _reg_por_pagina = reg_por_pagina;// Inicializa el número de registros por página
            CargarDatos();// Carga los datos iniciales
        }

        private void CargarDatos() // Metodo para cargar los datos de la pagina
        {
            numPagi = 1; // Reinicia el número de página a 1
            maxReg = _dataList.Count; // Obtiene el número total de registros
            pageCount = (maxReg / _reg_por_pagina);// Calcula el número total de páginas

            // Calcula el número total de páginas, considerando si hay registros restantes
            if ((maxReg % _reg_por_pagina) > 0)
            {
                pageCount += 1; // Si hay registros restantes, incrementa el número de páginas
            }
            else
            {
                _label.Text = $"Pagina 1/ {pageCount}";// Actualiza la etiqueta con el número de página actual y el total de páginas
            }
        }

        public int primero() // Metodo para ir a la primera pagina
        {
            numPagi = 1; // Establece el número de página a 1
            _label.Text = $"Pagina {numPagi}/ {pageCount}"; // Actualiza la etiqueta con el número de página actual y el total de páginas
            return numPagi; // Retorna el número de página actual
        }

        public int anterior()// Metodo para ir a la pagina anterior
        {
            if (numPagi > 1) // Verifica si no es la primera pagina
            {
                numPagi -= 1; // Decrementa el número de página si no es la primera
                _label.Text = $"Pagina {numPagi}/ {pageCount}"; // Actualiza la etiqueta con el número de página actual y el total de páginas
            }
            return numPagi;
        }

        public int siguente() // Metodo para ir a la pagina siguiente
        {
            if (numPagi == pageCount) numPagi -= 1;// Aqui estamos diciendo que si el numero de pagina es igual al total de tadas la piginas//
            if (numPagi < pageCount)// Verifica si no es la última página
            {
                numPagi += 1;
                _label.Text = $"Pagina {numPagi}/ {pageCount}"; // Actualiza la etiqueta con el número de página actual y el total de páginas
            }
            return numPagi; // Retorna el número de página actual
        }

        public int ultimo() // Metodo para ir a la ultima pagina
        {
            numPagi = pageCount; // Establece el número de página al total de páginas
            _label.Text = $"Pagina {numPagi}/ {pageCount}"; // Actualiza la etiqueta con el número de página actual y el total de páginas
            return numPagi; // Retorna el número de página actual
        }
    }
}
