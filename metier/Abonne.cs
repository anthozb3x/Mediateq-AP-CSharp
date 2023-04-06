using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    class Abonne
    {
        private string id;
        private string nom;
        private string prenom;
        private string adresse;
        private string telephone;
        private string adresseMail;
        private DateTime dateNaissance;
        private DateTime datePremierAbo;
        private DateTime dateFinAbo;
        private TypeAbonnement typeAbonnement;

        public Abonne(string id, string nom, string prenom, string adresse, string telephone, string adresseMail, DateTime dateNaissance, DateTime datePremierAbo, DateTime dateFinAbo, TypeAbonnement typeAbonnement)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.telephone = telephone;
            this.adresseMail = adresseMail;
            this.dateNaissance = dateNaissance;
            this.datePremierAbo = datePremierAbo;
            this.DateFinAbo = dateFinAbo;
            this.typeAbonnement = typeAbonnement;
        }

        
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string AdresseMail { get => adresseMail; set => adresseMail = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public DateTime DatePremierAbo { get => datePremierAbo; set => datePremierAbo = value; }
        public DateTime DateFinAbo { get => dateFinAbo; set => dateFinAbo = value; }
        public TypeAbonnement TypeAbonnement { get => typeAbonnement; set => typeAbonnement = value; }
        public string Id { get => id; set => id = value; }
        
    }
}


