using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using GestioneSocietaSportiva.Helper;
using GestioneSocietaSportiva.Classi;

namespace GestioneSocietaSportiva.Model
{
    class StampaModel
    {
        private List<Stampa> listaStampa;

        //costruttore del modello 
        
        public StampaModel()
        {
            this.listaStampa = new List<Stampa>();
        }

        public List<Stampa> ListaStampa
        {
            get { return this.listaStampa; }
        }

        public void aggiungiStampa(String nome, String cognome, String email, String numeroCellulare, DateTime dataNascita, String sesso, String Stipendio)
        {
            String query = " INSERT INTO Stampa("
                + "Nome, Cognome, DataDiNascita, Email, Telefono, Sesso, Stipendio)"
                + "VALUES('" + nome + "', '"
                + cognome + "', '"
                + SQLiteManager.formatoSQLite(dataNascita) + "', '"
                + email + "', '"
                + numeroCellulare + "', '"
                + sesso + "', '"
                + Stipendio + "')";

            SQLiteManager.eseguiQuery(query);
        }

        //Metodo per eseguire la query per la modifica della stampa nel DB
        public void modificaStampa(int id, String nome, String cognome, String email, String numeroCellulare, DateTime dataNascita, String sesso, String stipendio)
        {
            String query = " UPDATE Stampa "
                + " SET Nome = '" + nome + "', "
                + " Cognome = '" + cognome + "', "
                + " DataDiNascita = '" + SQLiteManager.formatoSQLite(dataNascita) + "', "
                + " Email= '" + email + "', "
                + " Telefono = '" + numeroCellulare + "', "
                + " Sesso = '" + sesso + "', "
                + " Stipendio = '" +stipendio + "'"
                + " WHERE Id = " + id;

            SQLiteManager.eseguiQuery(query);
        }

        //Metodo per eseguire la query per rimuovere una stampa dal DB
        public void rimuoviStampa(int id)
        {
            String query = "DELETE FROM Stampa WHERE Id =" + id;

            SQLiteManager.eseguiQuery(query);
        }
        public void popolaLista()
        {
            //svuoto subito la lista
            this.svuotaLista();

            string query = " SELECT * FROM Stampa";
            List<string[]> reader = SQLiteManager.eseguiSelect(query);

            if (reader.Count > 0)
            {
                foreach (string[] record in reader)
                {

                    bool Sesso;
                    String Nome = record[1].ToString();
                    String Cognome = record[2].ToString();
                    String date = record[3].ToString();
                    DateTime DataDiNascita = Convert.ToDateTime(date);
                    String Email = record[4].ToString();
                    String Telefono = record[5].ToString();
                    String sex = record[6].ToString();
                    if (sex.Length == 0)
                        Sesso = true;
                    else
                        Sesso = false;
                    String earn = record[7].ToString();
                    int Stipendio = Convert.ToInt32(earn);
                    Stampa stampa = new Stampa(Nome, Cognome, DataDiNascita, Email, Telefono, Sesso, Stipendio);
                    String identity = record[0];
                    stampa.Id = Convert.ToInt32(identity);
                    this.listaStampa.Add(stampa);
                }
            }
        }

        public void svuotaLista()
        {
            this.listaStampa.Clear();
        }
    }
}
