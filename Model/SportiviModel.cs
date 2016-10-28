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
    class SportiviModel
    {
        //variabili di classe
        private List<Sportivo> listaSportivi;

        //costruttore modello sportivo
        public SportiviModel()
        {
            this.listaSportivi = new List<Sportivo>();
        }

        public List<Sportivo> ListaSportivi
        {
            get { return this.listaSportivi; }
        }

        //Metodo per eseguire la query per aggiungere uno sportivo nel DB
        public void aggiungiSportivo(String nome, String cognome, String email, String quota, String numeroCellulare, DateTime dataNascita, DateTime dataIscrizione, String sesso, String ruolo)
        {
            String query = " INSERT INTO Sportivi("
                + "Nome, Cognome, DataDiNascita, Email, Telefono, Sesso, Quota, DataIscrizione, Ruolo)"
                + "VALUES('" + nome + "', '"
                + cognome + "', '"
                + SQLiteManager.formatoSQLite(dataNascita) + "', '"
                + email + "', '"
                + numeroCellulare + "', '"
                + sesso + "', '"
                + quota + "', '"
                + SQLiteManager.formatoSQLite(dataIscrizione)+"', '"
                + ruolo + "')";

            SQLiteManager.eseguiQuery(query);
        }

        //Metodo per effettuare una Select sul DB per la modifica
        public void modificaSportivo(int id, String nome, String cognome, String email, String quota, String numeroCellulare, DateTime dataNascita, DateTime dataIscrizione, String sesso, String ruolo)
        {
            String query = " UPDATE Sportivi "
                + " SET Nome = '" + nome + "', "
                + " Cognome = '" + cognome + "', "
                + " DataDiNascita = '" + SQLiteManager.formatoSQLite(dataNascita) + "', "
                + " Email= '" + email + "', "
                + " Telefono = '" + numeroCellulare + "', "
                + " Sesso = '" + sesso + "', "
                + " Quota = '" + quota + "', "
                + " DataIscrizione = '" + SQLiteManager.formatoSQLite(dataIscrizione) + "', "
                + " Ruolo = '" + ruolo + "'"
                + " WHERE Id = " + id;
            SQLiteManager.eseguiQuery(query);
        }

        //Metodo per eseguire la query per rimuovere uno sportivo dal DB
        public void rimuoviSportivo(int id)
        {
            String query = "DELETE FROM Sportivi WHERE Id =" + id;

            SQLiteManager.eseguiQuery(query);
        }

        public void popolaLista()
        {
            //svuoto subito la lista
            this.svuotaLista();

            string query = " SELECT * FROM Sportivi";
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

                    String quantity = record[7].ToString();
                    int Quota = Convert.ToInt32(quantity);
                    String subscription = record[8].ToString();
                    String Ruolo = record[9].ToString();
                    DateTime DataIscrizione = Convert.ToDateTime(subscription);
                    Sportivo sportivo  = new Sportivo(Nome, Cognome, DataDiNascita, Email, Telefono, Sesso, Quota, DataIscrizione, Ruolo);
                    String identity = record[0];
                    sportivo.Id = Convert.ToInt32(identity);
                    this.listaSportivi.Add(sportivo);
                }
            }
        }

        public void svuotaLista()
        {
            this.listaSportivi.Clear();
        }
    }
}
