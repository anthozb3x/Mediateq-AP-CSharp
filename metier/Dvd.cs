using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.metier
{
    /// <summary>
    /// Classe représentant un DVD, héritant de la classe Document.
    /// </summary>
    class Dvd : Document
    {
        private string synopsis;
        private string realisateur;
        private int duree;

        /// <summary>
        /// Constructeur de la classe Dvd.
        /// </summary>
        /// <param name="unId">L'identifiant du DVD.</param>
        /// <param name="unTitre">Le titre du DVD.</param>
        /// <param name="unSynopsis">Le synopsis du DVD.</param>
        /// <param name="unRealisateur">Le réalisateur du DVD.</param>
        /// <param name="uneDuree">La durée du DVD.</param>
        /// <param name="uneImage">L'image du DVD.</param>
        /// <param name="uneCategorie">La catégorie du DVD.</param>
        public Dvd(string unId, string unTitre, string unSynopsis, string unRealisateur, int uneDuree, string uneImage, Categorie uneCategorie) : base(unId, unTitre, uneImage, uneCategorie)
        {
            synopsis = unSynopsis;
            realisateur = unRealisateur;
            duree = uneDuree;
        }

        /// <summary>
        /// Obtient ou définit le synopsis du DVD.
        /// </summary>
        public string Synopsis { get => synopsis; set => synopsis = value; }

        /// <summary>
        /// Obtient ou définit le réalisateur du DVD.
        /// </summary>
        public string Ralisateur { get => realisateur; set => realisateur = value; }

        /// <summary>
        /// Obtient ou définit la durée du DVD.
        /// </summary>
        public int Duree { get => duree; set => duree = value; }
    }
}
