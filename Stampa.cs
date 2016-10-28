using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSocietaSportiva.Classi
{
    class Stampa : Persona
    {
        protected int id;
        protected int stipendio;

        public Stampa(string nome, string cognome, DateTime dataNascita, string email, string numeroDiCellulare, bool sesso, int stipendio):base(nome,cognome,dataNascita,numeroDiCellulare,email,sesso)
        {
            this.id = 0;
            this.stipendio = stipendio;

        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value;}
        }

        public int Stipendio
        {
            get { return this.stipendio; }
            set { this.stipendio = value; }
        }

    }
}
