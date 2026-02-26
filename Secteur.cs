namespace GestMegotWF.Entitees
{
    public class Secteur
    {
        private int id;
        private string name;

        public Secteur(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public override string ToString()
        {
            return name;
        }
    }
}