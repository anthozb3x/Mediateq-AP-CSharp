using Mediateq_AP_SIO2.metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Mediateq_AP_SIO2.modele
{
    class DAOAbonne
    {
        public static List<Abonne> getAllAbonne() 
        {
            List<Abonne> lesAbonnes = new List<Abonne>();
            string req = "SELECT nom, prenom, adresse, numeroTel, adresseEmail, dateNaissance, dateAbonnement, idTypeAbonnement, typeabonnement.libelle FROM abonne JOIN typeabonnement ON abonne.idTypeAbonnement = typeabonnement.idType";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {
                DateTime dateFinAbo = (DateTime)reader[6];
                dateFinAbo = dateFinAbo.AddDays(30);

                Abonne abonne = new Abonne(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), dateFinAbo, new TypeAbonnement(reader[7].ToString(), reader[8].ToString()));
                lesAbonnes.Add(abonne);
            }
            DAOFactory.deconnecter();
            return lesAbonnes;

        }
    }
}
