//Класс "Ломаная"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class BrokenLine : Shape
{
    public Point[] linePoints { set; get; } 

    //Конструктор
    public BrokenLine(float width = 1) : this(Color.Black, width) { }
    public BrokenLine(Color color, float width = 1)
    {
        aPenColor = color;
        aPenWidth = width;
        myPen = new Pen(aPenColor, aPenWidth);
    }

    //Метод отрисовки ломаной по массиву точек
    public override void Draw(Graphics g, float x1, float y1, float x2, float y2)
    {
        g.DrawLine(myPen, x1, y1, x2, y2);
    }

    //Метод отрисовки ломаной по массиву точек
    public void Draw(Graphics g, Point[] points)
    {
        g.DrawLines(myPen, points);
    }
}