//Класс "Эллипс"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Polygon : Shape
{
    public Dictionary<int, Point> polygonPoints;    //Словарь точек вершин многоугольника
    public bool isFinish;                           //Флаг сигнала завершения рисования многоугольника

    //Конструктор
    public Polygon(float width = 1) : this(Color.Black, Color.White, width) 
    {
        polygonPoints = new Dictionary<int, Point>();
    }
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

        polygonPoints = new Dictionary<int, Point>();
        isFinish = false;
    }

    public override void Draw(Graphics g, float x1, float y1, float x2, float y2)
    {
        if (showMode == TShowMode.MAIN_MODE)
            g.DrawLine(mainPen, x1, y1, x2, y2);
        else if (showMode == TShowMode.PRE_SHOW)
            g.DrawLine(preShowPen, x1, y1, x2, y2);
    }

    //Метод отрисовки многоугольника по массиву вершин
    public void Draw(Graphics g, Point[] points)
    {
        if (showMode == TShowMode.MAIN_MODE)
        {
            g.FillPolygon(mainBrush, points);
            g.DrawPolygon(mainPen, points);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            g.FillPolygon(preShowBrush, points);
            g.DrawPolygon(preShowPen, points);
        }
        
    }

    //Отрисовка многоугольника по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (isFinish)
        {
            Point[] points = new Point[polygonPoints.Count];
            polygonPoints.Values.CopyTo(points, 0);

            g.FillPolygon(mainBrush, points);
            g.DrawPolygon(mainPen, points);
        }
        else
        {
            Point[] points = new Point[polygonPoints.Count];
            polygonPoints.Values.CopyTo(points, 0);

            g.DrawLines(mainPen, points);
        }
    }
}
