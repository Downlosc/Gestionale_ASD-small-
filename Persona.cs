using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSocietaSportiva.Classi
{
    class Persona
    {
        protected string nome;
        protected string cognome;
        protected DateTime dataNascita;
        protected string telefono;
        protected string email;
        protected bool sesso; 

        public Persona(string nome, string cognome, DateTime dataNascita, string telefono, string email, bool sesso)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.dataNascita = dataNascita;
            this.telefono = telefono;
            this.email = email;
            this.sesso = sesso;
        }

        //metodi get e set
        public String Nome
        {
            get { return this.nome; }
            set { this.nome = value; }

        }
        public String Cognome
        {
            get { return this.cognome; }
            set { this.cognome = value; }

        }
        public DateTime DataNascita
        {
            get { return this.dataNascita; }
            set { this.dataNascita = value; }

        }
        public String Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public String Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }

        }
        public bool Sesso
        {
            get { return this.sesso; }
            set { this.sesso = value; }

        }
    }
}
