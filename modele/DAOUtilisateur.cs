using Mediateq_AP_SIO2.metier;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.modele
{
    class DAOUtilisateur
    {

        public static List<Utilisateur> getUtilisateur()
        {

            List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();
            string req = "SELECT utilisateur.id,nom,prenom,email,mdp,service.id, service.nomService FROM utilisateur JOIN service ON id_service = service.id";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {

                Service service = new Service(reader[5].ToString(), reader[6].ToString());
                Utilisateur utilisateur = new Utilisateur(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), service);
                lesUtilisateurs.Add(utilisateur);
            }
            DAOFactory.deconnecter();
            return lesUtilisateurs;


        }

      


        public static Utilisateur getUtilisateurByMail(string mail)
        {
            Utilisateur utilisateur = null;
            string req = "SELECT utilisateur.id,nom,prenom,email,mdp,service.id, service.nomService FROM utilisateur JOIN service ON id_service = service.id WHERE email ='" + mail + "'";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read()) { 

                Service service = new Service(reader[5].ToString(), reader[6].ToString());
                utilisateur = new Utilisateur(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), service);
                
            }
            DAOFactory.deconnecter();
            return utilisateur;
            


        }


        public static List<Service> getAllService()
        {
            List<Service> services = new List<Service>();
            string req = "SELECT id,nomService FROM service";

            DAOFactory.connecter();

            MySqlDataReader reader = DAOFactory.execSQLRead(req);

            while (reader.Read())
            {

                Service service = new Service(reader[0].ToString(), reader[1].ToString());

                services.Add(service);
            }
            DAOFactory.deconnecter();
            return services;

        }



    }
       
}
