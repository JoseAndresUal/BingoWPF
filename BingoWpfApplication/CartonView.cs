using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using BingoClassLibrary;

namespace BingoWpfApplication
{
    public class CartonView
    {
        Carton _carton;
        int _top;
        int _left;
        double _zoom;
        int _grados;
        Canvas _canvas;


        public Carton Carton
        {
            get { return _carton; }
            set { _carton = value; }
        }
        public CartonView(Carton carton,Canvas canvas)
        {
            _carton = carton;
            _canvas = canvas;
            
        }
        public void DibujarCartonCanvas( int top, int left, double zoom, int grados)
        {
            
            _top = top;
            _left = left;
            _zoom = zoom;
            _grados = grados;
            int i=0;
            foreach (Bola bola in _carton.Original)
            {
                CuadriculaView numeroCarton = new CuadriculaView(bola, _canvas);
                numeroCarton.DibujarCuadriculaBolaCanvas(top, left + (int)zoom * i*2,zoom,grados,Colors.Black,Colors.Brown);
                    i++;
                    numeroCarton.AddCanvas();
            }
        }

        public void TacharBola(IBola bolaTachada)
        {
            int i = 0;
            _carton.TacharBola(bolaTachada);
            foreach (Bola bola in _carton.Original)
            {
                if (bola.Equals(bolaTachada)) 
                //if (bola == bolaTachada)
                {
                    CuadriculaView numeroCarton = new CuadriculaView(bola, _canvas);
                    numeroCarton.DibujarCuadriculaBolaCanvas( _top, _left + (int)_zoom * i * 2, _zoom, _grados,Colors.Red,Colors.Yellow);               
                    numeroCarton.AddCanvas();
                }
                i++;
            }
        }
    }
}
