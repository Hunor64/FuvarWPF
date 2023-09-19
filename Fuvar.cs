using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat
{
    class Fuvar
    {
        int taxiID;
        string indulasIdotartam;
        double tavolsag;
        int viteldij;
        string borravalo;
        string fizetesModja;

        public Fuvar(int taxiID,string indulasIdotartam,double tavolsag,int viteldij,string borravalo,string fizetesModja)
        {
            this.taxiID = taxiID;
            this.indulasIdotartam = indulasIdotartam;
            this.tavolsag = tavolsag;
            this.viteldij = viteldij;
            this.borravalo = borravalo;
            this.fizetesModja = fizetesModja;
        }

        public int TaxiID { get => taxiID;}
        public string IndulasIdotartam { get => indulasIdotartam;}
        public double Tavolsag { get => tavolsag;}
        public int Viteldij { get => viteldij;}
        public string Borravalo { get => borravalo;}
        public string FizetesModja { get => fizetesModja;}
    }
}
