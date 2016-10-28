using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using GestioneSocietaSportiva.View;
using GestioneSocietaSportiva.Model;
using System.Windows.Forms;

namespace GestioneSocietaSportiva.Controller
{
    class SportiviController
    {
        //model e view dello sportivo 
        protected SportiviModel model;
        protected GestioneSportivaHome view;
        protected SportiviForm sportiviForm; 
   

        //costruttore controller sportivo
        public SportiviController(GestioneSportivaHome view)
        {
            this.model = new SportiviModel();
            this.view = view;
            this.sportiviForm = new SportiviForm();

            //inizializzo gli eventi 
            inizializzaEventi();
        }

        public GestioneSportivaHome View
        {
            get { return this.view; }
        }
        public SportiviModel Model
        {
            get { return this.model; }
        }

        public SportiviForm SportiviForm
        {
            get { return this.sportiviForm; }
        }


        public void inizializzaEventi()
        {
            //eventi della vista principale 
            this.view.CreaSportivitiBtn.Click += new System.EventHandler(this.creaSportivo);
            this.view.ModificaSportivibtn.Click += new System.EventHandler(this.modificaSportivo);
            //eventi della form
            this.sportiviForm.AnnullaBtn.Click += new System.EventHandler(this.chiudiForm);
            this.sportiviForm.SalvaBtn.Click += new System.EventHandler(this.salvaForm);
        }

        public void chiudiForm(object sender, EventArgs e)
        {
            this.sportiviForm.Close();
        }

        public void salvaForm(object sender, EventArgs e)
        {
            int id = 0; 
            String nome = this.sportiviForm.NomeTxtBox.Text;
            String cognome = this.sportiviForm.CognomeTxtBox.Text;
            String email = this.sportiviForm.EmailTxtBox.Text;
            String quota = this.sportiviForm.QuotaTxtBox.Text;
            String sesso = this.sportiviForm.MaleRadio.Checked ? "1" : "0";
            DateTime dataNascita = Convert.ToDateTime(this.sportiviForm.DataNascitaPicker.Value.ToShortDateString());
            DateTime dataIscrizione = Convert.ToDateTime(this.sportiviForm.DataIscrizionePicker.Value.ToShortDateString());
            String numeroCellulare = this.sportiviForm.NumeroDiCellulareTxtBox.Text;
            String ruolo = this.sportiviForm.RuoloTxtBox.Text;

            if (this.sportiviForm.SportiviId.Visible)
                id = Convert.ToInt32(this.sportiviForm.SportiviId.Text);

            //chiamo la funzione del modello per aggiungere un nuovo sportivo
            string result = checkValidazione(nome, cognome, email, quota, numeroCellulare, dataNascita, dataIscrizione, sesso, ruolo);
            if (result.Length == 0)
            {
                if (this.sportiviForm.SportiviId.Visible)
                this.model.modificaSportivo(id, nome, cognome, email, quota, numeroCellulare, dataNascita, dataIscrizione, sesso, ruolo);

                else
                    this.model.aggiungiSportivo(nome, cognome, email, quota, numeroCellulare, dataNascita, dataIscrizione, sesso, ruolo);

                this.sportiviForm.Close();
            }
            else
                MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        

        public string checkValidazione(String nome, String cognome, String email, String quota, String numeroCellulare, DateTime dataNascita, DateTime dataIscrizione, String sesso, String ruolo)
        {
            if (nome.Length == 0)
            {
                return "Compilare il campo nome";
            }
            if (cognome.Length == 0)
            {
                return "Compilare il campo cognome";
            }

            if (email.Length == 0)
            {
                return "Compilare il campo email";
            }
            else
            {
                try
                {
                    MailAddress mail = new MailAddress(email);
                }
                catch (FormatException e)
                {
                    return "Formato email non valido";
                }
            }
            if (numeroCellulare.Length == 0)
            {
                return "Compilare il campo Numero di Telefono";
            }
            if (dataNascita.ToString().Length == 0)
            {
                return "Compilare il campo Data di nascita";
            }
            if (dataIscrizione.ToString().Length == 0)
            {
                return "Compilare il campo Data iscrizione";
            }
            if (quota.Length > 0)
            {
                double num;
                bool isNum = double.TryParse(quota, out num);
                if (!isNum)
                    return "Formato quota non valido";
            }
            if (ruolo.Length == 0)
            {
                return "Compilare il campo ruolo";
            }
            return "";

        }

        public void creaSportivo(object sender, EventArgs e)
        {
            this.sportiviForm.NomeTxtBox.Text = "";
            this.sportiviForm.CognomeTxtBox.Text = "";
            this.sportiviForm.DataNascitaPicker.Text = "";
            this.sportiviForm.EmailTxtBox.Text = "";
            this.sportiviForm.NumeroDiCellulareTxtBox.Text = "";
            this.sportiviForm.MaleRadio.Checked = false;
            this.sportiviForm.FemaleRadio.Checked = false;
            this.sportiviForm.QuotaTxtBox.Text = "";
            this.sportiviForm.DataIscrizionePicker.Text = "";
            this.sportiviForm.SportiviIdLbl.Visible = false;
            this.sportiviForm.SportiviId.Visible = false;
            this.sportiviForm.RuoloTxtBox.Text = "";

            this.sportiviForm.ShowDialog();
        }

        public void modificaSportivo(object sender, EventArgs e)
        {
            if (this.view.SportiviGridView.SelectedRows.Count == 1)
            {
                string Id = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                string Nome = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[1].Value.ToString();
                string Cognome = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[2].Value.ToString();
                string DataNascita = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[3].Value.ToString();
                string Email = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[4].Value.ToString();
                string Telefono = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[5].Value.ToString();
                string Sesso = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[6].Value.ToString();
                string Quota = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[7].Value.ToString();
                string DataIscrizione = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[8].Value.ToString();
                string Ruolo = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[9].Value.ToString();

                this.sportiviForm.SportiviId.Visible = true;
                this.sportiviForm.SportiviIdLbl.Visible = true;
                this.sportiviForm.SportiviId.Text = Id;
                this.sportiviForm.NomeTxtBox.Text = Nome;
                this.sportiviForm.CognomeTxtBox.Text = Cognome;
                this.sportiviForm.DataNascitaPicker.Text = DataNascita;
                this.sportiviForm.EmailTxtBox.Text = Email;
                this.sportiviForm.NumeroDiCellulareTxtBox.Text = Telefono;
                this.sportiviForm.RuoloTxtBox.Text = Ruolo; 
                if (Sesso == "Maschio")
                    this.sportiviForm.MaleRadio.Checked = true;
                else
                    this.sportiviForm.FemaleRadio.Checked = true;
                this.sportiviForm.QuotaTxtBox.Text = Quota;
                this.sportiviForm.DataIscrizionePicker.Text = DataIscrizione;
                this.sportiviForm.ShowDialog();

            }
            else
                MessageBox.Show("Seleziona solo una riga!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
