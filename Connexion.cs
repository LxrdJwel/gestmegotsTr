using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using GestMegotWF.Entitees;


namespace GestMegotWF.Modeles
{
    public static class Connexion
    {
        public static MySqlConnection Ouvrir() { 
            MySqlConnection laConnex;
            string infosConnex = "server=localhost;port=3306;database=gestmegot_gr1;uid=root";
            laConnex = new MySqlConnection(infosConnex);
            laConnex.Open();
            return laConnex;
        }

    }
}
