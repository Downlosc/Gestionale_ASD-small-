using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GestioneSocietaSportiva.Classi;
using GestioneSocietaSportiva.Model;

namespace GestioneSocietaSportiva.Helper
{

    //Classe per resettare i campi modificabili nella form
    public static class FormHelper
    {
        //metodo per il reset
        public static void ResetForm(Control.ControlCollection controlForm)
        {
            //scorro tutti i controlli nella form 
            foreach (Control control in controlForm)
            {
                //reset del textbox
                TextBox tb = control as TextBox;
                if (tb != null)
                    tb.Text = "";
                else
                    ResetForm(control.Controls);
                
                //reset del datatimepicker
                if (control is DateTimePicker)
                {
                    DateTimePicker dtp = control as DateTimePicker;
                    dtp.Value = DateTime.Now;
                } 
            }
        }

        public static string[] ValidazioneCampi(TextBox nome, TextBox cognome, TextBox email, TextBox telefono)
        {
            //creo un array temporaneo
            string[] textRitorno = new string[5];

            //controllo se il campo nome è vuoto
            if (nome.Text.Trim() != "")
                //sostituisco i caratteri di escape
                textRitorno[0] = nome.Text.Replace("'", "'").Trim();
            else
                textRitorno[0] = "Empty";

            //controllo se il campo cognome è vuoto
            if (cognome.Text.Trim() != "")
                //sostituisco i caratteri di escape
                textRitorno[1] = cognome.Text.Replace("'", "'").Trim();
            else
                textRitorno[1] = "Empty";

            //controllo se il campo email è vuoto
            if (email.Text.Trim() != "")
                //sostituisco i caratteri di escape
                textRitorno[2] = email.Text.Replace("'", "'").Trim();
            else
                textRitorno[2] = "Empty";

            //controllo se il campo telefono è vuoto
            if (telefono.Text.Trim() != "")
                //sostituisco i caratteri di escape
                textRitorno[3] = telefono.Text.Replace("'", "'").Trim();
            else
                textRitorno[3] = "Empty";

            return textRitorno;
        }
    }
}
