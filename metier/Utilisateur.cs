using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    class Utilisateur
    {
        private string id;
        private string nom;
        private string prenom;
        private string email;
        private string mdp;
       
        private Service service;

        public Utilisateur(string id, string nom, string prenom, string email, string mdp,  Service service)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.mdp = mdp;
            this.service = service;
        }

        public string Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Email { get => email; set => email = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public Service Service { get => service; set => service = value; }
    }
}
