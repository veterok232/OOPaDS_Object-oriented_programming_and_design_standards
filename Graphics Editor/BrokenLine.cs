//Класс "Ломаная"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class BrokenLine : Shape
{
    //Конструктор
    public BrokenLine(float width = 1) : this(Color.Black, width) { }
    public BrokenLine(Color penColor, float width = 1)
    {
        aMainPenColor = penColor;
        aMainPenWidth = width;
        mainPen = new Pen(aMainPenColor, aMainPenWidth);
        aPreShowPenColor = Color.FromArgb(150, penColor);
        preShowPen = new Pen(aPreShowPenColor, aMainPenWidth);
        showMode = TShowMode.MAIN_MODE;
    }

    //Отрисовка ломаной по данным из полей класса
    public override void Draw(Graphics g)
    {
        mainPen.Color = aMainPenColor;
        mainPen.Width = aMainPenWidth;

        Point[] points = new Point[pointsNumber];
        Location.Values.CopyTo(points, 0);
        g.DrawLines(mainPen, points);
    }
}