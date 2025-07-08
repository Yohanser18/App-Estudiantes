using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices; // Para usar EmailAddressAttribute

namespace Logica.Library
{
    public class TextBoxEvent
    {
        public void textkeyPress(KeyPressEventArgs ex)// Este es el evento para el TextBox, que se activa cuando se presiona una tecla de tipo texto//
        {
            //Condicion que solo nos permite ingresar letras al TextBox//
            if (char.IsLetter(ex.KeyChar)) {ex.Handled = false; } // Esta es la validacion que estamos haciendo para el proceso//
            else if (ex.KeyChar == Convert.ToChar(Keys.Enter)) { ex.Handled = true; } // Condicion que pemite no dar salto de linea al presionar la tecla Enter//
            else if (char.IsControl(ex.KeyChar)) { ex.Handled = false; } // Condicion que nos permite utilizar la tecla backspace//
            else if (char.IsSeparator(ex.KeyChar)) {ex.Handled = false; }// Codicion que nos permite utilizar la tecla de espacio//
            else { ex.Handled = true; } // Si no se cumple ninguna de las condiciones anteriores, se bloquea la tecla presionada

        }

        public  void numberkeyPress(KeyPressEventArgs ex) // Este es el evento para el TextBox, que se activa cuando se presiona una tecla de tipo numero//
        {
            //Condicion que solo nos permite ingresar numeros al TextBox//
            if (char.IsDigit(ex.KeyChar)) { ex.Handled = false; }// Esta es la validacion que estamos haciendo para el proceso//
            else if (ex.KeyChar == Convert.ToChar(Keys.Enter)) { ex.Handled = true; }// Aqui estamos diciendo que perimita que utilizar la tecla enter //
            else if (char.IsLetter(ex.KeyChar)) { ex.Handled = true; } // Condicion que nos permite bloquear el ingreso de letras al TextBox//
            else if (char.IsControl(ex.KeyChar)) { ex.Handled = false; }// Condicion que nos permite utilizar la tecla backspace//
            else if (char.IsSeparator(ex.KeyChar)) { ex.Handled = false; } // Condicion que nos permite utilizar la tecla de espacio//
            else { ex.Handled = true; } // Si no se cumple ninguna de las condiciones anteriores, se bloquea la tecla presionada//
        }

        /*public bool ComprobarFormatoEmail(string email) // Aqui vamas comentar esta funcion porque no la vamos a utilizar por el momento//
        { 
           return new EmailAddressAttribute().Equals(email);
            // Utiliza EmailAddressAttribute para validar el formato del email
        }*/
    }
}
