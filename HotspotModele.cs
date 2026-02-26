using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using GestMegotWF.Entitees; 

namespace GestMegotWF.Modeles
{
   public static class HotspotModele
    {
        public static List<Hotspot> TousLesHotspots()
        {
            List<Hotspot> lesHP = new List<Hotspot>();
            Secteur unSec;
            Categorie uneCat;
            Hotspot unHS;

            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "SELECT * FROM HOTSPOT";
            MySqlDataReader lecteur;
            lecteur = cmd.ExecuteReader();
            MySqlDataReader lecteurFK;
            MySqlConnection connexFK ;
            MySqlDataReader lecteurFK2;
            MySqlConnection connexFK2;
            MySqlDataReader lecteurFK3;
            MySqlConnection connexFK3 = Connexion.Ouvrir();
            MySqlCommand cmdFK;
            MySqlCommand cmdFK2;
            MySqlCommand cmdFK3;



            while (lecteur.Read())
            {
                connexFK = Connexion.Ouvrir();
                cmdFK = connexFK.CreateCommand();
                cmdFK.CommandText = "SELECT * FROM Secteur where idSecteur =" + int.Parse(lecteur[5].ToString());
                lecteurFK = cmdFK.ExecuteReader();
                lecteurFK.Read();
                unSec = new Secteur(int.Parse(lecteurFK[0].ToString()), lecteurFK[1].ToString());
                connexFK2 = Connexion.Ouvrir();
                cmdFK2 = connexFK2.CreateCommand();

                cmdFK2.CommandText = "SELECT * FROM Categorie where idCategorie =" + int.Parse(lecteur[6].ToString());
                lecteurFK2 = cmdFK2.ExecuteReader();
                lecteurFK2.Read();
                uneCat = new Categorie(int.Parse(lecteurFK2[0].ToString()), lecteurFK2[1].ToString());
                
                unHS = new Hotspot(int.Parse(lecteur[0].ToString()), lecteur[1].ToString(), lecteur[2].ToString(), lecteur[3].ToString(), int.Parse(lecteur[4].ToString()),unSec,uneCat);
                lesHP.Add(unHS);
                connexFK.Close();
                connexFK2.Close();
            }
            connexHS.Close();
            return lesHP;

        }
        public static Hotspot HotsoptById(int id)
        {
            Secteur unSec = new Secteur(1, "Gare");
            Categorie uneCat = new Categorie(2, "Cinéma");

            Hotspot unHP = new Hotspot(3,"123456;45678","cinéma", "12 rue du cinema",0,unSec,uneCat);
           


            return unHP;

        }

        public static void AjoutHotspot(Hotspot unHS)
        {
            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "INSERT INTO `HOTSPOT`( `coordoGPS`, `nom`, `adresse`, `terrasse`, `fkSecteur`, `fkCategorie`,`fkMateriel`,) VALUES (@CoordoGPS ,@Nom ,@Adresse ,@Terrasse ,@LeSecteur,@LaCategorie,@LeMateriel)";
            cmd.Parameters.Add("@Coordo", MySqlDbType.VarChar).Value = unHS.CoordoGPS;
            cmd.Parameters.Add("@Nom", MySqlDbType.VarChar).Value = unHS.Nom;
            cmd.Parameters.Add("@Adresse", MySqlDbType.VarChar).Value = unHS.Adresse;
            cmd.Parameters.Add("@Terrasse", MySqlDbType.Int16).Value = unHS.Terrasse;
            cmd.Parameters.Add("@Secteur", MySqlDbType.Int32).Value = unHS.LeSecteur.Id;
            cmd.Parameters.Add("@Categorie", MySqlDbType.Int32).Value = unHS.LaCategorie.Id;
            cmd.Parameters.Add("@Materiel", MySqlDbType.Int32).Value = unHS.LeMateriel.ReferenceM;
            int nb = cmd.ExecuteNonQuery();


        }
        public static void ModifierHotspot(Hotspot unHS)
        {

            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "UPDATE `hotspot` SET `coordoGPS` = @coordo, `nom`=@nom, `adresse`=@adresse, `terrasse`=@terrasse, `fkSecteur`=@secteur, `fkCategorie`=@categorie ,`fkMateriel`=@materiel WHERE `hotspot`.`idHS` = @idHS  ";
            cmd.Parameters.Add("@coordo", MySqlDbType.VarChar).Value = unHS.CoordoGPS;
            cmd.Parameters.Add("@nom", MySqlDbType.VarChar).Value = unHS.Nom;
            cmd.Parameters.Add("@adresse", MySqlDbType.VarChar).Value = unHS.Adresse;
            cmd.Parameters.Add("@terrasse", MySqlDbType.Int16).Value = unHS.Terrasse;
            cmd.Parameters.Add("@secteur", MySqlDbType.Int32).Value = unHS.LeSecteur.Id;
            cmd.Parameters.Add("@categorie", MySqlDbType.Int32).Value = unHS.LaCategorie.Id;
            cmd.Parameters.Add("@materiel", MySqlDbType.Int32).Value = unHS.LeMateriel.ReferenceM;
            cmd.Parameters.Add("@idHS", MySqlDbType.Int32).Value = unHS.IdHS;

            int nb = cmd.ExecuteNonQuery();
            connexHS.Close();

        }
        public static void SupprimerHotspot(Hotspot unHS)
        {
            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "DELETE FROM `hotspot`  WHERE `hotspot`.`idHS` = @idHS  ";
            cmd.Parameters.Add("@idHS", MySqlDbType.Int32).Value = unHS.IdHS;

            int nb = cmd.ExecuteNonQuery();
            connexHS.Close();



        }

    }
}
