//Класс "Эллипс"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Polygon : Shape
{
    //Конструктор
    public Polygon(float width = 1) : this(Color.Black, Color.White, width) { }
    public Polygon(Color penColor, Color fillColor, float width = 1)
    {
        aPenColor = penColor;
        aPenWidth = width;
        aFillColor = fillColor;
        myPen = new Pen(aPenColor, aPenWidth);
        myBrush = new SolidBrush(aFillColor);
    }

    public override void Draw(Graphics g, float x1, float y1, float x2, float y2)
    {

    }

    //Метод отрисовки многоугольника по массиву вершин
    public void Draw(Graphics g, Point[] points)
    {
        g.FillPolygon(myBrush, points);
        g.DrawPolygon(myPen, points);
    }
}
