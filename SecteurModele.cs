using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestMegotWF.Entitees;
using GestMegotWF.Modeles;

namespace GestMegotsWF
{
    internal class SecteurModele
    {
        public static List<Secteur> TousLesSecteurs()
        {

            List<Secteur> lesSect = new List<Secteur>();

            MySqlConnection connex = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connex.CreateCommand();
            cmd.CommandText = "SELECT * FROM SECTEUR order by libelle ASC";
            MySqlDataReader lecteur;
            lecteur = cmd.ExecuteReader();
            Secteur unSec;
            while (lecteur.Read())
            {
                 unSec = new Secteur(int.Parse(lecteur[0].ToString()), lecteur[1].ToString());

                lesSect.Add(unSec);

            }
            connex.Close();
            return lesSect;

        }
        public static Secteur SecteurById(int id)
        {
            MySqlConnection connex = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connex.CreateCommand();
            cmd.CommandText = "SELECT * FROM SECTEUR where idSecteur =" + id;
            MySqlDataReader lecteur;
            lecteur = cmd.ExecuteReader();
            Secteur unSec;
            lecteur.Read();

            unSec = new Secteur(int.Parse(lecteur[0].ToString()), lecteur[1].ToString());
            connex.Close();
            return unSec;

        }

        public static void AjoutSecteur(Secteur unSect)
        {
            //insérer HotSpot dans BD

        }
        public static void ModifierHotspot(Hotspot unHS)
        {
            //modifier HotSpot dans BD

        }
        public static void SupprimerHotspot(Hotspot unHS)
        {
            //supprimer HotSpot dans BD

        }
    }
}
