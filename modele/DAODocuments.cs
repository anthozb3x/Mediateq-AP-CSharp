﻿using Mediateq_AP_SIO2.metier;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2
{
    class DAODocuments
    {
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
        
        public static List<Livre> getAllLivres()
        {
            List<Livre> lesLivres = new List<Livre>();
            string req = "Select l.id, l.ISBN, l.auteur, d.titre, d.image, l.collection, d.idCategorie, c.libelle from livre l ";
            req += " join document d on l.id=d.id";
            req += " join categorie c on d.idCategorie = c.id";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                Livre livre = new Livre(reader[0].ToString(), reader[3].ToString(), reader[1].ToString(),
                reader[2].ToString(), reader[5].ToString(), reader[4].ToString(),new Categorie(reader[6].ToString(),reader[7].ToString()));
  
                lesLivres.Add(livre);
                
            }

            DAOFactory.deconnecter();

            return lesLivres;
        }

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


        //renvoie une list de tout les dvd
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

        

        public static void insertDvd(Dvd dvd)
        {
            string req2 = "INSERT INTO document(id, titre, image, idCategorie) VALUES ('" + dvd.IdDoc + "','" + dvd.Titre + "','" + dvd.Image + "','"+ dvd.LaCategorie.Id+"')";
            string req = "INSERT INTO dvd(id, synopsis, réalisateur,duree) VALUES ('" + dvd.IdDoc + "','" + dvd.Synopsis + "','" + dvd.Ralisateur + "','" + dvd.Duree + "')";



            DAOFactory.connecter();

            DAOFactory.execSQLWrite(req2);
            DAOFactory.execSQLWrite(req);



            DAOFactory.deconnecter();
        }

    }

}
