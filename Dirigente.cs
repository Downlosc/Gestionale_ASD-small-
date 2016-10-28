using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSocietaSportiva.Classi
{
    class Dirigente : Persona
    {
        //variabili aggiuntive che la persona non ha 
        protected int id;
        protected int quota;
        protected DateTime dataIscrizione;

        public Dirigente(string nome, string cognome, DateTime dataNascita, string email, string numeroDiCellulare, bool sesso, int quota, DateTime dataIscrizione): base (nome, cognome, dataNascita, numeroDiCellulare, email,sesso)
        {
            this.id = 0;
            this.quota = quota;
            this.dataIscrizione = dataIscrizione; 
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int Quota
        {
            get { return this.quota; }
            set { this.quota = value; }
        }
        public DateTime DataIscrizione
        {
            get { return this.dataIscrizione; }
            set { this.dataIscrizione = value; }
        }
    }


}
