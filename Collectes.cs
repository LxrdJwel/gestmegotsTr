using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestMegotWF.Entitees
{
    public class Collectes
    {
        private DateTime DateC;
        private double QuantiteC;
        private int IdC;
        private Materiel leMateriel;

        public DateTime DateC1 { get => DateC; set => DateC = value; }
        public double QuantiteC1 { get => QuantiteC; set => QuantiteC = value; }
        public int IdC1 { get => IdC; set => IdC = value; }
        public Materiel LeMateriel { get => leMateriel; set => leMateriel = value; }

        public Collectes(int IdCollectes)
        {
            IdC = IdCollectes;
        }

        public Collectes(DateTime DateCollectes)
        {
            DateC = DateCollectes;
        }
        public Collectes(DateTime DateCollectes, double QuantitéCollectes)
        {
            DateC = DateCollectes;
            QuantiteC = QuantitéCollectes;
        }
        public Collectes(int IdCollectes,DateTime DateCollectes,double QuantitéCollectes) 
        {
            IdC = IdCollectes;
            DateC = DateCollectes;
            QuantiteC = QuantitéCollectes;
        }
        public Collectes(int IdCollectes, DateTime DateCollectes, double QuantitéCollectes, Materiel leMateriel)
        {
            IdC = IdCollectes;
            DateC = DateCollectes;
            QuantiteC = QuantitéCollectes;
            this.LeMateriel = leMateriel;

        }
    } 
}
