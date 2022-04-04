using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows;
using BingoClassLibrary;

namespace BingoWpfApplication
{
    public class BomboView
    {
        IBombo _bombo;
        int _top;
        int _left;
        double _zoom;
        int _grados;
        Canvas _canvas;


        public IBombo Bombo
        {
            get { return _bombo; }
            set { _bombo = value; }
        }
        public BomboView(IBombo bombo, Canvas canvas)
        {
            _bombo = bombo;
            _canvas = canvas;
            
        }
        public void DibujarBomboCanvas( int top, int left, double zoom, int grados)
        {
         
            _top = top;
            _left = left;
            _zoom = zoom;
            _grados = grados;

            int i=0;
            foreach (Bola bola in _bombo.Bolas)
            {
                int fila = (bola.Numero / 10);
                int columna = (bola.Numero-1) % 10;
                if (bola.Numero % 10 == 0) fila--;
                BolaView numeroBombo = new BolaView(bola, _canvas);
                numeroBombo.DibujarBolaCanvas( top + (int)zoom*fila*2, left + (int)zoom * columna*2,zoom, grados,Colors.Brown,Colors.Black);
                i++;
                numeroBombo.AddCanvas();
            }
        }

        public void TacharBola( IBola bolaTachada)
        {
            int fila = (bolaTachada.Numero / 10);
            int columna = (bolaTachada.Numero - 1) % 10;
            if (bolaTachada.Numero % 10 == 0) fila--;
            BolaView numeroBombo = new BolaView(bolaTachada, _canvas);
            numeroBombo.DibujarBolaCanvas(_top + (int)_zoom * fila * 2, _left + (int)_zoom * columna * 2, _zoom,  _grados, Colors.Red,Colors.Yellow);
            numeroBombo.AddBlink();
            Bombo.SacarBola(bolaTachada);

        }

        internal void TrasladaBola(Canvas CanvasAnimacion, int top, int left, double zoom, int grados, IBola bolaGenerada, Window window, int pos)
        {
            BolaView numeroBola = new BolaView(bolaGenerada, CanvasAnimacion);
            numeroBola.DibujarBolaCanvas( top, left, zoom, 0, Colors.Blue, Colors.White);
            numeroBola.AddRotateAndTranslate(window.Width,left, zoom, pos);
        }
    }
}
