using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant un type d'abonnement.
    /// </summary>
    class TypeAbonnement
    {
        private string id;
        private string libelle;

        /// <summary>
        /// Constructeur de la classe TypeAbonnement.
        /// </summary>
        /// <param name="id">L'identifiant du type d'abonnement.</param>
        /// <param name="libelle">Le libellé du type d'abonnement.</param>
        public TypeAbonnement(string id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du type d'abonnement.
        /// </summary>
        public string Id { get => id; set => id = value; }

        /// <summary>
        /// Obtient ou définit le libellé du type d'abonnement.
        /// </summary>
        public string Libelle { get => libelle; set => libelle = value; }
    }
}
