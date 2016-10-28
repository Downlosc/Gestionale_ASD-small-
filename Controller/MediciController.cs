using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestioneSocietaSportiva.View;
using GestioneSocietaSportiva.Model;

namespace GestioneSocietaSportiva.Controller
{
    class MediciController
    {
        //inclusione model e view controller
        protected MediciModel model;
        protected GestioneSportivaHome view;
        protected MediciForm mediciForm; 

        //costruttore del controller
        public MediciController(GestioneSportivaHome view)
        {
            this.model = new MediciModel();
            this.view = view;
            this.mediciForm = new MediciForm();

            //inizializzo gli eventi 
            inizializzaEventi();
        }

        public MediciModel Model
        {
            get { return this.model; }
        }

        public MediciForm MediciForm
        {
            get { return this.mediciForm; }
        }

        public GestioneSportivaHome View
        {
            get { return this.view; }
        }

        public void inizializzaEventi()
        {
            //eventi della vista principale (GestioneSportivaHome) 
            this.view.CreaMediciBtn.Click += new System.EventHandler(this.creaMedico);
            this.view.ModificaMedicibtn.Click += new System.EventHandler(this.modificaMedico);
            //eventi della vista fortm
            this.mediciForm.AnnullaBtn.Click += new System.EventHandler(this.chiudiForm);
            this.mediciForm.SalvaBtn.Click += new System.EventHandler(this.salvaForm);

        }

        public void chiudiForm(object sender, EventArgs e)
        {
            this.mediciForm.Close();
        }

        public void salvaForm(object sender, EventArgs e)
        {
            int id = 0; 
            String nome = this.mediciForm.NomeTxtBox.Text;
            String cognome = this.mediciForm.CognomeTxtBox.Text;
            String email = this.mediciForm.EmailTxtBox.Text;
            String sesso = this.mediciForm.MaleRadio.Checked ? "1" : "0";
            DateTime dataNascita = Convert.ToDateTime(this.mediciForm.DataNascitaPicker.Value.ToShortDateString());
            String numeroCellulare = this.mediciForm.NumeroDiCellulareTxtBox.Text;
            String stipendio = this.mediciForm.StipendioTxtBox.Text;
            String specializzazione = this.mediciForm.SpecializzazioneTxtBox.Text;

            if (this.mediciForm.MediciId.Visible)
                id = Convert.ToInt32(this.mediciForm.MediciId.Text);
            //chiamo la funzione del modello per aggiungere un nuovo Medico
            string result = checkValidazione(nome, cognome, email,numeroCellulare, dataNascita, sesso, stipendio, specializzazione);
            if (result.Length == 0)
            {
                if (this.mediciForm.MediciId.Visible)
                    this.model.modificaMedici(id, nome, cognome, email, stipendio, numeroCellulare, dataNascita, specializzazione, sesso);
                else
                    this.model.aggiungiMedico(nome, cognome, email, numeroCellulare, dataNascita, sesso, stipendio, specializzazione);

                this.mediciForm.Close();
            }
            else
                MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string checkValidazione(String nome, String cognome, String email, String numeroCellulare, DateTime dataNascita, String sesso, String stipendio, String specializzazione)
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
            if (numeroCellulare.Length == 0)
            {
                return "Compilare il campo Numero di Telefono";
            }
            if (dataNascita.ToString().Length == 0)
            {
                return "Compilare il campo Data di nascita";
            }
            if (specializzazione.Length == 0)
            {
                return "Compilare il campo specializzazione";
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

        public void creaMedico(object sender, EventArgs e)
        {
            this.mediciForm.NomeTxtBox.Text = "";
            this.mediciForm.CognomeTxtBox.Text = "";
            this.mediciForm.DataNascitaPicker.Text = "";
            this.mediciForm.EmailTxtBox.Text = "";
            this.mediciForm.NumeroDiCellulareTxtBox.Text = "";
            this.mediciForm.MaleRadio.Checked = false;
            this.mediciForm.FemaleRadio.Checked = false;
            this.mediciForm.StipendioTxtBox.Text = "";
            this.mediciForm.MediciIdLbl.Visible = false;
            this.mediciForm.MediciId.Visible = false;

            this.mediciForm.ShowDialog();
        }

        public void modificaMedico(object sender, EventArgs e)
        {
            if (this.view.MediciGridView.SelectedRows.Count == 1)
            {
                string Id = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                string Nome = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[1].Value.ToString();
                string Cognome = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[2].Value.ToString();
                string DataNascita = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[3].Value.ToString();
                string Email = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[4].Value.ToString();
                string Telefono = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[5].Value.ToString();
                string Sesso = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[6].Value.ToString();
                string Quota = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[7].Value.ToString();
                string DataIscrizione = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[8].Value.ToString();

                this.mediciForm.MediciId.Visible = true;
                this.mediciForm.MediciIdLbl.Visible = true;
                this.mediciForm.MediciId.Text = Id;
                this.mediciForm.NomeTxtBox.Text = Nome;
                this.mediciForm.CognomeTxtBox.Text = Cognome;
                this.mediciForm.DataNascitaPicker.Text = DataNascita;
                this.mediciForm.EmailTxtBox.Text = Email;
                this.mediciForm.NumeroDiCellulareTxtBox.Text = Telefono;
                if (Sesso == "Maschio")
                    this.MediciForm.MaleRadio.Checked = true;
                else
                    this.MediciForm.FemaleRadio.Checked = true;
                this.MediciForm.StipendioTxtBox.Text = Quota;
                this.MediciForm.ShowDialog();

            }
            else
                MessageBox.Show("Seleziona solo una riga!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
