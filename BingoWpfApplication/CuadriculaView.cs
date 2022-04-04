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
    public class CuadriculaView
    {
        Rectangle _rectangulo;
        TextBlock _numero;
        Canvas _canvas;
        IBola _bola;

        public CuadriculaView (IBola bola, Canvas canvas)
        {
            _bola = bola;
            _canvas = canvas;
        }
        public void DibujarCuadriculaBolaCanvas( int top, int left, double zoom,  int grados, Color colorNumero, Color colorFondo)
        {
           

            _rectangulo = new Rectangle();           
            _rectangulo.Stroke = System.Windows.Media.Brushes.Black;
            _rectangulo.Fill = new SolidColorBrush(colorFondo);
            _rectangulo.Width = zoom*2;
            _rectangulo.Height = zoom*2;
            _rectangulo.StrokeThickness=zoom/7.5;
            _rectangulo.Stroke=System.Windows.Media.Brushes.Black;
            
            
            Canvas.SetTop(_rectangulo, top);
            Canvas.SetLeft(_rectangulo, left);
            _rectangulo.LayoutTransform = new RotateTransform(grados);

            _numero = new TextBlock();
            _numero.FontFamily = new FontFamily("Courrier");
            _numero.FontSize = zoom;
            _numero.FontStyle = System.Windows.FontStyles.Italic;
            _numero.FontWeight = System.Windows.FontWeights.Bold;
            _numero.Foreground = new SolidColorBrush(colorNumero);

            string texto = _bola.ToString();
            if (texto.Length == 1) texto = " " + texto ;
            _numero.Text = texto;
            
          
            Canvas.SetTop(_numero, top+zoom/2.1);
            Canvas.SetLeft(_numero, left+zoom/2.5);
           // numero.RenderTransform = new RotateTransform(grados);
            _numero.LayoutTransform = new RotateTransform(grados);

        }

        public void RemoveCanvas()
        {
            _canvas.Children.Remove(_rectangulo);
            _canvas.Children.Remove(_numero);
        }

        public void AddCanvas()
        {
            _canvas.Children.Add(_rectangulo);
            _canvas.Children.Add(_numero);
        }




    }

}
