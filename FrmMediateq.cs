using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mediateq_AP_SIO2.metier;


namespace Mediateq_AP_SIO2
{
    public partial class FrmMediateq : Form
    {
        #region Variables globales

        static List<Categorie> lesCategories;
        static List<Descripteur> lesDescripteurs;
        static List<Revue> lesTitres;
        static List<Livre> lesLivres;
        static List<Dvd> lesDvd;

        #endregion


        #region Procédures évènementielles

        public FrmMediateq()
        {
            InitializeComponent();
        }

        private void FrmMediateq_Load(object sender, EventArgs e)
        {
            // Création de la connexion avec la base de données
            DAOFactory.creerConnection();

            // Chargement des objets en mémoire
            lesDescripteurs = DAODocuments.getAllDescripteurs();
            lesTitres = DAOPresse.getAllTitre();

        }

        #endregion


        #region Parutions
        //-----------------------------------------------------------
        // ONGLET "PARUTIONS"
        //------------------------------------------------------------
        private void tabParutions_Enter(object sender, EventArgs e)
        {
            cbxTitres.DataSource = lesTitres;
            cbxTitres.DisplayMember = "titre";
        }

        private void cbxTitres_SelectedIndexChanged(object sender, EventArgs e)
        {
                List<Parution> lesParutions;

                Revue titreSelectionne = (Revue)cbxTitres.SelectedItem;
                lesParutions = DAOPresse.getParutionByTitre(titreSelectionne);

                // ré-initialisation du dataGridView
                dgvParutions.Rows.Clear();

                // Parcours de la collection des titres et alimentation du datagridview
                foreach (Parution parution in lesParutions)
                {
                    dgvParutions.Rows.Add(parution.Numero, parution.DateParution, parution.Photo);
                }
            
        }
        #endregion


        #region Revues
        //-----------------------------------------------------------
        // ONGLET "TITRES"
        //------------------------------------------------------------
        private void tabTitres_Enter(object sender, EventArgs e)
        {
            cbxDomaines.DataSource = lesDescripteurs;
            cbxDomaines.DisplayMember = "libelle";
        }

        private void cbxDomaines_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Objet Domaine sélectionné dans la comboBox
            Descripteur domaineSelectionne = (Descripteur)cbxDomaines.SelectedItem;

            // ré-initialisation du dataGridView
            dgvTitres.Rows.Clear();

            // Parcours de la collection des titres et alimentation du datagridview
            foreach (Revue revue in lesTitres)
            {
                if (revue.IdDescripteur==domaineSelectionne.Id)
                {
                    dgvTitres.Rows.Add(revue.Id, revue.Titre, revue.Empruntable, revue.DateFinAbonnement, revue.DelaiMiseADispo);
                }
            }
        }
        #endregion


        #region Livres
        //-----------------------------------------------------------
        // ONGLET "LIVRES"
        //-----------------------------------------------------------

        private void tabLivres_Enter(object sender, EventArgs e)
        {
            // Chargement des objets en mémoire
            lesCategories = DAODocuments.getAllCategories();
            lesDescripteurs = DAODocuments.getAllDescripteurs();
            lesLivres = DAODocuments.getAllLivres();
            //DAODocuments.setDescripteurs(lesLivres);
        }
   
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            // On réinitialise les labels
            lblNumero.Text = "";
            lblTitre.Text = "";
            lblAuteur.Text = "";
            lblCollection.Text = "";
            lblISBN.Text = "";
            lblImage.Text = "";
            lblCategorie.Text = "";

            // On recherche le livre correspondant au numéro de document saisi.
            // S'il n'existe pas: on affiche un popup message d'erreur
            bool trouve = false;
            foreach (Livre livre in lesLivres)
            {
                if (livre.IdDoc==txbNumDoc.Text)
                {
                    lblNumero.Text = livre.IdDoc;
                    lblTitre.Text = livre.Titre;
                    lblAuteur.Text = livre.Auteur;
                    lblCollection.Text = livre.LaCollection;
                    lblISBN.Text = livre.ISBN1;
                    lblImage.Text = livre.Image;
                    lblCategorie.Text = livre.LaCategorie.Libelle;
                    trouve = true;
                }
            }
            if (!trouve)
                MessageBox.Show("Document non trouvé dans les livres");
        }

        private void txbTitre_TextChanged(object sender, EventArgs e)
        {
            dgvLivres.Rows.Clear();

            // On parcourt tous les livres. Si le titre matche avec la saisie, on l'affiche dans le datagrid.
            foreach (Livre livre in lesLivres)
            {
                // on passe le champ de saisie et le titre en minuscules car la méthode Contains
                // tient compte de la casse.
                string saisieMinuscules;
                saisieMinuscules = txbTitre.Text.ToLower();
                string titreMinuscules;
                titreMinuscules = livre.Titre.ToLower();

                //on teste si le titre du livre contient ce qui a été saisi
                if (titreMinuscules.Contains(saisieMinuscules))
                {
                    dgvLivres.Rows.Add(livre.IdDoc,livre.Titre,livre.Auteur,livre.ISBN1,livre.LaCollection);
                }
            }
        }
        #endregion


        #region DVD
        //-----------------------------------------------------------
        // ONGLET "Ajouter DVD" 
        //-----
        private void tabDVD_Enter(object sender, EventArgs e)
        {
            lesDvd = DAODocuments.getAllDvd();
            
            //clear du tableu et de la combo box 
            dtDvd.Rows.Clear();
            
            

            //affichage des dvd dans le tableau 
            foreach (Dvd dvd in lesDvd)
            {
                //ajoute au tableau tout les dvd
                dtDvd.Rows.Add(dvd.Synopsis, dvd.Ralisateur, dvd.Duree, dvd.Titre, dvd.Image, dvd.LaCategorie.Libelle);
                //ajoute a la comboxbox de modif/supp tout les dvd

                
            }
      
            //mets du text a la combobox de modif/supp dvd
            cbChoixDvd.DataSource = lesDvd;
            cbChoixDvd.DisplayMember = "titre";
            cbChoixDvd.Text = "choisir un DVD";

            // afficher les categories dans la liste deroulante
            lesCategories = DAODocuments.getAllCategories();
            cbCategorieDvd.Text = "chosir un catégorie";
            cbCategorieDvd.DataSource = lesCategories;
            cbCategorieDvd.DisplayMember = "Libelle";

            //afficher les categories dans la combobox modif/supp DVD
            cbCategoDvdModifSupp.DataSource = lesCategories;
            cbCategoDvdModifSupp.DisplayMember = "libelle";
  
            
        }


        // ajouter un DVD
        private void btAjouterDvd_Click(object sender, EventArgs e) 
        {

            //declaration des variables du form ajouter dvd
            string idDvd = txIddvd.Text;
            string TitreDvd = txTitreDvd.Text;
            string SysnopsisDvd = txSynopsisDvd.Text;
            string nomReaDvd = txNomReaDvd.Text;
            int dureeDvd = Int32.Parse(txDureeDvd.Text);
            string imageDvd = txImageDvd.Text;

            //création de l'objer catégorie en fonction de la categorie choisi dans la combobox
            Categorie categodvd =(Categorie)cbCategorieDvd.SelectedItem;
            
            //création du dvd
            Dvd dvd = new Dvd(idDvd, TitreDvd, SysnopsisDvd, nomReaDvd, dureeDvd, imageDvd,categodvd);

            //insert du dvd dabs la bdd
            DAODocuments.insertDvd(dvd);

            //recuper la liste avec le nouveau dvd
            lesDvd = DAODocuments.getAllDvd();

            //clear du tableau qui affiche les dvd
            dtDvd.Rows.Clear();


            foreach (Dvd unDVD in lesDvd)
            {
                dtDvd.Rows.Add(unDVD.Synopsis, unDVD.Ralisateur, unDVD.Duree, unDVD.Titre, unDVD.Image, unDVD.LaCategorie.Libelle);
             
            }

            // afficher tout les dvd avec celui qu'on a ajouter
            //clear de la combo box de ajouter/supp dvd
            cbChoixDvd.DataBindings.Clear();
            cbChoixDvd.DataSource = lesDvd;
            cbChoixDvd.DisplayMember = "titre";

        }

        //modifier un DVD 
        private void cbChoixDvd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dvd dvdSelectionner = (Dvd)cbChoixDvd.SelectedItem;
            

            foreach(Dvd unDvd in lesDvd)
            {
                if(unDvd.IdDoc == dvdSelectionner.IdDoc)
                {
                    int durreDvd = unDvd.Duree;
                    tbIdDvdModifSupp.Text= unDvd.IdDoc;
                    tbTitreDvdModifSupp.Text = unDvd.Titre;
                    tbSynopsisDvdModifSupp.Text = unDvd.Synopsis;
                    tbNomReaDvdModifSupp.Text = unDvd.Ralisateur;
                    tbDureeDvdModifSupp.Text = durreDvd.ToString();
                    tbImageDvdModifSupp.Text = unDvd.Image;
                    cbCategoDvdModifSupp.Text = unDvd.LaCategorie.Libelle;

                    
                   
                }
            }


        }
        private void btnModifierDVD_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void dtDvd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbEditionSuppDVD_Enter(object sender, EventArgs e)
        {

        }
    }
}
