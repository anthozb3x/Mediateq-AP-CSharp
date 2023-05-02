
namespace Mediateq_AP_SIO2
{
    partial class Connexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbConnexion = new System.Windows.Forms.Label();
            this.GbConnxion = new System.Windows.Forms.GroupBox();
            this.txbMdp = new System.Windows.Forms.TextBox();
            this.lbMdp = new System.Windows.Forms.Label();
            this.txbEmailCo = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.GbConnxion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbConnexion
            // 
            this.lbConnexion.AutoSize = true;
            this.lbConnexion.Font = new System.Drawing.Font("Verdana Pro Cond", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConnexion.Location = new System.Drawing.Point(110, 9);
            this.lbConnexion.Name = "lbConnexion";
            this.lbConnexion.Size = new System.Drawing.Size(156, 40);
            this.lbConnexion.TabIndex = 0;
            this.lbConnexion.Text = "Mediateq";
            // 
            // GbConnxion
            // 
            this.GbConnxion.BackColor = System.Drawing.Color.Transparent;
            this.GbConnxion.Controls.Add(this.txbMdp);
            this.GbConnxion.Controls.Add(this.lbMdp);
            this.GbConnxion.Controls.Add(this.txbEmailCo);
            this.GbConnxion.Controls.Add(this.lbEmail);
            this.GbConnxion.Controls.Add(this.btnConnexion);
            this.GbConnxion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GbConnxion.Location = new System.Drawing.Point(38, 133);
            this.GbConnxion.Name = "GbConnxion";
            this.GbConnxion.Size = new System.Drawing.Size(290, 285);
            this.GbConnxion.TabIndex = 1;
            this.GbConnxion.TabStop = false;
            // 
            // txbMdp
            // 
            this.txbMdp.Location = new System.Drawing.Point(88, 107);
            this.txbMdp.Name = "txbMdp";
            this.txbMdp.Size = new System.Drawing.Size(165, 20);
            this.txbMdp.TabIndex = 4;
            // 
            // lbMdp
            // 
            this.lbMdp.AutoSize = true;
            this.lbMdp.Location = new System.Drawing.Point(43, 110);
            this.lbMdp.Name = "lbMdp";
            this.lbMdp.Size = new System.Drawing.Size(37, 13);
            this.lbMdp.TabIndex = 3;
            this.lbMdp.Text = "MDP :";
            // 
            // txbEmailCo
            // 
            this.txbEmailCo.Location = new System.Drawing.Point(88, 69);
            this.txbEmailCo.Name = "txbEmailCo";
            this.txbEmailCo.Size = new System.Drawing.Size(165, 20);
            this.txbEmailCo.TabIndex = 2;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(43, 69);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(38, 13);
            this.lbEmail.TabIndex = 1;
            this.lbEmail.Text = "Email :";
            // 
            // btnConnexion
            // 
            this.btnConnexion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnexion.Location = new System.Drawing.Point(72, 236);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(136, 23);
            this.btnConnexion.TabIndex = 0;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 524);
            this.Controls.Add(this.GbConnxion);
            this.Controls.Add(this.lbConnexion);
            this.Name = "Connexion";
            this.Text = "Connexion Médiateq";
            this.Load += new System.EventHandler(this.Connexion_Load);
            this.GbConnxion.ResumeLayout(false);
            this.GbConnxion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbConnexion;
        private System.Windows.Forms.GroupBox GbConnxion;
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.TextBox txbMdp;
        private System.Windows.Forms.Label lbMdp;
        private System.Windows.Forms.TextBox txbEmailCo;
        private System.Windows.Forms.Label lbEmail;
    }
}