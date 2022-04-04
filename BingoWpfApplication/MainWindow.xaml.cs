using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BingoClassLibrary;

namespace BingoWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CartonView> ListaCartones = new List<CartonView>();
        BomboView bomboView;

        int numBolas = 0;
        
        public MainWindow()
        {
            InitializeComponent();

            CanvasBombo.Background = Brushes.Bisque;
            Bombo bombo = new Bombo();
            bombo.Rellenar();
            int anchuraBola = 20;
            bomboView = new BomboView(bombo,CanvasBombo);
            bomboView.DibujarBomboCanvas(10, 10, anchuraBola, 0);
           

        }




        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListaCartones.Count == 0)
            {
                MessageBox.Show(String.Format("Añada algún cartón para jugar"));
                return;
            }

            numBolas++;
            IBola bolaGenerada = bomboView.Bombo.ElegirBola();
            
            bomboView.TacharBola(bolaGenerada);

            int top = (int)(89-bomboView.Bombo.NumeroBolas) / 30;

            bomboView.TrasladaBola(CanvasAnimacion, 10 + 20 * top * 2, 0, 20, 0, bolaGenerada, this, numBolas);
            if (numBolas % 30 == 0) numBolas = 0;            
            
            int posCarton = 1;
            foreach (var cartonView in ListaCartones)
            {
                cartonView.TacharBola(bolaGenerada);
                if (cartonView.Carton.NumeroBolasSinTachar == 0)
                {
                    MessageBox.Show(String.Format("Cartón numero {0} ha ganado", posCarton));
                }
                posCarton++;
            }


            if (bomboView.Bombo.NumeroBolas==0) SacaBolaButton.IsEnabled = false;
            NuevoCarton.IsEnabled = false;

        }



        private void NewCartonButton_Click(object sender, RoutedEventArgs e)
        {            
            var cartonView = new CartonView(new Carton(15),CanvasCarton);
            ListaCartones.Add(cartonView);
            int anchura = 20;
            int margenIzquierda = 10;
            ListaCartones[ListaCartones.Count - 1].DibujarCartonCanvas(10+anchura*2*(ListaCartones.Count-1), margenIzquierda, anchura, 0);
        }
    }
}
