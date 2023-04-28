using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mediateq_AP_SIO2.modele;
using Mediateq_AP_SIO2.metier;
using System.Security.Cryptography;

namespace Mediateq_AP_SIO2
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void Connexion_Load(object sender, EventArgs e)
        {
            DAOFactory.creerConnection();
            

        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string email = txbEmailCo.Text;
            string mdp = txbMdp.Text;
            Utilisateur utilisateur=  DAOUtilisateur.getUtilisateurByMail(email);

            SHA256Managed hashString = new SHA256Managed();
           

            string hashmdp = ComputeSha256Hash(mdp);
            if ( hashmdp == utilisateur.Mdp)
            {
                FrmMediateq FrmMediateq = new FrmMediateq();
                TabControl tabControl = (TabControl)FrmMediateq.Controls["tabOngletsApplication"];
                TabPage tabPageVisuDVD = tabControl.TabPages["tabPageDVD"];
                TabPage tabPageCrudDVD = tabControl.TabPages["tabDVD"];
                TabPage tabPageCrudLire = tabControl.TabPages["tabPageCrudLivre"];
                TabPage tabPageAbonne = tabControl.TabPages["tabPageAbonne"];
                


                if (utilisateur.Service.NomService == "Administratif")
                {
                    tabControl.TabPages.Remove(tabPageAbonne);
                    
                }
                else if(utilisateur.Service.NomService == "Prêts")
                {
                    tabControl.TabPages.Remove(tabPageCrudDVD);
                    tabControl.TabPages.Remove(tabPageCrudLire);
                    tabControl.TabPages.Remove(tabPageAbonne);

                }
                else if (utilisateur.Service.NomService == "Culture")
                {
                    tabControl.TabPages.Remove(tabPageCrudDVD);
                    tabControl.TabPages.Remove(tabPageCrudLire);
                    tabControl.TabPages.Remove(tabPageAbonne);

                }
                FrmMediateq.Show();
                this.Close();

            }
         
        }


        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
