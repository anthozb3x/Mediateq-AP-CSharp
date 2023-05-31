using System;
using MySql.Data.MySqlClient;
using Mediateq_AP_SIO2.divers;

namespace Mediateq_AP_SIO2
{
    /// <summary>
    /// Classe représentant une fabrique de DAO.
    /// </summary>
    class DAOFactory
    {
        private static MySqlConnection connexion;

        /// <summary>
        /// Crée une connexion à la base de données.
        /// </summary>
        public static void creerConnection()
        {
            string serverIp = "127.0.0.1";
            string username = "root";
            string password = "";
            string databaseName = "mediateq";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            try
            {
                connexion = new MySqlConnection(dbConnectionString);
            }
            catch (Exception e)
            {
                throw new ExceptionSio(1, "problème création connexion BDD", e.Message);
            }
        }

        /// <summary>
        /// Établit la connexion à la base de données.
        /// </summary>
        public static void connecter()
        {
            try
            {
                connexion.Open();
            }
            catch (Exception e)
            {
                throw new ExceptionSio(1, "problème ouverture connexion BDD", e.Message);
            }
        }

        /// <summary>
        /// Ferme la connexion à la base de données.
        /// </summary>
        public static void deconnecter()
        {
            connexion.Close();
        }

        /// <summary>
        /// Exécute une requête de lecture et retourne un DataReader.
        /// </summary>
        /// <param name="requete">La requête SQL à exécuter.</param>
        /// <returns>Un DataReader contenant les résultats de la requête.</returns>
        public static MySqlDataReader execSQLRead(string requete)
        {
            MySqlCommand command;
            MySqlDataAdapter adapter;
            command = new MySqlCommand();
            command.CommandText = requete;
            command.Connection = connexion;

            adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;

            MySqlDataReader dataReader;

            try
            {
                dataReader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new ExceptionSio(1, "Erreur lecture BDD", e.Message);
            }

            return dataReader;
        }

        /// <summary>
        /// Exécute une requête d'écriture (Insert ou Update).
        /// </summary>
        /// <param name="requete">La requête SQL à exécuter.</param>
        public static void execSQLWrite(string requete)
        {
            MySqlCommand command;
            command = new MySqlCommand();
            command.CommandText = requete;
            command.Connection = connexion;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new ExceptionSio(1, "Erreur écriture BDD", e.Message);
            }
        }
    }
}
