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
        static List<Categorie> lesCategoriesModif;
        static List<Descripteur> lesDescripteurs;
        static List<Revue> lesTitres;
        static List<Livre> lesLivres;
        static List<Dvd> lesDvd;
        static List<collection> lesCollectionsModif;
        static List<collection> lesCollections;
        static List<TypeAbonnement> lesTypesAbonnements;
        static List<TypeAbonnement> lesTypesAbonnementsModifSupp;
        static List<Abonne> lesAbonnes;
        static List<Abonne> lesAbonnesModifSupp;

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

            
            //tabOngletsApplication.TabPages.Remove(tabDVD);

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
            //DAODocuments.setDescripteurs(lesLivres)
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
                    lblCollection.Text = livre.LaCollection.Libelle;
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
                    dgvLivres.Rows.Add(livre.IdDoc,livre.Titre,livre.Auteur,livre.ISBN1,livre.LaCollection.Libelle);
                }
            }
        }

        // CRUD LIVRE
        private void tabLivresCrud_Enter(object sender, EventArgs e)
        {
            lesCategories = DAODocuments.getAllCategories();
            lesLivres = DAODocuments.getAllLivres();

            lesCollections = DAODocuments.getAllCollection();
            lesCollectionsModif = DAODocuments.getAllCollection();

            dtLivre.Rows.Clear();
            //affichage des dvd dans le tableau 
            foreach (Livre unLivre in lesLivres)
            {
                //ajoute au tableau tout les livres
                dtLivre.Rows.Add(unLivre.Titre,unLivre.ISBN1,unLivre.Auteur,unLivre.LaCollection.Libelle,unLivre.Image,unLivre.LaCategorie.Libelle);
              

            }

            cbCHoixLivreEditSupp.DataSource = lesLivres;
            cbCHoixLivreEditSupp.DisplayMember = "titre";

            
            lesCategories = DAODocuments.getAllCategories();
            cbCategoLivre.Text = "chosir un catégorie";
            cbCategoLivre.DataSource = lesCategories;
            cbCategoLivre.DisplayMember = "Libelle";

            cbCollectionEditSupp.DataSource = lesCollectionsModif;
            cbCollectionEditSupp.DisplayMember = "libelle";

            cbCollection.DataSource = lesCollections;
            cbCollection.DisplayMember = "libelle";

            // cbbox catego modif/supp
            lesCategoriesModif = DAODocuments.getAllCategories();
            cbategoLivreEditSupp.DataSource = lesCategoriesModif;
            cbategoLivreEditSupp.DisplayMember = "libelle";

            


        }


        // ajouter livre btn
        private void btnAjouterLivre_Click(object sender, EventArgs e)
        {
            try
            {

                //declaration des variables du form ajouter dvd
                string idLivre = txIdLivre.Text;
                string titreLivre = txTitreLivre.Text;
                string ISBNLivre = txIsbnLivre.Text;
                string nomAuteurLivre = txAuteurLivre.Text;
                
                string imageLivre = txImageLivre.Text;
                //création de l'objer catégorie en fonction de la categorie choisi dans la combobox
                Categorie categoLivre = (Categorie)cbCategoLivre.SelectedItem;
                collection collection = (collection)cbCollection.SelectedItem;



                if (livreExsiteInCollection(txIdLivre.Text) == true)
                {
                    string message = "cette id exite deja";
                    const string caption = "attention";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Warning);

                }
                else
                {
                    //création du Livre
                    Livre livre = new Livre(idLivre, titreLivre, ISBNLivre, nomAuteurLivre, collection, imageLivre, categoLivre);

                    //insert du dvd dabs la bdd
                    DAODocuments.insertLivre(livre);

                    lesLivres = DAODocuments.getAllLivres();
                    //clear du tableau qui affiche les dvd
                    dtLivre.Rows.Clear();
                    //affichage des dvd dans le tableau 
                    foreach (Livre unLivre in lesLivres)
                    {
                        //ajoute au tableau tout les livres
                        dtLivre.Rows.Add(unLivre.Titre, unLivre.ISBN1, unLivre.Auteur, unLivre.LaCollection.Libelle, unLivre.Image, unLivre.LaCategorie.Libelle);


                    }

                    miseAjour();

                }




            }
            catch (Exception exc)
            {


            }
        }


        //modifier livre
        private void cbCHoixLivreEditSupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Livre unLivre = (Livre)cbCHoixLivreEditSupp.SelectedItem;

            txIdLivreEditSupp.Text  = unLivre.IdDoc;
            txtTitreLivreEditSupp.Text   = unLivre.Titre;
            txISBNLivreEditSupp.Text = unLivre.ISBN1;
            txAuteurLivreEditSupp.Text = unLivre.Auteur;
            cbCollectionEditSupp.Text = unLivre.LaCollection.Libelle;
            txImageLivreEditSupp.Text= unLivre.Image;
            cbategoLivreEditSupp.Text = unLivre.LaCategorie.Libelle;            

        }

        private void btnLivreEditModif_Click(object sender, EventArgs e)
        {

            Livre Livre = (Livre)cbCHoixLivreEditSupp.SelectedItem;

            //Waring qui permet de demander si on veut vraiment modifier le dvd
            string message = "etes vous sur de vouloir modifier le Livre " + Livre.Titre + " ?";
            const string caption = "vérification";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //creéation des variables avec contenue saisi des tx box
                string idLivreModifSupp = txIdLivreEditSupp.Text;
                string titreLivreModifSupp = txtTitreLivreEditSupp.Text;
                string ISBNLivreModifSupp = txISBNLivreEditSupp.Text;
                string nomAuteurLivreModifSupp = txAuteurLivreEditSupp.Text;
                
                string imageLivreModifSupp = txImageLivreEditSupp.Text;

                Categorie categodLivreModifSupp = (Categorie)cbategoLivreEditSupp.SelectedItem;
                collection collection = (collection)cbCollectionEditSupp.SelectedItem;

                //création du dvd
                Livre livre = new Livre(idLivreModifSupp, titreLivreModifSupp, ISBNLivreModifSupp, nomAuteurLivreModifSupp, collection, imageLivreModifSupp, categodLivreModifSupp);

                //appel de la fonction modifierDVD qui permet de modifier le dvd passer en parametre
                DAODocuments.ModifierLivre(livre);

                //actualisation de la liste lesDvd
                lesLivres = DAODocuments.getAllLivres();

                //clear du tableau qui affiche les dvd
                dtLivre.Rows.Clear();
                //affichage des dvd dans le tableau 
                foreach (Livre unLivre in lesLivres)
                {
                    //ajoute au tableau tout les livres
                    dtLivre.Rows.Add(unLivre.Titre, unLivre.ISBN1, unLivre.Auteur, unLivre.LaCollection.Libelle, unLivre.Image, unLivre.LaCategorie.Libelle);


                }


                miseAjour();

            }

        }
       
        //suprimer live
        private void btnSuppLivre_Click(object sender, EventArgs e)
        {
            Livre Livre = (Livre)cbCHoixLivreEditSupp.SelectedItem;

            //Waring qui permet de demander si on veut vraiment modifier le dvd
            string message = "etes vous sur de vouloir supprimer le Livre " + Livre.Titre + " ?";
            const string caption = "vérification";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //creéation des variables avec contenue saisi des tx box
                string idLivreModifSupp = txIdLivreEditSupp.Text;
                string titreLivreModifSupp = txtTitreLivreEditSupp.Text;
                string ISBNLivreModifSupp = txISBNLivreEditSupp.Text;
                string nomAuteurLivreModifSupp = txAuteurLivreEditSupp.Text;
                
                string imageLivreModifSupp = txImageLivreEditSupp.Text;
                Categorie categodLivreModifSupp = (Categorie)cbategoLivreEditSupp.SelectedItem;
                collection collection = (collection)cbCollectionEditSupp.SelectedItem;

                //création du dvd
                Livre livre = new Livre(idLivreModifSupp, titreLivreModifSupp, ISBNLivreModifSupp, nomAuteurLivreModifSupp, collection, imageLivreModifSupp, categodLivreModifSupp);

                //appel de la fonction modifierDVD qui permet de modifier le dvd passer en parametre
                DAODocuments.SupprimerLivre(livre);

                //actualisation de la liste lesDvd
                lesLivres = DAODocuments.getAllLivres();

                //clear du tableau qui affiche les dvd
                dtLivre.Rows.Clear();
                //affichage des dvd dans le tableau 
                foreach (Livre unLivre in lesLivres)
                {
                    //ajoute au tableau tout les livres
                    dtLivre.Rows.Add(unLivre.Titre, unLivre.ISBN1, unLivre.Auteur, unLivre.LaCollection.Libelle, unLivre.Image, unLivre.LaCategorie.Libelle);


                }


                miseAjour();

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

            //verifie si il existe des dvd
            existeDesDVD();

                  
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
            lesCategoriesModif = DAODocuments.getAllCategories();
            cbCategoDvdModifSupp.DataSource = lesCategoriesModif;
            cbCategoDvdModifSupp.DisplayMember = "libelle";
  
            
        }


        //-----------------------------------------------------------
        // ONGLET " btn Ajouter DVD" 
        //-----
        private void btAjouterDvd_Click(object sender, EventArgs e) 
        {

            try
            {
                
                //declaration des variables du form ajouter dvd
                string idDvd = txIddvd.Text;
                string TitreDvd = txTitreDvd.Text;
                string SysnopsisDvd = txSynopsisDvd.Text;
                string nomReaDvd = txNomReaDvd.Text;
                int dureeDvd = Int32.Parse(txDureeDvd.Text);
                string imageDvd = txImageDvd.Text;

 
                if (dvdExsiteInCollection(txIddvd.Text) == true)
                {
                    string message = "cette id exite deja";
                    const string caption = "attention";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Warning);

                }
                else
                {
                    //création de l'objet catégorie en fonction de la categorie choisi dans la combobox
                    Categorie categodvd = (Categorie)cbCategorieDvd.SelectedItem;

                    //création du dvd
                    Dvd dvd = new Dvd(idDvd, TitreDvd, SysnopsisDvd, nomReaDvd, dureeDvd, imageDvd, categodvd);

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

                    miseAjour();

                    existeDesDVD();


                }




            }
            catch(Exception exc)
            {

                
            }
            

        }

        //-----------------------------------------------------------
        // mofifier un dvd
        //-----
        private void cbChoixDvd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dvd dvdSelectionner = (Dvd)cbChoixDvd.SelectedItem;
            

                    int durreDvd = dvdSelectionner.Duree;
                    tbIdDvdModifSupp.Text= dvdSelectionner.IdDoc;
                    tbTitreDvdModifSupp.Text = dvdSelectionner.Titre;
                    tbSynopsisDvdModifSupp.Text = dvdSelectionner.Synopsis;
                    tbNomReaDvdModifSupp.Text = dvdSelectionner.Ralisateur;
                    tbDureeDvdModifSupp.Text = durreDvd.ToString();
                    tbImageDvdModifSupp.Text = dvdSelectionner.Image;
                    cbCategoDvdModifSupp.Text = dvdSelectionner.LaCategorie.Libelle;
                   



        }

        //btn modifier un dvd
        private void btnModifierDVD_Click(object sender, EventArgs e)
        {

            Dvd dvdSelectionner = (Dvd)cbChoixDvd.SelectedItem;

            //Waring qui permet de demander si on veut vraiment modifier le dvd
            string message ="etes vous sur de vouloir modifier le DVD "+dvdSelectionner.Titre+ " ?";
            const string caption = "vérification";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if(result==DialogResult.Yes)
            {
                //creéation des variables avec contenue saisi des tx box
                string idDvdModifSupp = tbIdDvdModifSupp.Text;
                string titreDvdModifSupp = tbTitreDvdModifSupp.Text;
                string synopsisDvdModifSupp = tbSynopsisDvdModifSupp.Text;
                string nomReaDvdModifSupp = tbNomReaDvdModifSupp.Text;
                int dureeDvdModifSupp = Int32.Parse(tbDureeDvdModifSupp.Text);
                string imageDvdModifSupp = tbImageDvdModifSupp.Text;
                Categorie categodvdModifSupp = (Categorie)cbCategoDvdModifSupp.SelectedItem;

                //création du dvd
                Dvd dvd = new Dvd(idDvdModifSupp, titreDvdModifSupp, synopsisDvdModifSupp, nomReaDvdModifSupp, dureeDvdModifSupp, imageDvdModifSupp, categodvdModifSupp);

                //appel de la fonction modifierDVD qui permet de modifier le dvd passer en parametre
                DAODocuments.ModifierDvd(dvd);

                //actualisation de la liste lesDvd
                lesDvd = DAODocuments.getAllDvd();

                //clear du tableau qui affiche les dvd
                dtDvd.Rows.Clear();

                //Affichage du tableau a jour
                foreach (Dvd unDVD in lesDvd)
                {
                    dtDvd.Rows.Add(unDVD.Synopsis, unDVD.Ralisateur, unDVD.Duree, unDVD.Titre, unDVD.Image, unDVD.LaCategorie.Libelle);

                }


                miseAjour();

            }
        }
        


        //-----------------------------------------------------------
        // supprimer un dvd
        //-----
        private void btnSuppDVD_Click(object sender, EventArgs e)
        {
            Dvd dvdSelectionner = (Dvd)cbChoixDvd.SelectedItem;

            //Waring qui permet de demander si on veut vraiment modifier le dvd
            string message = "êtes vous sur de supprimer le dvd " + dvdSelectionner.Titre + " ?";
            const string caption = "vérification";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //creéation des variables avec contenue saisi des tx box
                string idDvdModifSupp = tbIdDvdModifSupp.Text;
                string titreDvdModifSupp = tbTitreDvdModifSupp.Text;
                string synopsisDvdModifSupp = tbSynopsisDvdModifSupp.Text;
                string nomReaDvdModifSupp = tbNomReaDvdModifSupp.Text;
                int dureeDvdModifSupp = Int32.Parse(tbDureeDvdModifSupp.Text);
                string imageDvdModifSupp = tbImageDvdModifSupp.Text;
                Categorie categodvdModifSupp = (Categorie)cbCategoDvdModifSupp.SelectedItem;

                //création du dvd
                Dvd dvd = new Dvd(idDvdModifSupp, titreDvdModifSupp, synopsisDvdModifSupp, nomReaDvdModifSupp, dureeDvdModifSupp, imageDvdModifSupp, categodvdModifSupp);

                //appel de la fonction modifierDVD qui permet de modifier le dvd passer en parametre
                DAODocuments.SupprimerDvd(dvd);

                //actualisation de la liste lesDvd
                lesDvd = DAODocuments.getAllDvd();

                //clear du tableau qui affiche les dvd
                dtDvd.Rows.Clear();

                //Affichage du tableau a jour
                foreach (Dvd unDVD in lesDvd)
                {
                    dtDvd.Rows.Add(unDVD.Synopsis, unDVD.Ralisateur, unDVD.Duree, unDVD.Titre, unDVD.Image, unDVD.LaCategorie.Libelle);

                }

                miseAjour();

                //verifie si il existe des dvd
                existeDesDVD();

            }

        }
        #endregion

        #region abonne
        //-----------------------------------------------------------
        // ONGLET Abonne 
        //-----
        private void tabAbonneEnter(object sender, EventArgs e)
        {

            MaxDateDateTimePicker();
            lesAbonnes = DAOAbonne.getAllAbonne();
            

            //clear du tableu 
            dtAbonne.Rows.Clear();

            //affichage des abonne dans le tableau 
            foreach (Abonne abonne in lesAbonnes)
            {
                //ajoute au tableau tout les abonne
                dtAbonne.Rows.Add(abonne.Id,abonne.Nom,abonne.Prenom,abonne.Adresse,abonne.DateNaissance,abonne.AdresseMail,abonne.Telephone,abonne.DatePremierAbo,abonne.DateFinAbo,abonne.TypeAbonnement.Libelle) ;
                


            }
            // afficher les types d'abo dans la liste déroulante
            lesTypesAbonnements = DAOAbonne.getAllTypeAbonnement();
            lesTypesAbonnementsModifSupp = DAOAbonne.getAllTypeAbonnement();
            
            cbTypeAbonnement.Text = "choisir un type d'abonnement";
            cbTypeAbonnement.DataSource = lesTypesAbonnements;
            cbTypeAbonnement.DisplayMember = "libelle";

            cbChoixEditSuppAbonne.DataSource = lesAbonnes;
            cbChoixEditSuppAbonne.DisplayMember = "AdresseMail";

            cbTypeAboEditSuppAbonne.Text = "choisir un type d'abonnement";
            cbTypeAboEditSuppAbonne.DataSource = lesTypesAbonnementsModifSupp;
            cbTypeAboEditSuppAbonne.DisplayMember = "libelle";



        }

        /**
         * Creation abonne
         * **/
        private void btnAjouterAbo_Click(object sender, EventArgs e)
        {
            try
            {

                //declaration des variables du form ajouter dvd
                string idAbonne = tbIdAbonne.Text;
                string nomAbonne = tbNomAbonne.Text;
                string prenomAbonne = tbPrenomAbonne.Text;
                string adresseAbonne = tbAdrAbonne.Text;
                DateTime dateNaissanceAbonne = dtDateNaissanceAbo.Value;
                string adresseEmailAbonne = tbMailAbonne.Text;
                string telephoneAbonne =tbTelephoneAbonne.Text;
                DateTime dateAbonnement = dtDateAbo.Value;

                bool champsRemplis = VerifierChampsVides(idAbonne, nomAbonne, prenomAbonne, adresseAbonne, adresseEmailAbonne, telephoneAbonne);
                if (champsRemplis)
                {
                    if (AbonneExsiteInCollection(tbIdAbonne.Text) == true)
                    {
                        string message = "cette id exite deja";
                        const string caption = "attention";
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //création de l'objet typeAbonnement en function du type choisi dans la combobox
                        TypeAbonnement typeAbonnement = (TypeAbonnement)cbTypeAbonnement.SelectedItem;

                        //création de l'abonne
                        Abonne abo = new Abonne(idAbonne, nomAbonne, prenomAbonne, adresseAbonne, telephoneAbonne, adresseEmailAbonne, dateNaissanceAbonne, dateAbonnement, dateAbonnement, typeAbonnement);

                        //insert de l'abonne dabs la bdd
                        DAOAbonne.insertAbonne(abo);

                        //recuper la liste avec le nouveau abonne
                        lesAbonnes = DAOAbonne.getAllAbonne();

                        dtAbonne.Rows.Clear();

                        //affichage des abonne dans le tableau 
                        foreach (Abonne abonne in lesAbonnes)
                        {

                            dtAbonne.Rows.Add(abonne.Id, abonne.Nom, abonne.Prenom, abonne.Adresse, abonne.DateNaissance, abonne.AdresseMail, abonne.Telephone, abonne.DatePremierAbo, abonne.DateFinAbo, abonne.TypeAbonnement.Libelle);



                        }
                        miseAjour();
                        existeDesAbonne();
                    }

                }
                else
                {
                    string message = "vous devez remplir tout les champs.";
                    const string caption = "attention";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Warning);
                }
            }
            catch (Exception exc)
            {


            }

        }

        private void cbChoixEditSuppAbonne_SelectedIndexChanged(object sender, EventArgs e)
        {
            Abonne abonneSelectioner = (Abonne)cbChoixEditSuppAbonne.SelectedItem;


            tbIdEditSuppAbonne.Text = abonneSelectioner.Id;
            tbNomEditSuppAbonne.Text = abonneSelectioner.Nom;
            tbPrenomEditSuppAbonne.Text = abonneSelectioner.Prenom;
            tbAddrEditSuppAbonne.Text = abonneSelectioner.Adresse;
            dtDateNaissanceModifSuppAbo.Value = abonneSelectioner.DateNaissance;
            tbMailEditSuppAbonne.Text = abonneSelectioner.AdresseMail;
            tbTelephoneEditSuppAbonne.Text = abonneSelectioner.Telephone;
            dtModifSuppDateAbo.Value = abonneSelectioner.DatePremierAbo;
            cbTypeAboEditSuppAbonne.Text = abonneSelectioner.TypeAbonnement.Libelle;




        }

        /**
         * Modifier un Abonne
         * **/
        private void btnModifAbonne_Click(object sender, EventArgs e)
        {
            Abonne abonneSelect = (Abonne)cbChoixEditSuppAbonne.SelectedItem;
            //Waring qui permet de demander si on veut vraiment modifier le dvd
            string message = "etes vous sur de vouloir modifier l'abonne " + abonneSelect.AdresseMail + " ?";
            const string caption = "vérification";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //creéation des variables avec contenue saisi des tx box
                string idAbonne = tbIdEditSuppAbonne.Text;
                string nomAbo = tbNomEditSuppAbonne.Text;
                string prenomAbo = tbPrenomEditSuppAbonne.Text;
                string adresseAbo = tbAddrEditSuppAbonne.Text;
                DateTime dateNaissanceAbo= dtDateNaissanceModifSuppAbo.Value;
                string MailAbo = tbMailEditSuppAbonne.Text;
                string telephoneAbo =tbTelephoneEditSuppAbonne.Text;
                DateTime dateAbonemment = dtModifSuppDateAbo.Value;
                TypeAbonnement typeAbo = (TypeAbonnement)cbTypeAboEditSuppAbonne.SelectedItem; 

                //création du dvd
                Abonne abonneModif = new Abonne(idAbonne, nomAbo, prenomAbo, adresseAbo,telephoneAbo, MailAbo, dateNaissanceAbo ,dateAbonemment,dateAbonemment,typeAbo);

                //appel de la fonction modifierDVD qui permet de modifier le dvd passer en parametre
                DAOAbonne.ModifAbonne(abonneModif);

                //actualisation de la liste lesDvd
                lesAbonnes = DAOAbonne.getAllAbonne();

                dtAbonne.Rows.Clear();

                //affichage des abonne dans le tableau 
                foreach (Abonne abonne in lesAbonnes)
                {

                    dtAbonne.Rows.Add(abonne.Id, abonne.Nom, abonne.Prenom, abonne.Adresse, abonne.DateNaissance, abonne.AdresseMail, abonne.Telephone, abonne.DatePremierAbo, abonne.DateFinAbo, abonne.TypeAbonnement.Libelle);



                }
                miseAjour();

            }

        }
        #endregion

        //reset des txbox et mise a jour des combo box 
        public void miseAjour()
        {
            /**
            * Clear et mise a jour des abonne
            * **/

            tbIdAbonne.Text="";
            tbNomAbonne.Text = "";
            tbPrenomAbonne.Text = "";
            tbAdrAbonne.Text = "";
            dtDateNaissanceAbo.Value = DateTime.Today;
            tbMailAbonne.Text="";
            tbTelephoneAbonne.Text = "";
            dtDateAbo.Value = DateTime.Today;

            cbChoixEditSuppAbonne.DataBindings.Clear();
            cbChoixEditSuppAbonne.DataSource = lesAbonnes;
            cbChoixEditSuppAbonne.DisplayMember = "AdresseMail";

            /**
             * Clear et mise a jour des Livre 
             * **/

            txIdLivre.Text = ""; 
            txTitreLivre.Text = ""; 
            txIsbnLivre.Text = ""; 
            txAuteurLivre.Text = ""; 
            
            txImageLivre.Text = "";
            cbCategoLivre.Text = "chosir un categorie";

            txIdLivreEditSupp.Text = "";
            txtTitreLivreEditSupp.Text = "";
            txISBNLivreEditSupp.Text = "";
            txAuteurLivreEditSupp.Text = "";
            
            txImageLivreEditSupp.Text = "";
            cbategoLivreEditSupp.Text = "Choisir une categorie";

           cbCHoixLivreEditSupp.DataBindings.Clear();
            // afficher tout les dvd avec celui qu'on a ajouter
            cbCHoixLivreEditSupp.DataSource = lesLivres;
            cbCHoixLivreEditSupp.DisplayMember = "titre";


            /**
             * Clear et mise a jour des dvd 
             * **/
            //clear de la combo box de ajouter/supp dvd
            cbChoixDvd.DataBindings.Clear();
            // afficher tout les dvd avec celui qu'on a ajouter
            cbChoixDvd.DataSource = lesDvd;
            cbChoixDvd.DisplayMember = "titre";

            //clear des text box ajouter DVD
            txIddvd.Text = "";
            txTitreDvd.Text = "";
            txSynopsisDvd.Text = "";
            txNomReaDvd.Text = "";
            txDureeDvd.Text = "";
            txImageDvd.Text = "";

            //clear des text box modifier DVD
            tbIdDvdModifSupp.Text = "";
            tbTitreDvdModifSupp.Text = "";
            tbSynopsisDvdModifSupp.Text = "";
            tbNomReaDvdModifSupp.Text = "";
            tbDureeDvdModifSupp.Text = "";
            tbImageDvdModifSupp.Text = "";
            cbCategoDvdModifSupp.Text = "chosir un categorie";
            cbChoixDvd.Text = "chosir un dvd";
        }

        //mets le bouton griser de modif et supp si il existe pas de dvd
        public void existeDesDVD()
        {
            if (lesDvd.Count() == 0)
            {
                btnModifierDVD.Enabled = false;
                btnSuppDVD.Enabled = false;
            }
            else
            {
                btnModifierDVD.Enabled = true;
                btnSuppDVD.Enabled = true;
            }
        }
        public void existeDesLivre()
        {
            if (lesLivres.Count() == 0)
            {
                btnLivreEditModif.Enabled = false;
                btnSuppLivre.Enabled = false;
            }
            else
            {
                btnLivreEditModif.Enabled = true;
                btnSuppLivre.Enabled = true;
            }
        }
        public void existeDesAbonne()
        {
            if (lesAbonnes.Count() == 0)
            {
                btnModifAbonne.Enabled = false;
                btnSuppAbonne.Enabled = false;
            }
            else
            {
                btnModifAbonne.Enabled = true;
                btnSuppAbonne.Enabled = true;
            }
        }


        // permet de verifier si l'id passer en paramette existe pour undvd 
        public bool dvdExsiteInCollection(string idDVD)
        {
              bool resultat = false;
            foreach (Dvd unDVD in lesDvd)
            {
                if (unDVD.IdDoc == idDVD)
                {
                    resultat = true;
                }
                

            }
            return resultat;
        }

        public bool livreExsiteInCollection(string idLivre)
        {
            bool resultat = false;
            foreach (Livre unLivre in lesLivres)
            {
                if (unLivre.IdDoc == idLivre)
                {
                    resultat = true;
                }


            }
            return resultat;
        }
        public bool AbonneExsiteInCollection(string idAbonne)
        {
            bool resultat = false;
            foreach (Abonne unAbonne in lesAbonnes)
            {
                if (unAbonne.Id == idAbonne)
                {
                    resultat = true;
                }


            }
            return resultat;
        }
        public void MaxDateDateTimePicker()
        {
            
            dtDateNaissanceAbo.CustomFormat = "dd MMM yyyy";
            dtDateAbo.CustomFormat = "dd MMM yyyy";
            dtDateNaissanceModifSuppAbo.CustomFormat = "dd MMM yyyy";
            dtModifSuppDateAbo.CustomFormat = "dd MMM yyyy";
            dtDateNaissanceAbo.MaxDate = DateTime.Today;
            dtDateAbo.MaxDate = DateTime.Today;
            dtDateNaissanceModifSuppAbo.MaxDate = DateTime.Today;
            dtModifSuppDateAbo.MaxDate = DateTime.Today;
            dtDateNaissanceAbo.Value = DateTime.Today;
            dtDateAbo.Value = DateTime.Today;
            

        }

        

        public bool VerifierChampsVides(params string[] champs)
        {
            foreach (string champ in champs)
            {
                if (string.IsNullOrEmpty(champ))
                {
                    
                    return false; // Si le champ est vide, renvoie "false".
                }
                else if(string.IsNullOrWhiteSpace(champ))
                {
                    return false;
                }
            }       
            return true; // Si tous les champs sont remplis, renvoie "true".
        }
        private void dtDvd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }

    
}
