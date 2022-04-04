using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using BingoClassLibrary;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows;

namespace BingoWpfApplication
{

    public  class AnimacionBomboView
    {



        public  DoubleAnimation DibujarBolaAnimada(Canvas canvasAnimacion, int top, int left, double zoom, int grados, Bola bolaTachada)
        {
            int fila = 1;
            int columna = 1;
            BolaView bolaAnimada = new BolaView(bolaTachada, canvasAnimacion);
            bolaAnimada.DibujarBolaCanvas(top + (int)zoom * fila * 2, left + (int)zoom * columna * 2, zoom, grados, Colors.Red,Colors.Red);
            Storyboard storyboard = new Storyboard();

            var myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(3));
            myDoubleAnimation.AutoReverse = false;

           // Storyboard.SetTargetName(myDoubleAnimation, bolaView.Numero.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(TextBlock.OpacityProperty));
            storyboard.Children.Add(myDoubleAnimation);
           

            return myDoubleAnimation;
        }

        public  void AnimacionRotarBola(Canvas canvasAnimacion, int top, int left, double zoom, int grados, Bola bolaTachada)
        {
            int fila = 1;
            int columna = 1;
            BolaView bolaAnimada = new BolaView(bolaTachada, canvasAnimacion);
            bolaAnimada.DibujarBolaCanvas(top + (int)zoom * fila * 2, left + (int)zoom * columna * 2, zoom, grados, Colors.Red,Colors.Red);
            bolaAnimada.AddCanvas(); 
             
           DoubleAnimation oLabelAngleAnimation = new DoubleAnimation();

           oLabelAngleAnimation.From = 0;
           oLabelAngleAnimation.To = 360;
           oLabelAngleAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
           oLabelAngleAnimation.RepeatBehavior = new RepeatBehavior(4);
          

          RotateTransform oTransform  = (RotateTransform)bolaAnimada.Numero.LayoutTransform;
          oTransform.CenterX = 0.5;
          oTransform.CenterY = 0.5;            
          oTransform.BeginAnimation(RotateTransform.AngleProperty, oLabelAngleAnimation);         
       }

    public void AnimacionTraslacionBolas(Canvas canvasAnimacion, int top, int left, double zoom, int grados, Bola bolaTachada,Window window, Storyboard storyboard)
    {
        for (int i = 0; i < 12; ++i)
        {

            int fila = 0;
            int columna = 0;
                BolaView bolaAnimada = new BolaView(bolaTachada, canvasAnimacion);
                bolaAnimada.DibujarBolaCanvas(top + (int)zoom * fila * 2, left + (int)zoom * columna * 2, zoom, grados, Colors.Red,Colors.Red);
                bolaAnimada.AddCanvas();
            var tg = new TransformGroup();
            var translation = new TranslateTransform(100, 300);
            var translationName = "myTranslation" + translation.GetHashCode();
            window.RegisterName(translationName, translation);
            tg.Children.Add(translation);
            tg.Children.Add(new RotateTransform(30 * i));

            //_numero.RegisterName(_numero.Name, window); parpadea la ventana
            var myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0.8;
            myDoubleAnimation.To = 0.2;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = new RepeatBehavior(10);
            Storyboard.SetTargetName(myDoubleAnimation, bolaAnimada.Numero.Name);


            Storyboard.SetTargetName(storyboard, translationName);
            Storyboard.SetTargetProperty(storyboard, new PropertyPath(TranslateTransform.XProperty));



            storyboard.Children.Add(myDoubleAnimation);

            storyboard.Completed +=
                (sndr, evtArgs) =>
                {
                    bolaAnimada.RemoveCanvas();
                    window.Resources.Remove(storyboard.Name);
                    window.UnregisterName(translationName);
                };
            storyboard.Begin();
        }
    }


    }




}
