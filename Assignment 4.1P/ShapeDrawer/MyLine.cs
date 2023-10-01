using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class MyLine : Shape
    {
        float _startX, _startY, _endX, _endY;

        public MyLine(Color clr,float startX, float startY, float endX, float endY) : base(clr)
        {
            _startX = startX;
            _startY = startY;
            _endX = endX;
            _endY = endY;
        }

        public MyLine() : this(Color.Red, 0, 0, 0, 0)
        {

        }


        public float StartX
        {
            get { return _startX; }
            set { _startX = value; }
        }

        public float StartY
        {
            get { return _startY; }
            set { _startY = value; }
        }

        public float EndX
        {
            get { return _endX; }
            set { _endX = value; }
        }

        public float EndY
        {
            get { return _endY; }
            set { _endY = value; }
        }

        public override void Draw()
        {
            SplashKit.DrawLine(color, _startX, _startY, _endX, _endY);
            if(Selected == true)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, _startX, _startY, 5);
            SplashKit.DrawCircle(Color.Black, _endX, _endY, 5);
        }

        public override bool IsAt(Point2D pt)
        {
            if ((_startX < pt.X) && (pt.X < _endX) && (_startY < pt.Y) && (pt.Y < _endY))
            {
                return true;
            }

            return false;
            
        }

        public static MyLine operator +(MyLine start, MyLine end)
        {
            MyLine newLine = new MyLine();
            newLine.StartX = start.X;
            newLine.StartY = start.Y;
            newLine.EndX = end.X;
            newLine.EndY = end.Y;
            return newLine;
        }
    }
}
