using Mediateq_AP_SIO2.metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Globalization;

namespace Mediateq_AP_SIO2
{
    class DAOAbonne
    {
        public static List<Abonne> getAllAbonne() 
        {
            List<Abonne> lesAbonnes = new List<Abonne>();
            string req = "SELECT id, nom, prenom, adresse, numeroTel, adresseEmail, dateNaissance, dateAbonnement, idTypeAbonnement, typeabonnement.libelle FROM abonne JOIN typeabonnement ON abonne.idTypeAbonnement = typeabonnement.idType";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                DateTime dateAbo = Convert.ToDateTime(reader[7].ToString());
                
                DateTime dateFinAbo = Convert.ToDateTime(reader[7].ToString());
                dateFinAbo = dateFinAbo.AddDays(30);

                Abonne abonne = new Abonne(reader[0].ToString(),reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), dateAbo, dateFinAbo, new TypeAbonnement(reader[8].ToString(), reader[9].ToString()));
                lesAbonnes.Add(abonne);
            }
            DAOFactory.deconnecter();
            return lesAbonnes;

        }

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

        public static void insertAbonne(Abonne abonne)
        {

            try
            {
                string dateAbo = abonne.DatePremierAbo.ToString("yyyy-MM-dd");
                
                string req = "INSERT INTO abonne(id, nom, prenom,adresse,dateNaissance,adresseEmail,numeroTel,mdp,dateAbonnement,idTypeAbonnement) VALUES ('" + abonne.Id + "','" + abonne.Nom + "','" + abonne.Prenom + "','" + abonne.Adresse + "','" + abonne.DateNaissance.ToString() + "','" + abonne.AdresseMail + "','" + abonne.Telephone+ "','" + " " + "','" + dateAbo + "','" + abonne.TypeAbonnement.Id + "')";

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
