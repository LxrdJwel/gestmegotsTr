using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestMegotWF.Entitees; 

namespace GestMegotWF.Modeles
{
    internal class CategorieModele
    {
        public static List<Categorie> ToutesLesCategories()
        {

            

            List<Categorie> lesCat = new List<Categorie>();
            MySqlConnection connex = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connex.CreateCommand();
            cmd.CommandText = "SELECT * FROM CATEGORIE order by libelle ASC";
            MySqlDataReader lecteur;
            lecteur = cmd.ExecuteReader();
            Categorie uneCat;

            while (lecteur.Read())
            {
                uneCat = new Categorie(int.Parse(lecteur[0].ToString()), lecteur[1].ToString(), lecteur[2].ToString());

                lesCat.Add(uneCat);

            }
            connex.Close();
            return lesCat;

        }
        public static Categorie CategorieById(int id)
        {
            MySqlConnection connex = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connex.CreateCommand();
            cmd.CommandText = "SELECT * FROM Categorie where idCategorie =" + id;
            MySqlDataReader lecteur;
            lecteur = cmd.ExecuteReader();
            Categorie uneCat;
            lecteur.Read();
            uneCat = new Categorie(int.Parse(lecteur[0].ToString()), lecteur[1].ToString(), lecteur[2].ToString());
            connex.Close();
            return uneCat;

        }

    }
}
