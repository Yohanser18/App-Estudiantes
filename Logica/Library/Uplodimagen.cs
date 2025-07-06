using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Library
{
    public class Uplodimagen
    {
        private OpenFileDialog fd = new OpenFileDialog();// para abrir el explorador de archivos
        public void CargarImagen(PictureBox pictureBox)// método para cargar la imagen
        {
            pictureBox.WaitOnLoad = true;// para que espere a que se cargue la imagen
            fd.Filter = "Imagenes|*.jpg;*.png;*.gif;*.jpeg";// filtro para mostrar solo imágenes
            fd.ShowDialog();// muestra el diálogo para seleccionar el archivo
            if (fd.FileName != string.Empty)//Aqui estamos verificando si el usuario seleccionó un archivo y que no este vacio
            {
                pictureBox.ImageLocation = fd.FileName;// asigna la ruta de la imagen al PictureBox
            }
        }
    }
}
