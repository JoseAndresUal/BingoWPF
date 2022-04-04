
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace SDKSamples
{
    // This example shows how to use PointAnimation to animate the
    // position of an ellipse by animating the Center property of an 
    // EllipseGeometry. PointAnimation is used because the Center property
    // takes a Point value.
    public class PointAnimationExample : Window
    {
        public PointAnimationExample()
        {


            PointAnimation myPointAnimation = new PointAnimation();
            myPointAnimation.Duration = TimeSpan.FromSeconds(10);

            // Set the animation to repeat forever. 
            myPointAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Set the From and To properties of the animation.
            myPointAnimation.From = new Point(200, 100);
            myPointAnimation.To = new Point(450, 250);

            // Set the animation to target the Center property
            // of the object named "MyAnimatedEllipseGeometry."
            Storyboard.SetTargetName(myPointAnimation, "MyAnimatedEllipseGeometry");
            Storyboard.SetTargetProperty(
                myPointAnimation, new PropertyPath(EllipseGeometry.CenterProperty));

            // Create a storyboard to apply the animation.
            Storyboard ellipseStoryboard = new Storyboard();
            ellipseStoryboard.Children.Add(myPointAnimation);


        }

    }
}


