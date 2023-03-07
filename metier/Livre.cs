using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    class Livre : Document
    {
        private string ISBN;
        private string auteur;
        private collection laCollection;


        public Livre(string unId, string unTitre, string unISBN, string unAuteur, collection uneCollection,string uneImage, Categorie uneCategorie) : base(unId, unTitre, uneImage, uneCategorie)
        {
            ISBN1 = unISBN;
            Auteur = unAuteur;
            LaCollection = uneCollection;
        }

        public string ISBN1 { get => ISBN; set => ISBN = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        public collection LaCollection { get => laCollection; set => laCollection = value; }
    }
}
