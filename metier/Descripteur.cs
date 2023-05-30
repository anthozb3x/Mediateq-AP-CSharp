using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant un descripteur.
    /// </summary>
    class Descripteur
    {
        private string id;
        private string libelle;

        /// <summary>
        /// Constructeur de la classe Descripteur.
        /// </summary>
        /// <param name="id">L'identifiant du descripteur.</param>
        /// <param name="libelle">Le libellé du descripteur.</param>
        public Descripteur(string id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du descripteur.
        /// </summary>
        public string Id { get => id; set => id = value; }

        /// <summary>
        /// Obtient ou définit le libellé du descripteur.
        /// </summary>
        public string Libelle { get => libelle; set => libelle = value; }
    }
}
