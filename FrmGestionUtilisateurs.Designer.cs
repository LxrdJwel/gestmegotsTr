namespace GestMegotWF.Formulaires
{
    partial class FrmGestionUtilisateurs
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
            txtNom = new TextBox();
            txtPassword = new TextBox();
            txtRole = new TextBox();
            SuspendLayout();
            // 
            // txtNom
            // 
            txtNom.Location = new Point(475, 244);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(426, 23);
            txtNom.TabIndex = 3;
            txtNom.Text = "fd";
            txtNom.TextChanged += txtNom_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(475, 326);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(426, 23);
            txtPassword.TabIndex = 4;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(801, 432);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(100, 23);
            txtRole.TabIndex = 5;
            // 
            // FrmGestionUtilisateurs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1547, 629);
            Controls.Add(txtRole);
            Controls.Add(txtPassword);
            Controls.Add(txtNom);
            Name = "FrmGestionUtilisateurs";
            Text = "FrmGestionUtilisateurs";
            Load += FrmGestionUtilisateurs_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNom;
        private TextBox txtPassword;
        private TextBox txtRole;
    }
}