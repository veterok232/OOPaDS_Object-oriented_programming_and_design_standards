//Класс "Ломаная"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class BrokenLine : Shape
{
    private Dictionary<int, Point> linePoints;  //Словарь точек ломаной

    //Конструктор
    public BrokenLine(float width = 1) : this(Color.Black, width) { }
    public BrokenLine(Color penColor, float width = 1)
    {
        aMainPenColor = penColor;
        aMainPenWidth = width;
        aPreShowPenWidth = width;
        mainPen = new Pen(mainPenColor, mainPenWidth);
        aPreShowPenColor = Color.FromArgb(150, penColor);
        preShowPen = new Pen(preShowPenColor, preShowPenWidth);
        showMode = TShowMode.MAIN_MODE;
        linePoints = new Dictionary<int, Point>();
    }

    //Отрисовка ломаной по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (pointsNumber < 2)
            return;

        mainPen.Color = mainPenColor;
        mainPen.Width = mainPenWidth;

        Point[] points = new Point[pointsNumber];
        linePoints.Values.CopyTo(points, 0);
        g.DrawLines(mainPen, points);
    }

    //Установить очередную точку ломаной
    public override void SetPoint(Point point)
    {
        linePoints[++pointsNumber] = point;
    }

    //Очистить информацию о точках ломаной
    public override void ClearPoints()
    {
        pointsNumber = 0;
        linePoints.Clear();
    }

    //Фигура сложная
    public override bool isComplex()
    {
        return true;
    }
}