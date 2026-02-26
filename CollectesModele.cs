using GestMegotWF.Entitees;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestMegotWF.Modeles
{
    public class CollectesModele
    {
        public static List<Collectes> TousLesCollectes()
        {
            List<Collectes> lesC = new List<Collectes>();
          Collectes unC;
        
            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "SELECT * FROM Collectes";
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
                cmdFK.CommandText = "SELECT * FROM Collectes where idC =" + int.Parse(lecteur[2].ToString());
                lecteurFK = cmdFK.ExecuteReader();
                lecteurFK.Read();
                unC = new Collectes(int.Parse(lecteurFK[2].ToString()), DateTime.Parse(lecteur[0].ToString()), Double.Parse(lecteur[1].ToString()));
                lesC.Add(unC);
                connexFK.Close();
                
            }
            connexHS.Close();
            return lesC;
        }
        public static Collectes CollecteById(int idC)
        {
         Collectes unC = new Collectes(3, DateTime.Parse("12/25/21"), 2.5);
            return unC;
        }
        public static void AjoutCollectes(Collectes unC)
        {
            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            //INSERT INTO `hotspot` (`idHS`, `coordoGPS`, `nom`, `adresse`, `terrasse`, `fkSecteur`, `fkCategorie`, `fkMateriel`) VALUES (NULL, '123456;123456', 'Couleur Café', 'rue de la gare', '1', '2', '1', NULL);
            cmd.CommandText = "INSERT INTO `Collectes`(QuantitéC,DateC,LeMateriel) VALUES (@Quantité,@Date,@Materiel)";
            cmd.Parameters.Add("@Quantité", MySqlDbType.Double).Value = unC.QuantiteC1;
            cmd.Parameters.Add("@Date", MySqlDbType.Datetime).Value = unC.DateC1;
            cmd.Parameters.Add("@Materiel", MySqlDbType.Int32).Value = unC.LeMateriel.ReferenceM ;
            int nb = cmd.ExecuteNonQuery();


        }
        public static void ModifierCollectes(Collectes unC)
        {

            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "UPDATE `collectes` SET `DateC` = @Date, `QuantitéC`=@Quantité,`IdC`=@idc , `LeMateriel`=@Materiel  WHERE `collectes`.`IdC` = @idc  ";
            cmd.Parameters.Add("@Date", MySqlDbType.Datetime).Value = unC.DateC1;
            cmd.Parameters.Add("@Quantité", MySqlDbType.Double).Value = unC.QuantiteC1;
            cmd.Parameters.Add("@idc", MySqlDbType.Int64).Value = unC.IdC1;
            cmd.Parameters.Add("@Materiel", MySqlDbType.Int32).Value = unC.LeMateriel.ReferenceM;
            int nb = cmd.ExecuteNonQuery();
            connexHS.Close();

        }
        public static void SupprimerCollectes(Collectes unC)
        {
            MySqlConnection connexHS = Connexion.Ouvrir();
            MySqlCommand cmd;
            cmd = connexHS.CreateCommand();
            cmd.CommandText = "DELETE FROM `Collectes`  WHERE `Collectes`.`idC` = @idC  ";
            cmd.Parameters.Add("@idc", MySqlDbType.Int64).Value = unC.IdC1;
            int nb = cmd.ExecuteNonQuery();
            connexHS.Close();



        }
    }
}
