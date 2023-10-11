using System;
using SplashKitSDK;
using System.Collections.Generic;
using System.IO;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Circle,
            Rectangle,
            Line
        }

        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);
            ShapeKind kindToAdd = ShapeKind.Circle;
            Drawing draw = new Drawing();
            int clicked = 0;

            List<MyLine> lines = new List<MyLine>();

            do
            {
                SplashKit.ProcessEvents();
                draw.Draw();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape = new MyRectangle();
                    }
                    else if(kindToAdd == ShapeKind.Circle)
                    {
                        newShape = new MyCircle();
                    }
                    else
                    {
                        clicked++;
                        newShape = new MyLine();
                        if (clicked == 1)
                        {
                            MyLine line1 = new MyLine();
                            line1.X = SplashKit.MouseX();
                            line1.Y = SplashKit.MouseY();
                            lines.Add(line1);
                        }

                        if (clicked == 2)
                        {
                            MyLine line2 = new MyLine();
                            line2.X = SplashKit.MouseX();
                            line2.Y = SplashKit.MouseY();
                            lines.Add(line2);   
                            clicked = 0;
                        }
                    }

                    if (kindToAdd == ShapeKind.Circle || kindToAdd == ShapeKind.Rectangle)
                    {
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                    }
                    else
                    {
                        if (lines.Count == 2)
                        {
                            newShape = lines[0] + lines[1];
                            lines.Clear();
                        }
                    }
                    draw.AddShape(newShape);
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
                    foreach (Shape s in draw.SelectedShapes)
                    {
                        draw.RemoveShape(s);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    //path may vary depends on the chosen directory within each computer
                    string path = "C:\\msys64\\home\\anlong\\ShapeDrawer\\TestDrawing.txt";
                    draw.Save(path);
                    Console.WriteLine("Drawing Saved!");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {

                    Console.WriteLine("Drawing Loaded");
                    try
                    {
                        string path = "C:\\msys64\\home\\anlong\\ShapeDrawer\\TestDrawing.txt";
                        draw.Load(path);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                }

                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
