﻿using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.modele
{
    /// <summary>
    /// Classe représentant le Data Access Object (DAO) pour la gestion des documents.
    /// </summary>
    class DAODocuments
    {
        /// <summary>
        /// Récupère toutes les catégories de documents.
        /// </summary>
        /// <returns>Une liste d'objets Categorie représentant toutes les catégories de documents.</returns>
        public static List<Categorie> getAllCategories()
        {
            List<Categorie> lesCategories = new List<Categorie>();
            string req = "Select * from categorie";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                Categorie categorie = new Categorie(reader[0].ToString(), reader[1].ToString());
                lesCategories.Add(categorie);
            }
            DAOFactory.deconnecter();
            return lesCategories;
        }

        /// <summary>
        /// Récupère toutes les collections de documents.
        /// </summary>
        /// <returns>Une liste d'objets collection représentant toutes les collections de documents.</returns>
        public static List<collection> getAllCollection()
        {
            List<collection> lesCollection= new List<collection>();
            string req = "Select * from collection";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                collection collection = new collection(reader[0].ToString(), reader[1].ToString());
                lesCollection.Add(collection);
            }
            DAOFactory.deconnecter();
            return lesCollection;
        }
        /// <summary>
        /// Récupère tous les descripteurs de documents.
        /// </summary>
        /// <returns>Une liste d'objets Descripteur représentant tous les descripteurs de documents.</returns>
        public static List<Descripteur> getAllDescripteurs()
        {
            List<Descripteur> lesDescripteurs = new List<Descripteur>();
            string req = "Select * from descripteur";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                Descripteur genre = new Descripteur(reader[0].ToString(), reader[1].ToString());
                lesDescripteurs.Add(genre);
            }
            DAOFactory.deconnecter();
            return lesDescripteurs;
        }

        /// <summary>
        /// Récupère tous les livres.
        /// </summary>
        /// <returns>Une liste d'objets Livre représentant tous les livres.</returns>
        public static List<Livre> getAllLivres()
        {
            List<Livre> lesLivres = new List<Livre>();
            string req = "Select l.id, l.ISBN, l.auteur, d.titre, d.image, d.idCategorie, c.libelle, collection.id, collection.libelle from livre l ";
            req += " join document d on l.id=d.id";
            req += " join categorie c on d.idCategorie = c.id";
            req += " LEFT JOIN collection ON l.id_collection = collection.id";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                
                Livre livre = new Livre(reader[0].ToString(), reader[3].ToString(), reader[1].ToString(),
                reader[2].ToString(), new collection(reader[7].ToString(),reader[8].ToString()), reader[4].ToString(),new Categorie(reader[5].ToString(),reader[6].ToString()));
  
                lesLivres.Add(livre);
                
            }

            DAOFactory.deconnecter();

            return lesLivres;
        }

        /// <summary>
        /// Récupère les descripteurs d'un livre.
        /// </summary>
        /// <param name="lesLivres">Une liste d'objets Livre pour lesquels on souhaite récupérer les descripteurs.</param>
        public static void setDescripteurs(List<Livre> lesLivres)
        {
            DAOFactory.connecter();

            foreach (Livre livre in lesLivres)
            {
                List<Descripteur> lesDescripteursDuLivre = new List<Descripteur>(); ;
                string req = "Select de.id, de.libelle from descripteur de ";
                req += " join est_decrit_par e on de.id = e.idDesc";
                req += " join document do on do.id = '" + livre.IdDoc + "'";
                             
                MySqlDataReader reader = DAOFactory.execSQLRead(req);
                while (reader.Read())
                {
                    lesDescripteursDuLivre.Add(new Descripteur(reader[0].ToString(), reader[1].ToString()));
                }
                livre.LesDescripteurs = lesDescripteursDuLivre;
            }
            DAOFactory.deconnecter();
        }

        /// <summary>
        /// Récupère la catégorie d'un livre.
        /// </summary>
        /// <param name="pLivre">Un objet Livre pour lequel on souhaite récupérer la catégorie.</param>
        /// <returns>Un objet Categorie représentant la catégorie du livre.</returns>
        public static Categorie getCategorieByLivre(Livre pLivre)
        {
            Categorie categorie;
            string req = "Select c.id,c.libelle from categorie c,document d where c.id = d.idCategorie and d.id='";
            req += pLivre.IdDoc + "'";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            if (reader.Read())
            {
                categorie = new Categorie(reader[0].ToString(), reader[1].ToString());
            }
            else
            {
                categorie = null;
            }
            DAOFactory.deconnecter();
            return categorie;
        }


        /// <summary>
        /// Récupère tous les DVD.
        /// </summary>
        /// <returns>Une liste d'objets Dvd représentant tous les DVD.</returns>
        public static List<Dvd> getAllDvd()
        {
            List<Dvd> lesDvd = new List<Dvd>();

            try
            {
                string req = "Select dvd.id, dvd.synopsis, dvd.réalisateur, dvd.duree, document.titre, document.image,categorie.id, categorie.libelle from dvd join document on dvd.id=document.id JOIN categorie ON document.idCategorie = categorie.id";

                DAOFactory.connecter();

                MySqlDataReader reader = DAOFactory.execSQLRead(req);
                

                while (reader.Read())
                {
                    Categorie cate = new Categorie(reader[6].ToString(), reader[7].ToString());
                    // On ne renseigne pas le genre et la catégorie car on ne peut pas ouvrir 2 dataReader dans la même connexion
                    Dvd dvd = new Dvd(reader[0].ToString(), reader[4].ToString(), reader[1].ToString(),
                        reader[2].ToString(), int.Parse(reader[3].ToString()), reader[5].ToString(),cate);
                    lesDvd.Add(dvd);
                }
                DAOFactory.deconnecter();


            }

            catch (Exception exc)
            {
                throw exc;
            }

            return lesDvd;

        }

        /// <summary>
        /// Insère un livre dans la base de données.
        /// </summary>
        /// <param name="livre">L'objet Livre à insérer.</param>
        public static void insertLivre(Livre livre)
        {

            try
            {
                string req2 = "INSERT INTO document(id, titre, image, idCategorie) VALUES ('" + livre.IdDoc + "','" + livre.Titre + "','" + livre.Image + "','" + livre.LaCategorie.Id + "')";
                string req = "INSERT INTO livre(id, ISBN, auteur,id_collection) VALUES ('" + livre.IdDoc + "','" + livre.ISBN1 + "','" + livre.Auteur + "','" + livre.LaCollection.Id + "')";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req2);
                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();

            }
            catch (Exception exc)
            {
                throw exc;
            }


        }

        /// <summary>
        /// Modifie un livre dans la base de données.
        /// </summary>
        /// <param name="livre">L'objet Livre à modifier.</param>
        public static void ModifierLivre(Livre livre)
        {

            try
            {

                string req2 = "UPDATE document SET id = '" + livre.IdDoc + "', titre='" + livre.Titre + "',image= '" + livre.Image + "',idCategorie='" + livre.LaCategorie.Id + "' WHERE id = '" + livre.IdDoc + "'";
                string req = "UPDATE livre SET id='" + livre.IdDoc + "', ISBN='" + livre.ISBN1 + "', auteur='" + livre.Auteur + "',id_collection='" + livre.LaCollection.Id + "' WHERE id= '" + livre.IdDoc + "'";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req2);
                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();

            }
            catch (Exception exc)
            {
                throw exc;
            }


        }

        /// <summary>
        /// Insère un DVD dans la base de données.
        /// </summary>
        /// <param name="dvd">L'objet Dvd à insérer.</param>
        public static void insertDvd(Dvd dvd)
        {

            try
            {
                string req2 = "INSERT INTO document(id, titre, image, idCategorie) VALUES ('" + dvd.IdDoc + "','" + dvd.Titre + "','" + dvd.Image + "','" + dvd.LaCategorie.Id + "')";
                string req = "INSERT INTO dvd(id, synopsis, réalisateur,duree) VALUES ('" + dvd.IdDoc + "','" + dvd.Synopsis + "','" + dvd.Ralisateur + "','" + dvd.Duree + "')";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req2);
                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();

            }
            catch (Exception exc)
            {
                throw exc;
            }


        }
        /// <summary>
        /// Supprime un livre de la base de données.
        /// </summary>
        /// <param name="livre">L'objet Livre à supprimer.</param>
        public static void SupprimerLivre(Livre livre)
        {

            try
            {
                string req = "DELETE FROM livre WHERE id='" + livre.IdDoc + "'";
                string req2 = "DELETE FROM document WHERE id ='" + livre.IdDoc + "'";


                DAOFactory.connecter();


                DAOFactory.execSQLWrite(req);
                DAOFactory.execSQLWrite(req2);

                DAOFactory.deconnecter();

            }
            catch (Exception exc)
            {
                throw exc;
            }


        }

        /// <summary>
        /// Modifie un DVD dans la base de données.
        /// </summary>
        /// <param name="dvd">L'objet Dvd à modifier.</param>
        public static void ModifierDvd(Dvd dvd)
        {

            try
            {
         
                string req2 = "UPDATE document SET id = '" + dvd.IdDoc + "', titre='" + dvd.Titre + "',image= '" + dvd.Image + "',idCategorie='" + dvd.LaCategorie.Id + "' WHERE id = '" + dvd.IdDoc + "'";
                string req = "UPDATE dvd SET id='" + dvd.IdDoc + "', synopsis='" + dvd.Synopsis + "', réalisateur='" + dvd.Ralisateur + "',duree='" + dvd.Duree + "' WHERE id= '" + dvd.IdDoc + "'";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req2);
                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();

            }
            catch (Exception exc)
            {
                throw exc;
            }


        }

        /// <summary>
        /// Supprime un DVD de la base de données.
        /// </summary>
        /// <param name="dvd">L'objet Dvd à supprimer.</param>
        public static void SupprimerDvd(Dvd dvd)
        {

            try
            {
                string req = "DELETE FROM dvd WHERE id='" + dvd.IdDoc + "'";
                string req2 = "DELETE FROM document WHERE id ='" + dvd.IdDoc + "'";
                

                DAOFactory.connecter();

                
                DAOFactory.execSQLWrite(req);
                DAOFactory.execSQLWrite(req2);

                DAOFactory.deconnecter();

            }
            catch (Exception exc)
            {
                throw exc;
            }


        }

    }

}
