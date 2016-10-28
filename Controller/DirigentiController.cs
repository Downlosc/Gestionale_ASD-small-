using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSocietaSportiva.Model;
using GestioneSocietaSportiva.View;
using System.Net.Mail;
using System.Windows.Forms;

namespace GestioneSocietaSportiva.Controller
{
    class DirigentiController
    {
        //model e view del controller (inclusione) 
        protected DirigentiModel model;
        protected GestioneSportivaHome view;
        protected DirigentiForm dirigentiForm;

        //Costruttore del controller dirigenti
        public DirigentiController(GestioneSportivaHome view)
        {
            this.model = new DirigentiModel();
            this.view = view;
            this.dirigentiForm = new DirigentiForm();
            //inizializzo gli eventi 
            inizializzaEventi();

        }
        public GestioneSportivaHome View
        {
            get { return this.view; }
        }

        public DirigentiModel Model
        {
            get { return this.model; }
        }

        public DirigentiForm Form
        {
            get { return this.dirigentiForm; }
        }

        public void inizializzaEventi()
        {
            //eventi della vista principale (GestioneSportivaHome) 
            this.view.CreaDirigentiBtn.Click += new System.EventHandler(this.creaDirigente);
            this.view.ModificaDirigentibtn.Click += new System.EventHandler(this.modificaDirigente);

            //eventi della vista form
            this.dirigentiForm.AnnullaBtn.Click += new System.EventHandler(this.chiudiForm);
            this.dirigentiForm.SalvaBtn.Click += new System.EventHandler(this.salvaForm);

        }

        public void chiudiForm(object sender, EventArgs e)
        {
            this.dirigentiForm.Close();
        }

        public void salvaForm(object sender, EventArgs e)
        {
            int id = 0;
            String nome = this.dirigentiForm.NomeTxtBox.Text;
            String cognome = this.dirigentiForm.CognomeTxtBox.Text;
            String email = this.dirigentiForm.EmailTxtBox.Text;
            String quota = this.dirigentiForm.QuotaTxtBox.Text;
            String sesso = this.dirigentiForm.MaleRadio.Checked? "1" : "0";
            DateTime dataNascita = Convert.ToDateTime(this.dirigentiForm.DataNascitaPicker.Value.ToShortDateString());
            DateTime dataIscrizione = Convert.ToDateTime(this.dirigentiForm.DataIscrizionePicker.Value.ToShortDateString());
            String numeroCellulare = this.dirigentiForm.NumeroDiCellulareTxtBox.Text;

            if (this.dirigentiForm.DirigentiId.Visible)
                id = Convert.ToInt32(this.dirigentiForm.DirigentiId.Text);

            //chiamo la funzione del modello per aggiungere un nuovo dirigente
            string result = checkValidazione(nome,cognome,email,quota,numeroCellulare,dataNascita,dataIscrizione,sesso);
            if (result.Length == 0)
            {
                if(this.dirigentiForm.DirigentiId.Visible)
                    this.model.modificaDirigente(id,nome, cognome, email, quota, numeroCellulare, dataNascita, dataIscrizione, sesso);

                else
                    this.model.aggiungiDirigente(nome, cognome, email, quota, numeroCellulare, dataNascita, dataIscrizione,sesso);

                this.dirigentiForm.Close();
            }
            else
                MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string checkValidazione(String nome,  String cognome,String email,String quota, String numeroCellulare, DateTime dataNascita, DateTime dataIscrizione, String sesso)
        {
            if(nome.Length == 0)
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
            if(dataNascita.ToString().Length == 0)
            {
                return "Compilare il campo Data di nascita";
            }
            if(dataIscrizione.ToString().Length == 0)
            {
                return "Compilare il campo Data iscrizione";
            }
            if(quota.Length > 0)
            {
                    double num;
                    bool isNum = double.TryParse(quota, out num);
                if(!isNum)
                    return "Formato quota non valido";
            }
            return "";

          
        }

        public void creaDirigente(object sender, EventArgs e)
        {
            this.dirigentiForm.NomeTxtBox.Text = "";
            this.dirigentiForm.CognomeTxtBox.Text = "";
            this.dirigentiForm.DataNascitaPicker.Text = "";
            this.dirigentiForm.EmailTxtBox.Text = "";
            this.dirigentiForm.NumeroDiCellulareTxtBox.Text = "";
            this.dirigentiForm.MaleRadio.Checked = false;
            this.dirigentiForm.FemaleRadio.Checked = false;
            this.dirigentiForm.QuotaTxtBox.Text = "";
            this.dirigentiForm.DataIscrizionePicker.Text = "";
            this.dirigentiForm.DirigentiLabel.Visible = false;
            this.dirigentiForm.DirigentiId.Visible = false; 

            this.dirigentiForm.ShowDialog();
        }

        public void modificaDirigente(object sender, EventArgs e)
        {
            if (this.view.DirigentiGridView.SelectedRows.Count == 1)
            {
                string Id = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                string Nome = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[1].Value.ToString();
                string Cognome = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[2].Value.ToString();
                string DataNascita = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[3].Value.ToString();
                string Email = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[4].Value.ToString();
                string Telefono = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[5].Value.ToString();
                string Sesso = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[6].Value.ToString();
                string Quota = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[7].Value.ToString();
                string DataIscrizione = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[8].Value.ToString();

                this.dirigentiForm.DirigentiId.Visible = true;
                this.dirigentiForm.DirigentiLabel.Visible = true;
                this.dirigentiForm.DirigentiId.Text = Id; 
                this.dirigentiForm.NomeTxtBox.Text = Nome;
                this.dirigentiForm.CognomeTxtBox.Text = Cognome;
                this.dirigentiForm.DataNascitaPicker.Text = DataNascita;
                this.dirigentiForm.EmailTxtBox.Text = Email;
                this.dirigentiForm.NumeroDiCellulareTxtBox.Text = Telefono;
                if (Sesso == "Maschio")
                    this.dirigentiForm.MaleRadio.Checked = true;
                else
                    this.dirigentiForm.FemaleRadio.Checked = true;
                this.dirigentiForm.QuotaTxtBox.Text = Quota;
                this.dirigentiForm.DataIscrizionePicker.Text = DataIscrizione;
                this.dirigentiForm.ShowDialog();

            }
            else
                MessageBox.Show("Seleziona solo una riga!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
