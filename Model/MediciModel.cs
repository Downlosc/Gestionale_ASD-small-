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
    class MediciModel
    {
        //variabili di classe 
        private List<Medico> listaMedici;

        //costruttore del modello
        public MediciModel()
        {
            this.listaMedici = new List<Medico>();
        }

        public List<Medico> ListaMedici
        {
            get { return this.listaMedici; }
            set { this.listaMedici = value; }
        }

        //Metodo per eseguire la query per rimuovere un medico dal DB
        public void rimuoviMedico(int id)
        {
            String query = "DELETE FROM Medici WHERE Id =" + id;

            SQLiteManager.eseguiQuery(query);
        }

        //Metodo per eseguire la query per aggiungere un medico nel DB
        public void aggiungiMedico(String nome, String cognome, String email, String numeroCellulare, DateTime dataNascita, String sesso, String Stipendio, String Specializzazione)
        {
            String query = " INSERT INTO Medici("
                + "Nome, Cognome, DataDiNascita, Email, Telefono, Sesso, Stipendio, Specializzazione)"
                + "VALUES('" + nome + "', '"
                + cognome + "', '"
                + SQLiteManager.formatoSQLite(dataNascita) + "', '"
                + email + "', '"
                + numeroCellulare + "', '"
                + sesso + "', '"
                + Stipendio +"', '"
                + Specializzazione+"')";

            SQLiteManager.eseguiQuery(query);
        }

        //Metodo per eseguire la query di update degli attributi di un medico nel DB
        public void modificaMedici(int id, String nome, String cognome, String email, String stipendio, String numeroCellulare, DateTime dataNascita, String specializzazione, String sesso)
        {
            String query = " UPDATE Medici "
                + " SET Nome = '" + nome + "', "
                + " Cognome = '" + cognome + "', "
                + " DataDiNascita = '" + SQLiteManager.formatoSQLite(dataNascita) + "', "
                + " Email= '" + email + "', "
                + " Telefono = '" + numeroCellulare + "', "
                + " Sesso = '" + sesso + "', "
                + " Specializzazione = '" + specializzazione + "', "
                + " Stipendio = '" + stipendio + "'"
                + " WHERE Id = " + id;
            SQLiteManager.eseguiQuery(query);
        }


        public void popolaLista()
        {
            //svuoto subito la lista
            this.svuotaLista();

            string query = " SELECT * FROM Medici";
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
                    String Specializzazione = record[8].ToString();
                    Medico medico = new Medico(Nome, Cognome, DataDiNascita, Email, Telefono, Sesso, Stipendio, Specializzazione);
                    String identity = record[0];
                    medico.Id = Convert.ToInt32(identity);
                    this.listaMedici.Add(medico);
                }
            }
        }

        public void svuotaLista()
        {
            this.listaMedici.Clear();
        }
    }
}
