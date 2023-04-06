using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    class collection
    {
        private string id;
        private string libelle;

        public collection(string id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        public string Libelle { get => libelle; set => libelle = value; }
        public string Id { get => id; set => id = value; }
    }
}
