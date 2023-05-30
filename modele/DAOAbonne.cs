using Mediateq_AP_SIO2.metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Mediateq_AP_SIO2.modele
{
    /// <summary>
    /// Classe représentant le Data Access Object (DAO) pour la gestion des abonnés.
    /// </summary>
    class DAOAbonne
    {
        /// <summary>
        /// Récupère tous les abonnés.
        /// </summary>
        /// <returns>Une liste d'objets Abonne représentant tous les abonnés.</returns>
        public static List<Abonne> getAllAbonne() 
        {
            List<Abonne> lesAbonnes = new List<Abonne>();
            string req = "SELECT id, nom, prenom, adresse, numeroTel, adresseEmail, dateNaissance, dateAbonnement, idTypeAbonnement, typeabonnement.libelle FROM abonne JOIN typeabonnement ON abonne.idTypeAbonnement = typeabonnement.idType";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                DateTime dateNaissance = Convert.ToDateTime(reader[6].ToString());
                DateTime dateAbo = Convert.ToDateTime(reader[7].ToString());
                
                DateTime dateFinAbo = Convert.ToDateTime(reader[7].ToString());
                dateFinAbo = dateFinAbo.AddDays(50);

                Abonne abonne = new Abonne(reader[0].ToString(),reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), dateNaissance, dateAbo, dateFinAbo, new TypeAbonnement(reader[8].ToString(), reader[9].ToString()));
                lesAbonnes.Add(abonne);
            }
            DAOFactory.deconnecter();
            return lesAbonnes;

        }


        /// <summary>
        /// Récupère tous les types d'abonnement.
        /// </summary>
        /// <returns>Une liste d'objets TypeAbonnement représentant tous les types d'abonnement.</returns>
        public static List<TypeAbonnement> getAllTypeAbonnement()
        {
            List<TypeAbonnement> lesTypesAbonnement = new List<TypeAbonnement>();
            string req = "SELECT idType, libelle FROM typeabonnement";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                TypeAbonnement typeAbo = new TypeAbonnement(reader[0].ToString(), reader[1].ToString());
                lesTypesAbonnement.Add(typeAbo);
            }
            DAOFactory.deconnecter();
            return lesTypesAbonnement;

        }
        /// <summary>
        /// Insère un nouvel abonné.
        /// </summary>
        /// <param name="abonne">L'objet Abonne à insérer.</param>
        public static void InsertAbonne(Abonne abonne)
        {

            try
            {
                string dateAbo = abonne.DatePremierAbo.ToString("yyyy-MM-dd");
                string dateNaissance = abonne.DateNaissance.ToString("yyyy-MM-dd");


                string req = "INSERT INTO abonne(id, nom, prenom,adresse,dateNaissance,adresseEmail,numeroTel,mdp,dateAbonnement,idTypeAbonnement) VALUES ('" + abonne.Id + "','" + abonne.Nom + "','" + abonne.Prenom + "','" + abonne.Adresse + "','" + dateNaissance + "','" + abonne.AdresseMail + "','" + abonne.Telephone+ "','" + " " + "','" + dateAbo + "','" + abonne.TypeAbonnement.Id + "')";

                DAOFactory.connecter();

                DAOFactory.execSQLWrite(req);

                DAOFactory.deconnecter();

            }
            catch (Exception exc)
            {
                throw exc;
            }


        }
        /// <summary>
        /// Modifie les informations d'un abonné.
        /// </summary>
        /// <param name="abonne">L'objet Abonne à modifier.</param>
        public static void ModifAbonne(Abonne abonne)
        {

            try
            {

                string dateAbo = abonne.DatePremierAbo.ToString("yyyy-MM-dd");
                string dateNaissance = abonne.DateNaissance.ToString("yyyy-MM-dd");
                string req = "UPDATE abonne SET id='" + abonne.Id + "', nom='" + abonne.Nom + "', prenom='" + abonne.Prenom + "',adresse='" + abonne.Adresse + "',dateNaissance='" + dateNaissance + "',adresseEmail='" + abonne.AdresseMail + "',numeroTel='" + abonne.Telephone + "',dateAbonnement='" + dateAbo + "',idTypeAbonnement='" + abonne.TypeAbonnement.Id + "' WHERE id= '" + abonne.Id + "'";

                DAOFactory.connecter();
                DAOFactory.execSQLWrite(req);
                DAOFactory.deconnecter();

            }
            catch (Exception exc)
            {
                string message = exc.Message;
                const string caption = "attention";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning);
                throw exc;
            }


        }

        /// <summary>
        /// Supprime un abonné.
        /// </summary>
        /// <param name="abonne">L'objet Abonne à supprimer.</param>
        public static void SupprimerAbonne(Abonne abonne)
        {
            try
            {
                string req = "DELETE FROM abonne WHERE id='" + abonne.Id + "'";
                DAOFactory.connecter();
                DAOFactory.execSQLWrite(req);
                DAOFactory.deconnecter();
            }
            catch (Exception exc)
            {
                throw exc;

            }

            
        }

    }

}
