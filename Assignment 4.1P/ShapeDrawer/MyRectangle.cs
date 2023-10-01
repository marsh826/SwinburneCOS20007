using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width, _height;

        public MyRectangle(Color clr, float x, float y, int height, int width) : base (clr)
        {
            _width = width;
            _height = height;
            X = x; 
            Y = y;
        }

        public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
        {

        }

        public int Width
        {
            set { _width = value; }
            get { return _width; }
        }

        public int Height
        {
            set { _height = value; }
            get { return _height; }
        }

        public override void Draw()
        {
            SplashKit.FillRectangle(color, X, Y, _width, _height);    
            if (Selected == true)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, (X - 2), (Y - 2), (Width + 4), (Height + 4));
        }

        public override bool IsAt(Point2D pt)
        {
            if ((X < pt.X) && (X + _width > pt.X) && (Y < pt.Y) && (Y + _height > pt.Y))
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
