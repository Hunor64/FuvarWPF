using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> fuvarokLista = new List<Fuvar>();
        List<string> fizetesiModok = new List<string>();
        List<int> fizetettMennyiseg = new List<int>();
        List<string> fizetettKiir = new List<string>();
        List<String> hibasFuvarok = new List<String>();
        int leghosszabbUtIndex = 0;
        int fuvarosEmber = 0;
        public MainWindow()
        {
            InitializeComponent();
            //3           
            readFile();
            lblElsoFeladat.Content = fuvarokLista.Count();

            //4
            txtNegyesFeladat.Text =

            //5


            //6
            lblHatosFeladat.Content = osszesKilometer();

            //7
            lblHetesFeladat.Content = fuvarokLista[leghosszabbUtIndex].IndulasIdotartam + "perc volt a leghosszabb út!";

            //8
            File.WriteAllLines("hibak.txt", hibasFuvarok);

        }
        //2
        public void readFile()
        {
            string filePath = "fuvar.csv";
            var readFile = File.ReadAllLines(filePath);
            for (int i = 1; i < readFile.Length; i++)
            {
                var felbontva = readFile[i].Split(';');
                fuvarokLista.Add(new Fuvar(int.Parse(felbontva[0]), felbontva[1], Convert.ToDouble(felbontva[2]), int.Parse(felbontva[3]), felbontva[4], felbontva[5]));

            }
        }

        //4
        /*
        idő hiánya miatt nem jó
        public void cmbFeltöltés()
        {

        }*/



        //5
        public void fizetesiModokatMegkeres()
        {
            for (int i = 0; i < fuvarokLista.Count; i++)
            {
                if (!fizetesiModok.Contains(fuvarokLista[i].FizetesModja))
                {
                    fizetesiModok.Add(fuvarokLista[i].FizetesModja);
                }
            }
        }
        public void fizetesekMegszamol()
        {
            for (int i = 0; i < fizetesiModok.Count; i++)
            {
                fizetettMennyiseg.Add(0);
            }
            for (int i = 0; i < fuvarokLista.Count; i++)
            {
                for (int o = 0; o < fizetesiModok.Count; o++)
                {
                    if (fizetesiModok[o] == fuvarokLista[i].FizetesModja)
                    {
                        fizetettMennyiseg[o] += 1;
                    }
                }
            }
        }

        public void fizetettKiirListaba()
        {
            for (int i = 0; i < fizetettMennyiseg.Count; i++)
            {
                fizetettKiir.Add(fizetesiModok[i] + fizetettMennyiseg[i]);
            }
        }

        //6
        public double osszesKilometer()
        {
            double osszesMegtettUtMI = 0;
            for (int i = 0; i < fuvarokLista.Count; i++)
            {
                osszesMegtettUtMI += fuvarokLista[i].Tavolsag;
            }

            return osszesMegtettUtMI * 1.6;
        }
        //7
        public void leghosszabbUt()
        {
            for (int i = 0; i < fuvarokLista.Count; i++)
            {
                if (int.Parse(fuvarokLista[i].IndulasIdotartam) > int.Parse(fuvarokLista[leghosszabbUtIndex].IndulasIdotartam))
                {
                    leghosszabbUtIndex = i;
                }
            }
        }

        //8
        public void hibaKereso()
        {
            hibasFuvarok.Add("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
            for (int i = 0; i < fuvarokLista.Count; i++)
            {
                if (int.Parse(fuvarokLista[i].IndulasIdotartam) > 0 && fuvarokLista[i].Viteldij > 0 && fuvarokLista[i].Tavolsag == 0)
                {
                    hibasFuvarok.Add(fuvarokLista[i].TaxiID + fuvarokLista[i].IndulasIdotartam + fuvarokLista[i].Tavolsag + fuvarokLista[i].Viteldij + fuvarokLista[i].Borravalo + fuvarokLista[i].FizetesModja);
                }
            }
        }
    }
}
