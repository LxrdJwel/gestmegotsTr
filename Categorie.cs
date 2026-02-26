
namespace GestMegotWF.Entitees
{
    public class Categorie
    {
        private int id;
        private string name;
        private string remarque;

        public Categorie(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Categorie(int id, string name, string remarque)
        {
            this.id = id;
            this.name = name;
            this.Remarque = remarque;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Remarque { get => remarque; set => remarque = value; }

        public override string ToString()
        {
            return name;
        }

    }
}