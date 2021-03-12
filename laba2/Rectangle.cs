//Класс "Прямоугольник"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Rectangle : Shape
{
    public Point p0 { set; get; }
    public float recWidth { set; get; }
    public float recHeight { set; get; }

    //Конструктор
    public Rectangle(float width = 1) : this(Color.Black, Color.White, width) { }
    public Rectangle(Color penColor, Color fillColor, float width = 1)
    {
        aPenColor = penColor;
        aPenWidth = width;
        aFillColor = fillColor;
        myPen = new Pen(aPenColor, aPenWidth);
        myBrush = new SolidBrush(aFillColor);
    }

    //Метод отрисовки прямоугольника по левой верхней точке и значениям ширины и высоты
    public override void Draw(Graphics g, float x0, float y0, float width, float height)
    {
        g.FillRectangle(myBrush, x0, y0, width, height);
        g.DrawRectangle(myPen, x0, y0, width, height);
    }
}
