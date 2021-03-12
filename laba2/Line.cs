//Класс "Отрезок"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Line : Shape
{
    public Point p1 { set; get; }    //Координаты начала отрезка
    public Point p2 { set; get; }    //Координаты конца отрезка


    public Line(float width = 1) : this(Color.Black, width) { }
    public Line(Color penColor, float width = 1)
    {
        aPenColor = penColor;
        aPenWidth = width;
        myPen = new Pen(aPenColor, aPenWidth);
    }

    //Метод отрисовки линии
    public override void Draw(Graphics g, float x1, float y1, float x2, float y2)
    {
        g.DrawLine(myPen, x1, y1, x2, y2);
    }
}

