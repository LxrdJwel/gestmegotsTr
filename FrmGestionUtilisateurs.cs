using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestMegotWF.Formulaires
{
    public partial class FrmGestionUtilisateurs : Form
    {
        public FrmGestionUtilisateurs()
        {
            InitializeComponent();
        }

        private void FrmGestionUtilisateurs_Load(object sender, EventArgs e)
        {

        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string iDuser = txtNom.Text;
            string Password = txtPassword.Text;
            string role = txtRole.SelectedItem.ToString();

            if (!ValiderMotDePasse(Password)
            {
                MessageBox.Show("Mot de passe non conforme !");
                return;
            }

            string hash = Password.HashPassword(Password, out string salt);

            // Exemple : insertion SQL
            string query = "INSERT INTO Utilisateurs (NomUtilisateur, MotDePasseHash, Salt, Role) VALUES (@u, @h, @s, @r)";
            using (SqlConnection con = new SqlConnection("..."))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@h", hash);
                cmd.Parameters.AddWithValue("@s", salt);
                cmd.Parameters.AddWithValue("@r", role);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Utilisateur ajouté !");
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
}
