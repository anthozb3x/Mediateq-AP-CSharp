using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant une catégorie.
    /// </summary>
    class Categorie
    {
        private string id;
        private string libelle;

        /// <summary>
        /// Constructeur de la classe Categorie.
        /// </summary>
        /// <param name="id">L'identifiant de la catégorie.</param>
        /// <param name="libelle">Le libellé de la catégorie.</param>
        public Categorie(string id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant de la catégorie.
        /// </summary>
        public string Id { get => id; set => id = value; }

        /// <summary>
        /// Obtient ou définit le libellé de la catégorie.
        /// </summary>
        public string Libelle { get => libelle; set => libelle = value; }
    }
}
