using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSocietaSportiva.Classi
{
    class Medico:Persona
    {
        //variabili di classe
        protected int id;
        protected int stipendio;
        protected string specializzazione;

        public Medico(string nome, string cognome, DateTime dataNascita, string email, string numeroDiCellulare, bool sesso, int stipendio, string specializzazione):base(nome, cognome, dataNascita, numeroDiCellulare, email, sesso)
        {
            this.id = 0;
            this.stipendio = stipendio;
            this.specializzazione = specializzazione; 
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int Stipendio
        {
            get { return this.stipendio; }
            set { this.stipendio = value; }
        }

        public string Specializzazione
        {
            get { return this.specializzazione; }
            set { this.specializzazione = value; }
        }
    }
}
