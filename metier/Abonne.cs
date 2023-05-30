using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant un abonné.
    /// </summary>
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

        /// <summary>
        /// Constructeur de la classe Abonne.
        /// </summary>
        /// <param name="id">L'identifiant de l'abonné.</param>
        /// <param name="nom">Le nom de l'abonné.</param>
        /// <param name="prenom">Le prénom de l'abonné.</param>
        /// <param name="adresse">L'adresse de l'abonné.</param>
        /// <param name="telephone">Le numéro de téléphone de l'abonné.</param>
        /// <param name="adresseMail">L'adresse e-mail de l'abonné.</param>
        /// <param name="dateNaissance">La date de naissance de l'abonné.</param>
        /// <param name="datePremierAbo">La date de début de l'abonnement.</param>
        /// <param name="dateFinAbo">La date de fin de l'abonnement.</param>
        /// <param name="typeAbonnement">Le type d'abonnement de l'abonné.</param>
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

        /// <summary>
        /// Obtient ou définit le nom de l'abonné.
        /// </summary>
        public string Nom { get => nom; set => nom = value; }

        /// <summary>
        /// Obtient ou définit le prénom de l'abonné.
        /// </summary>
        public string Prenom { get => prenom; set => prenom = value; }

        /// <summary>
        /// Obtient ou définit l'adresse de l'abonné.
        /// </summary>
        public string Adresse { get => adresse; set => adresse = value; }

        /// <summary>
        /// Obtient ou définit le numéro de téléphone de l'abonné.
        /// </summary>
        public string Telephone { get => telephone; set => telephone = value; }

        /// <summary>
        /// Obtient ou définit l'adresse e-mail de l'abonné.
        /// </summary>
        public string AdresseMail { get => adresseMail; set => adresseMail = value; }

        /// <summary>
        /// Obtient ou définit la date de naissance de l'abonné.
        /// </summary>
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }

        /// <summary>
        /// Obtient ou définit la date de début de l'abonnement de l'abonné.
        /// </summary>
        public DateTime DatePremierAbo { get => datePremierAbo; set => datePremierAbo = value; }

        /// <summary>
        /// Obtient ou définit la date de fin de l'abonnement de l'abonné.
        /// </summary>
        public DateTime DateFinAbo { get => dateFinAbo; set => dateFinAbo = value; }

        /// <summary>
        /// Obtient ou définit le type d'abonnement de l'abonné.
        /// </summary>
        public TypeAbonnement TypeAbonnement { get => typeAbonnement; set => typeAbonnement = value; }

        /// <summary>
        /// Obtient ou définit l'identifiant de l'abonné.
        /// </summary>
        public string Id { get => id; set => id = value; }
    }
}

