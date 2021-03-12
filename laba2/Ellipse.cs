using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Ellipse : Shape
{
    public Point p0 { set; get; }
    public float ellWidth { set; get; }
    public float ellHeight { set; get; }

    //Конструктор
    public Ellipse(float width = 1) : this(Color.Black, Color.White, width) { }
    public Ellipse(Color penColor, Color fillColor, float width = 1)
    {
        aPenColor = penColor;
        aFillColor = fillColor;
        aPenWidth = width;
        myPen = new Pen(aPenColor, aPenWidth);
        myBrush = new SolidBrush(aFillColor);
    }

    //Метод отрисовки эллипса
    public override void Draw(Graphics g, float x0, float y0, float width, float height)
    {
        g.FillEllipse(myBrush, x0, y0, width, height);
        g.DrawEllipse(myPen, x0, y0, width, height);
    }
}