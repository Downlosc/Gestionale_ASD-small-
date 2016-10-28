using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using GestioneSocietaSportiva.Model;
using GestioneSocietaSportiva.Classi;
using GestioneSocietaSportiva.View;
using GestioneSocietaSportiva.Helper;

namespace GestioneSocietaSportiva.Controller
{
    class MainController
    {
        // Vista della Home (dichiarazione delle varibili)
        GestioneSportivaHome view;


        //controller delle varie categorie di persone
        DirigentiController dirigentiController;
        SportiviController sportiviController;
        MediciController mediciContoller;
        StampaController stampaController; 


        public MainController()
        {
            this.view = new GestioneSportivaHome();
            this.dirigentiController = new DirigentiController(this.view);
            this.sportiviController = new SportiviController(this.view);
            this.stampaController = new StampaController(this.view);
            this.mediciContoller = new MediciController(this.view);
            this.inizializzaEventi();
        }

        public void inizializzaEventi()
        {
            this.dirigentiController.Form.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formDirigentiClose);
            this.dirigentiController.View.EliminaDirigentiBtn.Click += new System.EventHandler(this.eliminaDirigente);

            this.sportiviController.SportiviForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formSportiviClose);
            this.sportiviController.View.EliminaSportiviBtn.Click += new System.EventHandler(this.eliminaSportivo);

            this.stampaController.StampaForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formStampaClose);
            this.stampaController.View.EliminaStampaBtn.Click += new System.EventHandler(this.eliminaStampa);

            this.mediciContoller.MediciForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formMediciClose);
            this.mediciContoller.View.EliminaMediciBtn.Click += new System.EventHandler(this.eliminaMedico);
        }

        public void Start()
        {

            //creo il database se non esiste
            if (!File.Exists("GestioneSportivaDB.sqlite"))
            {
                SQLiteManager.creaDatabase();
            }
            //inizializzo liste
            this.inizializzaListe();
            this.inizializzaGrid();
            this.view.ShowDialog();
        }

        public void inizializzaListe()
        {
            this.dirigentiController.Model.popolaLista();
            this.sportiviController.Model.popolaLista();
            this.stampaController.Model.popolaLista();
            this.mediciContoller.Model.popolaLista();
            
        }

        public void inizializzaGrid()
        {
            //Pulisco le colonne
            this.view.DirigentiGridView.Rows.Clear();
            this.view.SportiviGridView.Rows.Clear();
            this.view.MediciGridView.Rows.Clear();
            this.view.StampaGridView.Rows.Clear();
            //Decido quante colonne mettere a display
            this.view.DirigentiGridView.ColumnCount = 9;
            this.view.SportiviGridView.ColumnCount = 10;
            this.view.MediciGridView.ColumnCount = 9;
            this.view.StampaGridView.ColumnCount = 8;

            //Label per ogni colonna - Dirigenti 
            this.view.DirigentiGridView.Columns[0].Name = "ID";
            this.view.DirigentiGridView.Columns[1].Name = "Nome";
            this.view.DirigentiGridView.Columns[2].Name = "Cognome";
            this.view.DirigentiGridView.Columns[3].Name = "Data di nascita";
            this.view.DirigentiGridView.Columns[4].Name = "Email";
            this.view.DirigentiGridView.Columns[5].Name = "Telefono";
            this.view.DirigentiGridView.Columns[6].Name = "Sesso";
            this.view.DirigentiGridView.Columns[7].Name = "Quota";
            this.view.DirigentiGridView.Columns[8].Name = "Data iscrizione";

            //Label per ogni colonna - Sportivi
            this.view.SportiviGridView.Columns[0].Name = "ID";
            this.view.SportiviGridView.Columns[1].Name = "Nome";
            this.view.SportiviGridView.Columns[2].Name = "Cognome";
            this.view.SportiviGridView.Columns[3].Name = "Data di Nascita";
            this.view.SportiviGridView.Columns[4].Name = "Email";
            this.view.SportiviGridView.Columns[5].Name = "Telefono";
            this.view.SportiviGridView.Columns[6].Name = "Sesso";
            this.view.SportiviGridView.Columns[7].Name = "Quota";
            this.view.SportiviGridView.Columns[8].Name = "Data iscrizione";
            this.view.SportiviGridView.Columns[9].Name = "Ruolo";

            //Label per ogni colonna - Stampa
            this.view.StampaGridView.Columns[0].Name = "ID";
            this.view.StampaGridView.Columns[1].Name = "Nome";
            this.view.StampaGridView.Columns[2].Name = "Cognome";
            this.view.StampaGridView.Columns[3].Name = "Data di nascita";
            this.view.StampaGridView.Columns[4].Name = "Email";
            this.view.StampaGridView.Columns[5].Name = "Telefono";
            this.view.StampaGridView.Columns[6].Name = "Sesso";
            this.view.StampaGridView.Columns[7].Name = "Stipendio";

            //Label per ogni colonna - Medici
            this.view.MediciGridView.Columns[0].Name = "ID";
            this.view.MediciGridView.Columns[1].Name = "Nome";
            this.view.MediciGridView.Columns[2].Name = "Cognome";
            this.view.MediciGridView.Columns[3].Name = "Data di nascita";
            this.view.MediciGridView.Columns[4].Name = "Email";
            this.view.MediciGridView.Columns[5].Name = "Telefono";
            this.view.MediciGridView.Columns[6].Name = "Sesso";
            this.view.MediciGridView.Columns[7].Name = "Stipendio";
            this.view.MediciGridView.Columns[8].Name = "Specializzazione";

            //popolo la grid dei dirigenti 
            foreach (Dirigente dirigente in this.dirigentiController.Model.ListaDirigenti)
            {
                //costruisco riga di dati 
                string[] row =
                {
                    dirigente.Id.ToString(),
                    dirigente.Nome.ToString(),
                    dirigente.Cognome.ToString(),
                    dirigente.DataNascita.ToString(),
                    dirigente.Email.ToString(),
                    dirigente.Telefono.ToString(),
                    dirigente.Sesso ? "Femmina":"Maschio",
                    dirigente.Quota.ToString(),
                    dirigente.DataIscrizione.ToString()
                };

                this.view.DirigentiGridView.Rows.Add(row);
            }

            //popolo la grid degli sportivi
            foreach (Sportivo sportivo in this.sportiviController.Model.ListaSportivi)
            {
                //costruisco la riga di dati
                string[] row1 = 
                {
                    sportivo.Id.ToString(),
                    sportivo.Nome.ToString(),
                    sportivo.Cognome.ToString(),
                    sportivo.DataNascita.ToString(),
                    sportivo.Email.ToString(),
                    sportivo.Telefono.ToString(),
                    sportivo.Sesso ? "Femmina" : "Maschio", 
                    sportivo.Quota.ToString(),
                    sportivo.DataIscrizione.ToString(),
                    sportivo.Ruolo.ToString()
                };

                this.view.SportiviGridView.Rows.Add(row1);
            }

            //popolo la gird della stampa
            foreach (Stampa stampa in this.stampaController.Model.ListaStampa)
            {
                //costruisco la riga di dati 
                string[] row2 =
                {
                    stampa.Id.ToString(),
                    stampa.Nome.ToString(),
                    stampa.Cognome.ToString(),
                    stampa.DataNascita.ToString(),
                    stampa.Email.ToString(),
                    stampa.Telefono.ToString(),
                    stampa.Sesso ? "Femmina":"Maschio",
                    stampa.Stipendio.ToString()
                };

                this.view.StampaGridView.Rows.Add(row2);
            }

            //popolo la grid dei medici
            foreach (Medico medico in this.mediciContoller.Model.ListaMedici)
            {
                //costruisco la riga di dati
                string[] row3 =
                {
                    medico.Id.ToString(),
                    medico.Nome.ToString(),
                    medico.Cognome.ToString(),
                    medico.DataNascita.ToString(),
                    medico.Email.ToString(),
                    medico.Telefono.ToString(),
                    medico.Sesso ? "Femmina":"Maschio",
                    medico.Stipendio.ToString(),
                    medico.Specializzazione.ToString()
                };

                this.view.MediciGridView.Rows.Add(row3);
            }
        }

        //Chiudi il form dirigente 
        public void formDirigentiClose(object sender, FormClosedEventArgs e)
        {
            this.inizializzaListe();
            this.inizializzaGrid();
        }

        //Chiudi il form sportivi
        public void formSportiviClose(object sender, FormClosedEventArgs e)
        {
            this.inizializzaListe();
            this.inizializzaGrid();
        }

        //Chiudi il form stampa
        public void formStampaClose(object sender, FormClosedEventArgs e)
        {
            this.inizializzaListe();
            this.inizializzaGrid();
        }

        //Chiudi il form medici
        public void formMediciClose(object sender, FormClosedEventArgs e)
        {
            this.inizializzaListe();
            this.inizializzaGrid();
        }

        //Metodo per eliminare un dirigente 
        public void eliminaDirigente(object sender, EventArgs e)
        {
            if (this.view.DirigentiGridView.SelectedRows.Count == 1)
            {
                string Id = this.view.DirigentiGridView.Rows[this.view.DirigentiGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                int id = Convert.ToInt16(Id);
                if (MessageBox.Show("Sei sicuro?", "Elimina", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.dirigentiController.Model.rimuoviDirigente(id);
                    this.inizializzaListe();
                    this.inizializzaGrid();
                }
            }
            else
                MessageBox.Show("Seleziona solo una riga!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //Metodo per elminiare uno sportivo
        public void eliminaSportivo(object sender, EventArgs e)
        {
            if(this.view.SportiviGridView.SelectedRows.Count == 1)
            {
                string Id = this.view.SportiviGridView.Rows[this.view.SportiviGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                int id = Convert.ToInt16(Id);
                if (MessageBox.Show("Sei sicuro?", "Elimina", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.sportiviController.Model.rimuoviSportivo(id);
                    this.inizializzaListe();
                    this.inizializzaGrid();
                }
                else
                    MessageBox.Show("Seleziona solo una riga!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Metodo per eliminare un membro stampa
        public void eliminaStampa(object sender, EventArgs e)
        {
            if (this.view.StampaGridView.SelectedRows.Count == 1)
            {
                string Id = this.view.StampaGridView.Rows[this.view.StampaGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                int id = Convert.ToInt16(Id);
                if (MessageBox.Show("Sei sicuro?", "Elimina", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.stampaController.Model.rimuoviStampa(id);
                    this.inizializzaListe();
                    this.inizializzaGrid();
                }
                else
                    MessageBox.Show("Seleziona solo una riga!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Metodo per eliminare un membro staff medico
        public void eliminaMedico(object sender, EventArgs e)
        {
            if (this.view.MediciGridView.SelectedRows.Count == 1)
            {
                string Id = this.view.MediciGridView.Rows[this.view.MediciGridView.SelectedRows[0].Index].Cells[0].Value.ToString();
                int id = Convert.ToInt16(Id);
                if (MessageBox.Show("Sei sicuro?", "Elimina", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.mediciContoller.Model.rimuoviMedico(id);
                    this.inizializzaListe();
                    this.inizializzaGrid();
                }
                else
                    MessageBox.Show("Seleziona solo una riga!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
