using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant un document.
    /// </summary>
    class Document
    {
        private string idDoc;
        private string titre;
        private string image;
        private Categorie laCategorie;
        private List<Descripteur> lesDescripteurs;

        /// <summary>
        /// Constructeur de la classe Document.
        /// </summary>
        /// <param name="unId">L'identifiant du document.</param>
        /// <param name="unTitre">Le titre du document.</param>
        /// <param name="uneImage">L'image du document.</param>
        /// <param name="uneCategorie">La catégorie du document.</param>
        public Document(string unId, string unTitre, string uneImage, Categorie uneCategorie)
        {
            idDoc = unId;
            titre = unTitre;
            image = uneImage;
            laCategorie = uneCategorie;
        }

        /// <summary>
        /// Obtient ou définit l'identifiant du document.
        /// </summary>
        public string IdDoc { get => idDoc; set => idDoc = value; }

        /// <summary>
        /// Obtient ou définit le titre du document.
        /// </summary>
        public string Titre { get => titre; set => titre = value; }

        /// <summary>
        /// Obtient ou définit l'image du document.
        /// </summary>
        public string Image { get => image; set => image = value; }

        /// <summary>
        /// Obtient ou définit la catégorie du document.
        /// </summary>
        internal Categorie LaCategorie { get => laCategorie; set => laCategorie = value; }

        /// <summary>
        /// Obtient ou définit la liste des descripteurs du document.
        /// </summary>
        internal List<Descripteur> LesDescripteurs { get => lesDescripteurs; set => lesDescripteurs = value; }
    }
}
