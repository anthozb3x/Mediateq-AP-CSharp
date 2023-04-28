using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    class Service
    {
        private string id;
        private string nomService;

        public Service(string id, string nomService)
        {
            this.id = id;
            this.nomService = nomService;
        }

        public string Id { get => id; set => id = value; }
        public string NomService { get => nomService; set => nomService = value; }
    }
}
