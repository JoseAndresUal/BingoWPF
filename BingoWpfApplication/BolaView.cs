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
    public class BolaView
    {
        Ellipse _elipse;

        public Ellipse Elipse
        {
            get { return _elipse; }
            set { _elipse = value; }
        }

        TextBlock _numero;

        public TextBlock Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        Canvas _canvas;

        IBola _bola;
      public BolaView(IBola bola, Canvas canvas)
        {
            _bola = bola;
            _canvas = canvas;
        }

        public void DibujarBolaCanvas( int top, int left, double zoom,  int grados, Color colorBola, Color colorFondo)
        {
            
             _elipse = new Ellipse();
            _elipse.Stroke = System.Windows.Media.Brushes.Black;
            _elipse.Fill = new SolidColorBrush(colorFondo);
            _elipse.Width = zoom*2;
            _elipse.Height = zoom*2;
            _elipse.StrokeThickness=zoom/7.5;
            _elipse.Stroke=System.Windows.Media.Brushes.Black;
            
            
            Canvas.SetTop(_elipse, top);
            Canvas.SetLeft(_elipse, left);
  
            
            _elipse.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            _elipse.LayoutTransform = new RotateTransform(grados);

            _numero = new TextBlock();
            _numero.Name = "numero_" + _bola.ToString();
            _numero.FontFamily = new FontFamily("Courrier");
            _numero.FontSize = zoom;
            _numero.FontStyle = System.Windows.FontStyles.Italic;
            _numero.FontWeight = System.Windows.FontWeights.Bold;
            _numero.Foreground = new SolidColorBrush(colorBola);
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
            _canvas.Children.Remove(_elipse);
            _canvas.Children.Remove(_numero);
        }


        public void AddCanvas()
        {
            _canvas.Children.Add(_elipse);
            _canvas.Children.Add(_numero);  
        }


     
        public void AddBlink()
        {
            AddCanvas();
            string _name = "n_" + this._numero.Name.ToString() ;
            Storyboard _storyboard = new Storyboard();

            var myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 0.8;
            myDoubleAnimation.To = 0.2;
            myDoubleAnimation.Duration = new System.Windows.Duration(TimeSpan.FromMilliseconds(200));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = new RepeatBehavior(10);


            Storyboard.SetTarget(myDoubleAnimation, _elipse);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(TextBlock.OpacityProperty));
            _storyboard.Children.Add(myDoubleAnimation);

            _storyboard.Completed +=
                        (sndr, evtArgs) =>
                        {

                        };

            _storyboard.Begin();
        }

        
        public void AddOnlyRotate()
        {
           AddCanvas();              
           DoubleAnimation angleAnimation = new DoubleAnimation();
           angleAnimation.From = 0;
           angleAnimation.To = 360;
           angleAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
           angleAnimation.RepeatBehavior = new RepeatBehavior(4);
          

          RotateTransform rotateTransform  = (RotateTransform)_numero.LayoutTransform;
          rotateTransform.CenterX = 0.5;
          rotateTransform.CenterY = 0.5;            
          rotateTransform.BeginAnimation(RotateTransform.AngleProperty, angleAnimation);

        }

       


        public void AddRotateAndTranslate(double windowWidth, int left, double zoom, int numBola)
        {
            AddCanvas();
            string _name = "n_" + this._numero.Name.ToString();
            
            Storyboard _storyboard = new Storyboard();

           

            DoubleAnimation leftNumAnimation = new DoubleAnimation();
            leftNumAnimation.Duration = TimeSpan.FromSeconds(2 - numBola * 0.04);
            leftNumAnimation.RepeatBehavior = new RepeatBehavior(1);
            leftNumAnimation.From = windowWidth;
            leftNumAnimation.To = (left + zoom / 2.5) + (numBola - 1) * zoom * 2;   

            Storyboard.SetTarget(leftNumAnimation, _numero);
            Storyboard.SetTargetProperty(leftNumAnimation, new PropertyPath(Canvas.LeftProperty));
            _storyboard.Children.Add(leftNumAnimation);

            
            DoubleAnimation leftElipseAnimation = new DoubleAnimation();
            leftElipseAnimation.Duration = TimeSpan.FromSeconds(2 - numBola * 0.04);
            leftElipseAnimation.RepeatBehavior = new RepeatBehavior(1);
            leftElipseAnimation.From = windowWidth - (zoom / 2.5);
            leftElipseAnimation.To = left + (numBola - 1) * zoom * 2;

            Storyboard.SetTarget(leftElipseAnimation, _elipse);
            Storyboard.SetTargetProperty(leftElipseAnimation, new PropertyPath(Canvas.LeftProperty));
            _storyboard.Children.Add(leftElipseAnimation);



           


            DoubleAnimation angleAnimation = new DoubleAnimation();
            angleAnimation.From = 360;
            angleAnimation.To = 0;
            angleAnimation.Duration = TimeSpan.FromSeconds(1 - numBola * 0.02);
            angleAnimation.RepeatBehavior = new RepeatBehavior(2);

            
            RotateTransform rotateTransform = (RotateTransform)_numero.LayoutTransform;
            rotateTransform.CenterX = 0.5;
            rotateTransform.CenterY = 0.5;
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, angleAnimation);


            //
            DoubleAnimation sizeNumAnimation = new DoubleAnimation();
            sizeNumAnimation.From = _numero.FontSize;
            sizeNumAnimation.To = _numero.FontSize*5;
            sizeNumAnimation.Duration = TimeSpan.FromSeconds(1 - numBola * 0.02);
            sizeNumAnimation.AutoReverse = true;
            sizeNumAnimation.RepeatBehavior = new RepeatBehavior(1);

            _numero.BeginAnimation(TextBlock.FontSizeProperty, sizeNumAnimation);


            DoubleAnimation sizeElipseAnimation = new DoubleAnimation();
            sizeElipseAnimation.From = _elipse.Height;
            sizeElipseAnimation.To = _elipse.Height * 5;
            sizeElipseAnimation.Duration = TimeSpan.FromSeconds(1 - numBola * 0.02);
            sizeElipseAnimation.AutoReverse = true;
            sizeElipseAnimation.RepeatBehavior = new RepeatBehavior(1);

            _elipse.BeginAnimation(Ellipse.HeightProperty, sizeElipseAnimation);
            _elipse.BeginAnimation(Ellipse.WidthProperty, sizeElipseAnimation);
            _storyboard.Begin();

        }

    } 
}

       

