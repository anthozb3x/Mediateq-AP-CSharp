using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant un utilisateur.
    /// </summary>
    class Utilisateur
    {
        private string id;
        private string nom;
        private string prenom;
        private string email;
        private string mdp;
        private Service service;

        /// <summary>
        /// Constructeur de la classe Utilisateur.
        /// </summary>
        /// <param name="id">L'identifiant de l'utilisateur.</param>
        /// <param name="nom">Le nom de l'utilisateur.</param>
        /// <param name="prenom">Le prénom de l'utilisateur.</param>
        /// <param name="email">L'email de l'utilisateur.</param>
        /// <param name="mdp">Le mot de passe de l'utilisateur.</param>
        /// <param name="service">Le service auquel l'utilisateur est rattaché.</param>
        public Utilisateur(string id, string nom, string prenom, string email, string mdp, Service service)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.mdp = mdp;
            this.service = service;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'utilisateur.
        /// </summary>
        public string Id { get => id; set => id = value; }

        /// <summary>
        /// Obtient ou définit le nom de l'utilisateur.
        /// </summary>
        public string Nom { get => nom; set => nom = value; }

        /// <summary>
        /// Obtient ou définit le prénom de l'utilisateur.
        /// </summary>
        public string Prenom { get => prenom; set => prenom = value; }

        /// <summary>
        /// Obtient ou définit l'email de l'utilisateur.
        /// </summary>
        public string Email { get => email; set => email = value; }

        /// <summary>
        /// Obtient ou définit le mot de passe de l'utilisateur.
        /// </summary>
        public string Mdp { get => mdp; set => mdp = value; }

        /// <summary>
        /// Obtient ou définit le service auquel l'utilisateur est rattaché.
        /// </summary>
        public Service Service { get => service; set => service = value; }
    }
}
