using GestMegots.Modeles;
using GestMegotsWF;
using GestMegotWF.Entitees;
using GestMegotWF.Modeles;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestMegotWF.Formulaires
{
    public partial class fmHS : Form
    {
        public fmHS()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = HotspotModele.TousLesHotspots();
            this.cb_categorie.DataSource = CategorieModele.ToutesLesCategories();
            this.cb_categorie.DisplayMember = "name";
            this.cb_categorie.ValueMember = "id";
            this.cb_secteur.DataSource = SecteurModele.TousLesSecteurs();
            this.cb_secteur.DisplayMember = "name";
            this.cb_secteur.ValueMember = "id";
            this.dataGridView2.DataSource = CollectesModele.TousLesCollectes();
            panelHot.Visible = false;
            panelColl.Visible = false;
            panelMat.Visible = false;
            this.dataGridView3.DataSource = MaterielModele.TousLesMateriels();

        }

        private void fmHS_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_GPS.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb_nom.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tb_adresse.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()) == 1)
            {
                cb_terrasse.Checked = true;
            }
            else
            {
                cb_terrasse.Checked = false;
            }
            //Cherche la chaine de caracteres dans la combobox correspondant à ce qui est sélectionné dans le datagridview
            int i = cb_secteur.FindStringExact(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            cb_secteur.SelectedIndex = i;

            i = cb_categorie.FindStringExact(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            cb_categorie.SelectedIndex = i;

            ///TODO : Faire la même chose pour le matériel
        }

        private void bt_Ajouter_Click(object sender, EventArgs e)
        {
            int terrasse;
            if (cb_terrasse.Checked == true)
            {
                terrasse = 1;
            }
            else
            {
                terrasse = 0;
            }

            object ob = cb_categorie.SelectedValue;
            Categorie uneCat = CategorieModele.CategorieById(int.Parse(ob.ToString()));

            ob = cb_secteur.SelectedValue;
            Secteur unSect = SecteurModele.SecteurById(int.Parse(ob.ToString()));
            Hotspot unHs = new Hotspot(tb_GPS.Text, tb_nom.Text, tb_adresse.Text, terrasse, unSect, uneCat);

            HotspotModele.AjoutHotspot(unHs);
            //Recharge le datgridview
            this.dataGridView1.DataSource = HotspotModele.TousLesHotspots();
        }

        private void bt_dell_Click(object sender, EventArgs e)
        {
            Hotspot unHs = new Hotspot(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

            HotspotModele.SupprimerHotspot(unHs);
            this.dataGridView1.DataSource = HotspotModele.TousLesHotspots();
        }

        private void bt_update_Click(object sender, EventArgs e)
        {
            int terrasse;
            if (cb_terrasse.Checked == true)
            {
                terrasse = 1;
            }
            else
            {
                terrasse = 0;
            }

            object ob = cb_categorie.SelectedValue;
            Categorie uneCat = CategorieModele.CategorieById(int.Parse(ob.ToString()));

            ob = cb_secteur.SelectedValue;
            Secteur unSect = SecteurModele.SecteurById(int.Parse(ob.ToString()));
            //Ajouter le matériel
            Hotspot unHs = new Hotspot(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), tb_GPS.Text, tb_nom.Text, tb_adresse.Text, terrasse, unSect, uneCat);

            HotspotModele.ModifierHotspot(unHs);
            //Recharge le datgridview
            this.dataGridView1.DataSource = HotspotModele.TousLesHotspots();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelColl.Visible = true;
            panelHot.Visible = true;
            panelMat.Visible = false;

            // Form2 fm = new form2()
            // this.Hide(); caché LE FORMULAIRE EN COURS 

            // PublicKey form2(string var1)//


        }

        private void bt_hotspot_Click(object sender, EventArgs e)
        {
            panelHot.Visible = true;
            panelColl.Visible = false;
            panelMat.Visible = false;
        }

        private void tb_AjouterColl_Click(object sender, EventArgs e)
        {
            Collectes unC = new Collectes(DateTime.Parse(tb_date.Text), Double.Parse(tb_quantité.Text));
            CollectesModele.AjoutCollectes(unC);

            this.dataGridView2.DataSource = CollectesModele.TousLesCollectes();
        }

        private void bt_SupprimerColl_Click(object sender, EventArgs e)
        {
            Collectes unC = new Collectes(int.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString()), DateTime.Parse(tb_date.Text), Double.Parse(tb_quantité.Text));

            CollectesModele.SupprimerCollectes(unC);
            this.dataGridView2.DataSource = CollectesModele.TousLesCollectes();
        }

        private void bt_ModifierColl_Click(object sender, EventArgs e)
        {
            Collectes unC = new Collectes(int.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString()), DateTime.Parse(tb_date.Text), Double.Parse(tb_quantité.Text));

            CollectesModele.ModifierCollectes(unC);

            this.dataGridView2.DataSource = CollectesModele.TousLesCollectes();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_date.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            tb_quantité.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();


            ///TODO : Faire la même chose pour le matériel
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tb_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cb_materiel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void bt_materiels_Click(object sender, EventArgs e)
        {
            panelMat.Visible = true;
            panelHot.Visible = true;
            panelColl.Visible = true;

        }

        private void AjouterM_Click(object sender, EventArgs e)
        {
            Materiel unM = new Materiel(int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString()), tb_couleursM.Text, DateTime.Parse(tb_dateInsM.Text), tb_adresseM.Text, tb_coordoGPSM.Text);
            MaterielModele.AjoutMateriel(unM);

            this.dataGridView3.DataSource = MaterielModele.TousLesMateriels();
        }

        private void ModifierM_Click(object sender, EventArgs e)
        {
            Materiel unM = new Materiel(int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString()), tb_couleursM.Text, DateTime.Parse(tb_dateInsM.Text), tb_adresseM.Text, tb_coordoGPSM.Text);

            MaterielModele.ModifierMateriel(unM);

            this.dataGridView3.DataSource = MaterielModele.TousLesMateriels();
        }

        private void SupprimerM_Click(object sender, EventArgs e)
        {
            Materiel unM = new Materiel(int.Parse(dataGridView3.CurrentRow.Cells[2].Value.ToString()), tb_couleursM.Text, DateTime.Parse(tb_dateInsM.Text), tb_adresseM.Text, tb_coordoGPSM.Text);

            MaterielModele.SupprimerMateriel(unM);
            this.dataGridView3.DataSource = MaterielModele.TousLesMateriels();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_couleursM.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            tb_dateInsM.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            tb_adresseM.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            tb_coordoGPSM.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
