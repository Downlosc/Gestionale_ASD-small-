using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using GestioneSocietaSportiva.View;
using GestioneSocietaSportiva.Model;

namespace GestioneSocietaSportiva.Controller
{
    class StampaController
    {
        //inclusione model e view 
        protected StampaModel model;
        protected GestioneSportivaHome view;
        protected StampaForm stampaForm;

        //costruttore
        public StampaController(GestioneSportivaHome view)
        {
            this.model = new StampaModel();
            this.view = view;
            this.stampaForm = new StampaForm();

            //Inizializzo gli eventi 
            inizializzaEventi();
        }

        public GestioneSportivaHome View
        {
            get { return this.view; }
        }

        public StampaModel Model
        {
            get { return this.model; }
        }

        public StampaForm StampaForm
        {
            get { return this.stampaForm; }
            set { this.stampaForm = value; }
        }

        public void inizializzaEventi()
        {
            //eventi della vista principale 
            this.view.CreaStampaBtn.Click += new System.EventHandler(this.creaStampa);
            this.view.ModificaStampabtn.Click += new System.EventHandler(this.modificaStampa);

            //eventi della vista form 
            this.stampaForm.AnnullaBtn.Click += new System.EventHandler(this.chiudiForm);
            this.stampaForm.SalvaBtn.Click += new System.EventHandler(this.salvaForm);
        }

        public void chiudiForm(object sender, EventArgs e)
        {
            this.stampaForm.Close();
        }

        public void salvaForm(object sender, EventArgs e)
        {
            int id = 0; 
            String nome = this.stampaForm.NomeTxtBox.Text;
            String cognome = this.stampaForm.CognomeTxtBox.Text;
            String email = this.stampaForm.EmailTxtBox.Text;
            String sesso = this.stampaForm.MaleRadio.Checked ? "1" : "0";
            DateTime dataNascita = Convert.ToDateTime(this.stampaForm.DataNascitaPicker.Value.ToShortTimeString());
            String numeroCellulare = this.stampaForm.NumeroDiCellulareTxtBox.Text;
            String stipendio = this.stampaForm.StipendioTxtBox.Text;

            if (this.stampaForm.StampaId.Visible)
                id = Convert.ToInt32(this.stampaForm.StampaId.Text);

            //chiamo la funzione del modello per aggiungere un nuovo Stampa
            string result = checkValidazione(nome, cognome, email, numeroCellulare, dataNascita, sesso, stipendio);
            if (result.Length == 0)
            {
                if (this.stampaForm.StampaId.Visible)
                    this.model.modificaStampa(id, nome, cognome, email, numeroCellulare, dataNascita, sesso, stipendio);
                else
                    this.model.aggiungiStampa(nome, cognome, email, numeroCellulare, dataNascita, sesso, stipendio);

                this.stampaForm.Close();
            }
            else
                MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string checkValidazione(String nome, String cognome, String email, String numeroCellulare, DateTime dataNascita,String sesso, String stipendio)
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
            if (stipendio.Length > 0)
            {
                double num;
                bool isNum = double.TryParse(stipendio, out num);
                if (!isNum)
                    return "Formato quota non valido";
            }
            return "";


        }

        public void creaStampa(object sender, EventArgs e)
        {
            this.stampaForm.NomeTxtBox.Text = "";
            this.stampaForm.CognomeTxtBox.Text = "";
            this.stampaForm.DataNascitaPicker.Text = "";
            this.stampaForm.EmailTxtBox.Text = "";
            this.stampaForm.NumeroDiCellulareTxtBox.Text = "";
            this.stampaForm.MaleRadio.Checked = false;
            this.stampaForm.FemaleRadio.Checked = false;
            this.stampaForm.QuotaTxtBox.Text = "";
            this.stampaForm.StampaIdLbl.Visible = false;
            this.stampaForm.StampaId.Visible = false;

            this.stampaForm.ShowDialog();
        }

        public void modificaStampa(object sender, EventArgs e)
        {
            if (this.view.StampaGridView.SelectedRows.Count == 1)
            {
                string Id = this.view.StampaGridView.Rows[this.view.StampaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                string Nome = this.view.StampaGridView.Rows[this.view.StampaGridView.SelectedRows[0].Index].Cells[1].Value.ToString();
                string Cognome = this.view.StampaGridView.Rows[this.view.StampaGridView.SelectedRows[0].Index].Cells[2].Value.ToString();
                string DataNascita = this.view.StampaGridView.Rows[this.view.StampaGridView.SelectedRows[0].Index].Cells[3].Value.ToString();
                string Email = this.view.StampaGridView.Rows[this.view.StampaGridView.SelectedRows[0].Index].Cells[4].Value.ToString();
                string Telefono = this.view.StampaGridView.Rows[this.view.StampaGridView.SelectedRows[0].Index].Cells[5].Value.ToString();
                string Sesso = this.view.StampaGridView.Rows[this.view.StampaGridView.SelectedRows[0].Index].Cells[6].Value.ToString();
                string Stipendio = this.view.StampaGridView.Rows[this.view.StampaGridView.SelectedRows[0].Index].Cells[7].Value.ToString();
               

                this.stampaForm.StampaId.Visible = true;
                this.stampaForm.StampaIdLbl.Visible = true;
                this.stampaForm.StampaId.Text = Id;
                this.stampaForm.NomeTxtBox.Text = Nome;
                this.stampaForm.CognomeTxtBox.Text = Cognome;
                this.stampaForm.DataNascitaPicker.Text = DataNascita;
                this.stampaForm.EmailTxtBox.Text = Email;
                this.stampaForm.NumeroDiCellulareTxtBox.Text = Telefono;
                if (Sesso == "Maschio")
                    this.stampaForm.MaleRadio.Checked = true;
                else
                    this.stampaForm.FemaleRadio.Checked = true;
                this.stampaForm.StipendioTxtBox.Text = Stipendio;
                this.stampaForm.ShowDialog();

            }
            else
                MessageBox.Show("Seleziona solo una riga!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
