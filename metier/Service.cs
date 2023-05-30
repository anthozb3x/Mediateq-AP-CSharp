using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant un service.
    /// </summary>
    class Service
    {
        private string id;
        private string nomService;

        /// <summary>
        /// Constructeur de la classe Service.
        /// </summary>
        /// <param name="id">L'identifiant du service.</param>
        /// <param name="nomService">Le nom du service.</param>
        public Service(string id, string nomService)
        {
            this.id = id;
            this.nomService = nomService;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du service.
        /// </summary>
        public string Id { get => id; set => id = value; }

        /// <summary>
        /// Obtient ou définit le nom du service.
        /// </summary>
        public string NomService { get => nomService; set => nomService = value; }
    }
}
