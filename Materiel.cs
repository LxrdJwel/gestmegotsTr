namespace GestMegotWF.Entitees
{
    public class Materiel
    {
        private int reference;
        private string couleurs;
        private DateTime dateInstal;
        private string adresse;
        private string coordoGPS;
        private TypeMateriel leType;

        public int ReferenceM { get => reference; set => reference = value; }
        public string CouleursM { get => couleurs; set => couleurs = value; }
        public DateTime DateInstalM { get => dateInstal; set => dateInstal = value; }
        public string AdresseM { get => adresse; set => adresse = value; }
        public string CoordoGPSM { get => coordoGPS; set => coordoGPS = value; }
        public TypeMateriel LeTypeM { get => leType; set => leType = value; }

        public Materiel(int reference, string couleurs, DateTime dateInstal, string adresse, string coordoGPS, TypeMateriel leType)
        {
            this.ReferenceM = reference;
            this.CouleursM = couleurs;
            this.DateInstalM = dateInstal;
            this.AdresseM = adresse;
            this.CoordoGPSM = coordoGPS;
            this.LeTypeM = leType;
        }

        public Materiel(int reference, string couleurs, DateTime dateInstal, string adresse, string coordoGPS)
        {
            this.ReferenceM = reference;
            this.CouleursM = couleurs;
            this.DateInstalM = dateInstal;
            this.AdresseM = adresse;
            this.CoordoGPSM = coordoGPS;
            this.LeTypeM = leType;
        }
    }
}