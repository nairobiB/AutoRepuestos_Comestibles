using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AutoRepuestos_Comestibles.Clases
{
    class ClValidaciones
    {

        public void mensajeError(string mensaje)
        {
            string messageBoxText = mensaje;
            string caption = "Campos incompletos";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }

        public void validarLetras(TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
                //MessageBox.Show("SOLO ADMITE LETRAS");

            }

        }
        public bool email(string e)
        {

            if (Regex.IsMatch(e, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*"))
            {
                return true;                
            }
            else
            {
                return false;
            }
                
            //MessageBox.Show("Ingrese un correo valido");

        }

        public void validarNumeros(TextCompositionEventArgs e)
        {
            
            int character = Convert.ToInt32(Convert.ToChar(e.Text));


            if (character >= 48 && character <= 57)
                e.Handled = false;
            else
            {

                e.Handled = true;
  
            }

        }
        public bool ValidarEspaciosEnBlancos(string dato)
        {
            string val = "^[A-Za-z0-9]*$";
            if (Regex.IsMatch(dato, val))
            {
                return true;
            }else
            {
                return false;
            }
            
        }
    }
}