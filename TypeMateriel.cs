namespace GestMegotWF.Entitees
{
    public class TypeMateriel
    {
       private int idType;
       private string libelle;
       private string contenance;
       private int sacIntegre;

        public int IdType
        { get { return idType; } set { idType = value; } }
        public string Libelle
            { get { return libelle; } set { libelle = value; } }
        public string Contenance
            { get { return contenance; } set { contenance = value; } }
        public int SacIntegre
            { get { return sacIntegre; } set { sacIntegre = value; } }

        public TypeMateriel()
        {
        }

        public TypeMateriel(int idType)
        {
            this.idType = idType;
        }

        public TypeMateriel(int idType, string libelle) : this(idType)
        {
            this.libelle = libelle;
        }

        public TypeMateriel(int idType, string libelle, string contenance) : this(idType, libelle)
        {
            this.contenance = contenance;
        }

        public TypeMateriel(int idType, string libelle, string contenance, int sacIntegre) : this(idType, libelle, contenance)
        {
            this.sacIntegre = sacIntegre;
        }
    } 
}