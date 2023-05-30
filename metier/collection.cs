using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant une collection.
    /// </summary>
    class collection
    {
        private string id;
        private string libelle;

        /// <summary>
        /// Constructeur de la classe Collection.
        /// </summary>
        /// <param name="id">L'identifiant de la collection.</param>
        /// <param name="libelle">Le libellé de la collection.</param>
        public collection(string id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        /// <summary>
        /// Obtient ou définit le libellé de la collection.
        /// </summary>
        public string Libelle { get => libelle; set => libelle = value; }

        /// <summary>
        /// Obtient ou définit l'identifiant de la collection.
        /// </summary>
        public string Id { get => id; set => id = value; }
    }
}
