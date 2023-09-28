using System;
using SplashKitSDK;
using System.Collections.Generic;

namespace ShapeDrawer
{
    public class Program
    {
        public class Shape
        {
            private Color _color;
            private float _x, _y;
            private int _width, _height;
            private bool _selected;

            public Shape()
            {
                _color = Color.Green;
                _x = 0;
                _y = 0;
                _width = 100;
                _height = 100;
                _selected = false;
            }

            public Color color
            {
                set { _color = value; }
                get { return _color; }
            }

            public float X
            {
                set { _x = value; }
                get { return _x; }
            }

            public float Y
            {
                set { _y = value; }
                get { return _y; }
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

            public bool Selected
            {
                set { _selected = value; }
                get { return _selected; }
            }

            public void Draw()
            {
                SplashKit.FillRectangle(_color, _x, _y, _width, _height);
                if(Selected == true)
                {
                    DrawOutline();
                }
            }

            public bool IsAt(Point2D pt)
            {

                if ((X < pt.X) && (X+_width > pt.X) && (Y < pt.Y) && (Y + _height > pt.Y))
                {
                    return true;
                } 
                else
                {
                    return  false;
                }
            }

            public void DrawOutline()
            {
                SplashKit.DrawRectangle(Color.Black, (X - 2), (Y - 2), (Width+4), (Height+4));
            }
        }

        public class Drawing
        {
            private readonly List<Shape> _shapes;
            private Color _background;

            public Drawing(Color background)
            {
                _shapes = new List<Shape>();
                _background = background;
            }

            public Drawing() : this (Color.White)
            {
                _shapes = new List<Shape>();
            }

            public Color Background
            {
                set { _background = value; }
                get { return _background; }
            }

            public int ShapeCount
            {
                get { return _shapes.Count; }
            }

            public List<Shape> SelectedShapes
            {
                get
                {
                    List<Shape> result = new List<Shape>();
                    foreach (Shape s in _shapes)
                    {
                        if (s.Selected == true)
                        {
                            result.Add(s);
                        }
                    }
                    return result;
                }
            }

            public void AddShape(Shape newShape)
            {
                _shapes.Add(newShape);
            }

            public void Draw()
            {
                SplashKit.ClearScreen(_background);
                foreach (Shape shape in _shapes)
                {
                    shape.Draw();
                }
            }

            public void SelectShapeAt(Point2D pt)
            {
                foreach(Shape s in _shapes)
                {
                    if (s.IsAt(pt))
                    {
                    	s.Selected = true;
                    }
                }
            }

            public void RemoveShape(Shape shape)
            {
                _shapes.Remove(shape);
            }
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            Drawing draw = new Drawing();
            do
            {
                SplashKit.ProcessEvents();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape randomShape = new Shape();
                    randomShape.X = SplashKit.MouseX();
                    randomShape.Y = SplashKit.MouseY();
                    draw.AddShape(randomShape);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    draw.SelectShapeAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    draw.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach(Shape s in draw.SelectedShapes)
                    {
                        draw.RemoveShape(s);
                    }
                }

                draw.Draw();

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
