using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestMegotWF.Entitees;
using GestMegotWF.Modeles;
using MySql.Data.MySqlClient;

namespace GestMegots.Modeles
{
    internal class MaterielModele
    {
        public static List<Materiel> TousLesMateriels()
        {
            List<Materiel> lesM = new List<Materiel>();
            Materiel unM;

            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "SELECT * FROM materiel";
            MySqlDataReader lecteur;
            lecteur = cmd.ExecuteReader();
            MySqlDataReader lecteurFK;
            MySqlConnection connexFK;
            MySqlConnection connexFK3 = Connexion.Ouvrir();
            MySqlCommand cmdFK;

            while (lecteur.Read())
            {
                connexFK = Connexion.Ouvrir();
                cmdFK = connexFK.CreateCommand();
                cmdFK.CommandText = "SELECT * FROM materiel where reference =" + int.Parse(lecteur[0].ToString());
                lecteurFK = cmdFK.ExecuteReader();
                lecteurFK.Read();
                unM = new Materiel(int.Parse(lecteurFK[0].ToString()), (lecteur[1].ToString()), DateTime.Parse(lecteur[2].ToString()), (lecteur[3].ToString()), (lecteur[4].ToString()));
                lesM.Add(unM);
                connexFK.Close();

            }
            connexHS.Close();
            return lesM;
        }
            
        public static Materiel MaterielById(int idM)
        {
            Materiel unM = new Materiel(3,"bleu", DateTime.Parse("12/25/21"), "22 rue du oui","61.002");
            return unM;
        }
        public static void AjoutMateriel(Materiel unM)
        {
            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();

            cmd.CommandText = "INSERT INTO `Materiel`(Reference,couleurs,dateInstallation,adresse,coordoGPS,fkType) VALUES (@reference,@couleurs,@DateInstallation,@Adresse,@CoordoGPS,@fkType)";
            cmd.Parameters.Add("@reference", MySqlDbType.Double).Value = unM.ReferenceM;
            cmd.Parameters.Add("@couleurs", MySqlDbType.VarChar).Value = unM.CouleursM;
            cmd.Parameters.Add("@DateInstallation", MySqlDbType.Datetime).Value = unM.DateInstalM;
            cmd.Parameters.Add("@Adresse", MySqlDbType.Double).Value = unM.AdresseM;
            cmd.Parameters.Add("@CoordoGPS", MySqlDbType.Double).Value = unM.CoordoGPSM;
            cmd.Parameters.Add("@TypeMateriel", MySqlDbType.Int32).Value = unM.LeTypeM;
            int nb = cmd.ExecuteNonQuery();


        }
        public static void ModifierMateriel(Materiel unM)
        {

            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "UPDATE `Materiel` SET `reference` = @reference,`couleurs` = @couleurs, `dateInstallation`=@DateInstallation,`adresse`=@Adresse ,`coordoGPS`=@CoordoGPS, `LeMateriel`=@Materiel  WHERE `collectes`.`Reference` = @reference  ";
            cmd.Parameters.Add("@reference", MySqlDbType.Double).Value = unM.ReferenceM;
            cmd.Parameters.Add("@couleurs", MySqlDbType.VarChar).Value = unM.CouleursM;
            cmd.Parameters.Add("@DateInstallation", MySqlDbType.Datetime).Value = unM.DateInstalM;
            cmd.Parameters.Add("@Adresse", MySqlDbType.Double).Value = unM.AdresseM;
            cmd.Parameters.Add("@CoordoGPS", MySqlDbType.Double).Value = unM.CoordoGPSM;
            cmd.Parameters.Add("Type@Materiel", MySqlDbType.Int32).Value = unM.LeTypeM;
            int nb = cmd.ExecuteNonQuery();
            connexHS.Close();

        }
        public static void SupprimerMateriel(Materiel unM)
        {
            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "DELETE FROM `Materiel`  WHERE `Collectes`.`reference` = @reference  ";
            cmd.Parameters.Add("@reference", MySqlDbType.Int64).Value = unM.ReferenceM;
            int nb = cmd.ExecuteNonQuery();
            connexHS.Close();

        }
    }
}
