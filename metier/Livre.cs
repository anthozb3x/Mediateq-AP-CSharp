using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant un livre, héritant de la classe Document.
    /// </summary>
    class Livre : Document
    {
        private string ISBN;
        private string auteur;
        private collection laCollection;

        /// <summary>
        /// Constructeur de la classe Livre.
        /// </summary>
        /// <param name="unId">L'identifiant du livre.</param>
        /// <param name="unTitre">Le titre du livre.</param>
        /// <param name="unISBN">L'ISBN du livre.</param>
        /// <param name="unAuteur">L'auteur du livre.</param>
        /// <param name="uneCollection">La collection du livre.</param>
        /// <param name="uneImage">L'image du livre.</param>
        /// <param name="uneCategorie">La catégorie du livre.</param>
        public Livre(string unId, string unTitre, string unISBN, string unAuteur, collection uneCollection, string uneImage, Categorie uneCategorie) : base(unId, unTitre, uneImage, uneCategorie)
        {
            ISBN1 = unISBN;
            Auteur = unAuteur;
            LaCollection = uneCollection;
        }

        /// <summary>
        /// Obtient ou définit l'ISBN du livre.
        /// </summary>
        public string ISBN1 { get => ISBN; set => ISBN = value; }

        /// <summary>
        /// Obtient ou définit l'auteur du livre.
        /// </summary>
        public string Auteur { get => auteur; set => auteur = value; }

        /// <summary>
        /// Obtient ou définit la collection du livre.
        /// </summary>
        public collection LaCollection { get => laCollection; set => laCollection = value; }
    }
}
