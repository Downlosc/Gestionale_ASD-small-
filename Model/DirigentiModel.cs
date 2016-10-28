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
    class DirigentiModel
    {
        //variabili di classe
        private List<Dirigente> listaDirigenti;

        //costruttore del Modello
        public DirigentiModel()
        {
            this.listaDirigenti = new List<Dirigente>();

        }

        public List<Dirigente> ListaDirigenti
        {
            get { return this.listaDirigenti; }
        }

        public void aggiungiDirigente(String nome, String cognome, String email, String quota, String numeroCellulare, DateTime dataNascita, DateTime dataIscrizione, String sesso)
        {
            String query = " INSERT INTO Dirigenti("
                + "Nome, Cognome, DataDiNascita, Email, Telefono, Sesso, Quota, DataIscrizione)"
                + "VALUES('" + nome + "', '"
                + cognome + "', '"
                + SQLiteManager.formatoSQLite(dataNascita) + "', '"
                + email + "', '"
                + numeroCellulare + "', '"
                + sesso + "', '"
                + quota + "', '"
                + SQLiteManager.formatoSQLite(dataIscrizione) + "')";
            SQLiteManager.eseguiQuery(query);
        }

        public void modificaDirigente(int id,String nome, String cognome, String email, String quota, String numeroCellulare, DateTime dataNascita, DateTime dataIscrizione, String sesso)
        {
            String query = " UPDATE Dirigenti "
                + " SET Nome = '" + nome + "', "
                + " Cognome = '" + cognome + "', "
                + " DataDiNascita = '" + SQLiteManager.formatoSQLite(dataNascita) + "', "
                + " Email= '" + email + "', "
                + " Telefono = '" + numeroCellulare + "', "
                + " Sesso = '" + sesso + "', "
                + " Quota = '" + quota + "', "
                + " DataIscrizione = '" + SQLiteManager.formatoSQLite(dataIscrizione) + "'"
                + " WHERE Id = " + id;
           
            //ATTENZIONE CAMBIARE CONVERTI DATA ANCHE SUGLI ALTRI 

            SQLiteManager.eseguiQuery(query);
        }

        public void rimuoviDirigente(int id)
        {
            String query = "DELETE FROM Dirigenti WHERE Id =" + id;

            SQLiteManager.eseguiQuery(query);
        }
        public void popolaLista()
        {
            //svuoto subito la lista
            this.svuotaLista();

            string query = " SELECT * FROM Dirigenti";
            List<string[]> reader = SQLiteManager.eseguiSelect(query);

            if(reader.Count > 0)
            {
                foreach(string[] record in reader)
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
                    DateTime DataIscrizione = Convert.ToDateTime(subscription);

                    Dirigente dirigente = new Dirigente(Nome, Cognome, DataDiNascita, Email, Telefono, Sesso, Quota, DataIscrizione);
                    String identity = record[0];
                    dirigente.Id = Convert.ToInt32(identity);
                    this.listaDirigenti.Add(dirigente);
                }
            }
        }

        public void svuotaLista()
        {
            this.listaDirigenti.Clear();
        }
    }
}
