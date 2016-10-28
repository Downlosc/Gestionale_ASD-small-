using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GestioneSocietaSportiva.Helper
{
    public static class SQLiteManager
    {
        public static void creaDatabase()
        {
            //creo il database
            SQLiteConnection.CreateFile("GestioneSportivaDB.sqlite");

            //creo una connessione al db
            SQLiteConnection dbConnection = null;

            //testo la connessione (buon fine-->try else catch
            try
            {
                dbConnection = new SQLiteConnection("Data Source=GestioneSportivaDB.sqlite;Version=3;");
                dbConnection.Open();

                //query per la creazione delle tabelle
                string creaTabellaDirigenti = "     CREATE TABLE IF NOT EXISTS Dirigenti(     "
                                               + "   ID      INTEGER PRIMARY KEY AUTOINCREMENT, "
                                               + "   Nome                 TEXT        NOT NULL,"
                                               + "   Cognome              TEXT        NOT NULL,"
                                               + "   DataDiNascita        DATE        NOT NULL,"
                                               + "   Email                VARCHAR(50) NOT NULL,"
                                               + "   Telefono             VARCHAR(20) NOT NULL,"
                                               + "   Sesso                INTEGER     NOT NULL,"
                                               + "   Quota                INTEGER     NOT NULL,"
                                               + "   DataIscrizione       DATE        NOT NULL)";

                string creaTabellaSportivi = "       CREATE TABLE IF NOT EXISTS Sportivi(     "
                                             + "      ID     INTEGER PRIMARY KEY AUTOINCREMENT, "
                                             + "      Nome               TEXT        NOT NULL,"
                                             + "      Cognome            TEXT        NOT NULL,"
                                             + "      DataDiNascita      DATE        NOT NULL,"
                                             + "      Email              VARCHAR(50) NOT NULL,"
                                             + "      Telefono           VARCHAR(20) NOT NULL,"
                                             + "      Sesso              INTEGER     NOT NULL,"
                                             + "      Quota              INTEGER     NOT NULL,"
                                             + "      DataIscrizione     DATE        NOT NULL,"
                                             + "      Ruolo              TEXT        NOT NULL)";
                string creaTabellaStampa = "       CREATE TABLE IF NOT EXISTS Stampa(     "
                                             + "      ID     INTEGER PRIMARY KEY AUTOINCREMENT, "
                                             + "      Nome               TEXT        NOT NULL,"
                                             + "      Cognome            TEXT        NOT NULL,"
                                             + "      DataDiNascita      DATE        NOT NULL,"
                                             + "      Email              VARCHAR(50) NOT NULL,"
                                             + "      Telefono           VARCHAR(20) NOT NULL,"
                                             + "      Sesso              INTEGER     NOT NULL,"
                                             + "      Stipendio          INTEGER(50) NOT NULL)";
                string creaTabellaMedici = "       CREATE TABLE IF NOT EXISTS Medici(     "
                                             + "      ID     INTEGER PRIMARY KEY AUTOINCREMENT, "
                                             + "      Nome               TEXT        NOT NULL,"
                                             + "      Cognome            TEXT        NOT NULL,"
                                             + "      DataDiNascita      DATE        NOT NULL,"
                                             + "      Email              VARCHAR(50) NOT NULL,"
                                             + "      Telefono           VARCHAR(20) NOT NULL,"
                                             + "      Sesso              INTEGER     NOT NULL,"
                                             + "      Stipendio          INTEGER(50) NOT NULL,"
                                             + "      Specializzazione   TEXT        NOT NULL)";

                //crea un comando sqlite che prende la connessione e la stringa da eseguire 
                SQLiteCommand cmdCreaDirigenti = new SQLiteCommand(creaTabellaDirigenti, dbConnection);
                SQLiteCommand cmdCreaSportivi = new SQLiteCommand(creaTabellaSportivi, dbConnection);
                SQLiteCommand cmdCreaStampa = new SQLiteCommand(creaTabellaStampa, dbConnection);
                SQLiteCommand cmdCreaMedici = new SQLiteCommand(creaTabellaMedici, dbConnection);

                //esegue il comando
                cmdCreaDirigenti.ExecuteNonQuery();
                cmdCreaSportivi.ExecuteNonQuery();
                cmdCreaStampa.ExecuteNonQuery();
                cmdCreaMedici.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Accesso al DB fallito con errore: " + e);
            }
            finally
            {
                //chiusra della connessione col db 
                if (dbConnection != null)
                {
                    try
                    {
                        dbConnection.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Chiusura DB fallita con errore: " + e);
                    }
                    finally
                    {
                        dbConnection.Dispose();
                    }
                }
            }
        }

        public static void eseguiQuery(String query)
        {
            SQLiteConnection dbConnection = null;

            //testo la connessione (buon fine-->try else catch
            try
            {
                dbConnection = new SQLiteConnection("Data Source=GestioneSportivaDB.sqlite;Version=3;");
                dbConnection.Open();
                SQLiteCommand queryCommand = new SQLiteCommand(query, dbConnection);
                queryCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Accesso al DB fallita con errore: " + e);
            }
            finally
            {
                //chiusra della connessione col db 
                if (dbConnection != null)
                {
                    try
                    {
                        dbConnection.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Chiusa DB fallita con errore: " + e);
                    }
                    finally
                    {
                        dbConnection.Dispose();
                    }
                }
            }

        }

        public static List<string[]> eseguiSelect(String query)
        {
            SQLiteConnection dbConnection = null;
            SQLiteDataReader readerSelect = null;
            List<string[]> lista = new List<string[]>();
            try
            {
                dbConnection = new SQLiteConnection("Data Source=GestioneSportivaDB.sqlite;Version=3;");
                dbConnection.Open();
                SQLiteCommand queryCommand = new SQLiteCommand(query, dbConnection);
                readerSelect = queryCommand.ExecuteReader();
                while (readerSelect.Read())
                {
                    int i = 0;
                    string[] record = new string[readerSelect.GetValues().Count];
                    
                    foreach(string campo in readerSelect.GetValues())
                    {
                        record[i] = readerSelect[campo].ToString();
                        i++;
                    }

                    lista.Add(record);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Accesso al DB fallita con errore: " + e);
            }
            finally
            {
                //chiusra della connessione col db 
                if (dbConnection != null)
                {
                    try
                    {
                        dbConnection.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Chiusa DB fallita con errore: " + e);
                    }
                    finally
                    {
                        dbConnection.Dispose();
                    }
                }
            }

            return lista;
        }
        public static string formatoSQLite(DateTime data)
        {
            string nuovaData = data.ToString("yyyy-MM-dd");
            return nuovaData; 
        }
    }

}