using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        int _radius;

        public MyCircle(Color clr, float x, float y, int radius) : base(clr)
        {
            _radius = radius;
        }

        public MyCircle() : this(Color.Blue, 0, 0, 50)
        {

        }

        public int Radius
        {
            get { return _radius; }
        }

        public override void Draw()
        {
            SplashKit.FillCircle(color, X, Y, _radius);
            if (Selected == true)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, Radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            if (((X - pt.X)*(X - pt.X)) + ((Y - pt.Y)*(Y - pt.Y)) <= (_radius*_radius))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
