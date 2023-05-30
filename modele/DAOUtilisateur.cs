using Mediateq_AP_SIO2.metier;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediateq_AP_SIO2.modele
{
    /// <summary>
    /// Classe représentant le Data Access Object (DAO) pour la gestion des Utilisateur du logiciel.
    /// </summary>
    class DAOUtilisateur
    {
        /// <summary>
        /// Récupère tous les utilisateurs.
        /// </summary>
        /// <returns>Une liste des utilisateurs.</returns>
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


        /// <summary>
        /// Récupère un utilisateur en fonction de son adresse e-mail.
        /// </summary>
        /// <param name="mail">L'adresse e-mail de l'utilisateur.</param>
        /// <returns>L'utilisateur correspondant à l'adresse e-mail spécifiée, ou null s'il n'existe pas.</returns>
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


        /// <summary>
        /// Récupère tous les services.
        /// </summary>
        /// <returns>Une liste des services.</returns>
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
