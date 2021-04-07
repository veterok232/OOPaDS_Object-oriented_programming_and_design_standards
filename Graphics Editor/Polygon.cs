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
        aMainPenColor = penColor;
        aMainPenWidth = width;
        aMainFillColor = fillColor;
        mainPen = new Pen(aMainPenColor, aMainPenWidth);
        mainBrush = new SolidBrush(aMainFillColor);
        aPreShowPenColor = Color.FromArgb(150, penColor);
        preShowPen = new Pen(aPreShowPenColor, aMainPenWidth);
        aPreShowFillColor = Color.FromArgb(150, fillColor);
        preShowBrush = new SolidBrush(aPreShowFillColor);
        showMode = TShowMode.MAIN_MODE;
        isFinish = false;
    }

    //Отрисовка многоугольника по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (isFinish)
        {
            mainPen.Color = aMainPenColor;
            mainBrush.Color = aMainFillColor;
            mainPen.Width = aMainPenWidth;

            Point[] points = new Point[pointsNumber];
            Location.Values.CopyTo(points, 0);

            g.FillPolygon(mainBrush, points);
            g.DrawPolygon(mainPen, points);
        }
        else
        {
            mainPen.Color = aMainPenColor;
            mainBrush.Color = aMainFillColor;
            mainPen.Width = aMainPenWidth;

            Point[] points = new Point[pointsNumber];
            Location.Values.CopyTo(points, 0);

            g.DrawLines(mainPen, points);
        }
    }
}
