//Класс "Окружность"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Circle : Shape
{
    public Point p0 { set; get; }
    public float cirWidth { set; get; }
    public float cirHeight { set; get; }

    //Конструктор
    public Circle(float width = 1) : this(Color.Black, Color.White, width) { }
    public Circle(Color penColor, Color fillColor, float width = 1)
    {
        aPenColor = penColor;
        aPenWidth = width;
        aFillColor = fillColor;
        myPen = new Pen(aPenColor, aPenWidth);
        myBrush = new SolidBrush(aFillColor);
    }


    public override void Draw(Graphics g, float x0, float y0, float width, float height)
    {
        g.FillEllipse(myBrush, x0, y0, width, height);
        g.DrawEllipse(myPen, x0, y0, width, height);
    }

    //Метод отрисовки окружности по точке центра и радиусу
    public void Draw(Graphics g, float x0, float y0, float radius)
    {
        g.FillEllipse(myBrush, x0 - radius, y0 - radius, radius * 2, radius * 2);
        g.DrawEllipse(myPen, x0 - radius, y0 - radius, radius * 2, radius * 2);
    }
}