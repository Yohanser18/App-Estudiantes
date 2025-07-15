using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public byte[] Imagenbytes(Image img) //Aqui estaemos utilizado este metodo para poder convertir la imagen a un arreglo de bytes para poder guardarla en una base de datos o en un archivo//
        { 
            var convertir = new ImageConverter();// Creamos una instancia de la clase ImageConverter
            return (byte[])convertir.ConvertTo(img, typeof(byte[])); // Convertimos la imagen a un arreglo de bytes y lo retornamos
        }

        public Image byteArrayToImage(byte[] byteArrayIn)// Este metodo lo que hace es convertir un arreglo de bytes a una imagen//
        {
            MemoryStream ms = new MemoryStream(byteArrayIn); // Creamos un MemoryStream a partir del arreglo de bytes
            Image returnImage = Image.FromStream(ms); // Creamos una imagen a partir del MemoryStream
            return returnImage; // Retornamos la imagen creada
        }
    }
}
