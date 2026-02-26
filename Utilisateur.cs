using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GestMegotWF.Entitees
{
    public class Utilisateur
    {
        private int idUser;
        private string password;
        private string salt;
        private string role;
        public int IdUser { get => idUser; set => idUser = value; }
        public string Password { get => password; set => password = value; }
        public string Salt { get => salt; set => salt = value; }
        public string Role { get => role; set => role = value; }

        public Utilisateur(int IdUser)
        {
            idUser = IdUser ;
        }


    }
        /// <summary>
        /// CREATE TABLE Utilisateurs (
    ///IduSER INT PRIMARY KEY IDENTITY,
   /// NomUtilisateur NVARCHAR(50) NOT NULL UNIQUE,
   /// pASSWORD NVARCHAR(200) NOT NULL,
    //Salt NVARCHAR(100) NOT NULL,
  //  Role NVARCHAR(20) NOT NULL -- SuperAdmin, Admin, Agent
//);
        /// </summary>

}
