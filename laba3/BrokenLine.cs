//Класс "Ломаная"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class BrokenLine : Shape
{
    public Dictionary<int, Point> linePoints;   //Словарь точек ломаной

    //Конструктор
    public BrokenLine(float width = 1) : this(Color.Black, width)
    {
        linePoints = new Dictionary<int, Point>();
    }
    public BrokenLine(Color penColor, float width = 1)
    {
        aMainPenColor = penColor;
        aMainPenWidth = width;
        mainPen = new Pen(aMainPenColor, aMainPenWidth);
        aPreShowPenColor = Color.FromArgb(150, penColor);
        preShowPen = new Pen(aPreShowPenColor, aMainPenWidth);
        showMode = TShowMode.MAIN_MODE;

        linePoints = new Dictionary<int, Point>();
    }

    //Метод отрисовки ломаной по массиву точек
    public override void Draw(Graphics g, float x1, float y1, float x2, float y2)
    {
        g.DrawLine(mainPen, x1, y1, x2, y2);
    }

    //Метод отрисовки ломаной по массиву точек
    public void Draw(Graphics g, Point[] points)
    {
        g.DrawLines(mainPen, points);
    }

    //Отрисовка ломаной по данным из полей класса
    public override void Draw(Graphics g)
    {
        Point[] points = new Point[linePoints.Count];
        linePoints.Values.CopyTo(points, 0);
        g.DrawLines(mainPen, points);
    }
}