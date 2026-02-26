using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestMegotWF.Entitees
{
    public class Hotspot
    {
        private int idHS;
        private string coordoGPS;
        private string nom;
        private string adresse;
        private int terrasse;
        private Secteur leSecteur;
        private Categorie laCategorie;
        private Materiel leMateriel;

        public Hotspot(int idHS)
        {
            this.idHS = idHS;
        }

        public Hotspot(int idHS, string coordoGPS, string nom, string adresse, int terrasse)
        {
            this.idHS = idHS;
            this.coordoGPS = coordoGPS;
            this.nom = nom;
            this.adresse = adresse;
            this.terrasse = terrasse;
        }

        public Hotspot(string coordoGPS, string nom, string adresse, int terrasse, Secteur leSecteur, Categorie laCategorie)
        {
            this.coordoGPS = coordoGPS;
            this.nom = nom;
            this.adresse = adresse;
            this.terrasse = terrasse;
            this.leSecteur = leSecteur;
            this.laCategorie = laCategorie;
        }

        public Hotspot(int idHS, string coordoGPS, string nom, string adresse, int terrasse, Secteur leSecteur, Categorie laCategorie)
        {
            this.idHS = idHS;
            this.coordoGPS = coordoGPS;
            this.nom = nom;
            this.adresse = adresse;
            this.terrasse = terrasse;
            this.leSecteur = leSecteur;
            this.laCategorie = laCategorie;
        }

        public Hotspot(string coordoGPS, string nom, string adresse, int terrasse, Secteur leSecteur, Categorie laCategorie, Materiel leMateriel)
        {
            this.coordoGPS = coordoGPS;
            this.nom = nom;
            this.adresse = adresse;
            this.terrasse = terrasse;
            this.leSecteur = leSecteur;
            this.laCategorie = laCategorie;
            this.leMateriel = leMateriel;
        }

        public Hotspot(int idHS, string coordoGPS, string nom, string adresse, int terrasse, Secteur leSecteur, Categorie laCategorie, Materiel leMateriel)
        {
            this.IdHS = idHS;
            this.CoordoGPS = coordoGPS;
            this.Nom = nom;
            this.Adresse = adresse;
            this.Terrasse = terrasse;
            this.LeSecteur = leSecteur;
            this.LaCategorie = laCategorie;
            this.LeMateriel = leMateriel;
        }
        public int IdHS { get => idHS; set => idHS = value; }
        public string CoordoGPS { get => coordoGPS; set => coordoGPS = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public int Terrasse { get => terrasse; set => terrasse = value; }
        public Secteur LeSecteur { get => leSecteur; set => leSecteur = value; }
        public Categorie LaCategorie { get => laCategorie; set => laCategorie = value; }
        public Materiel LeMateriel { get => leMateriel; set => leMateriel = value; }

        
    }
}
