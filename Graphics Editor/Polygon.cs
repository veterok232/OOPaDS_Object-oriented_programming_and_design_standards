//Класс "Эллипс"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Polygon : Shape
{
    private Dictionary<int, Point> polygonPoints;   //Словарь точек многоугольника

    //Конструктор
    public Polygon()
    {
        mainPen = new Pen(mainPenColor, mainPenWidth);
        mainBrush = new SolidBrush(mainFillColor);
        preShowPen = new Pen(preShowPenColor, preShowPenWidth);
        preShowBrush = new SolidBrush(preShowFillColor);
    }

    public Polygon(float width = 1) : this(Color.Black, Color.White, width) {  }

    public Polygon(Color penColor, Color fillColor, float width = 1)
    {
        aMainPenColor = penColor;
        aMainPenWidth = width;
        aMainFillColor = fillColor;
        aPreShowPenWidth = width;
        mainBrush = new SolidBrush(mainFillColor);
        mainPen = new Pen(mainPenColor, mainPenWidth);
        aPreShowPenColor = Color.FromArgb(150, penColor);
        preShowPen = new Pen(preShowPenColor, preShowPenWidth);
        aPreShowFillColor = Color.FromArgb(150, fillColor);
        preShowBrush = new SolidBrush(preShowFillColor);
        showMode = TShowMode.MAIN_MODE;
        isFinish = false;

        polygonPoints = new Dictionary<int, Point>();
    }

    //Отрисовка многоугольника по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (pointsNumber < 2)
            return;

        if (isFinish)
        {
            mainPen.Color = mainPenColor;
            mainBrush.Color = mainFillColor;
            mainPen.Width = mainPenWidth;

            Point[] points = new Point[pointsNumber];
            polygonPoints.Values.CopyTo(points, 0);

            g.FillPolygon(mainBrush, points);
            g.DrawPolygon(mainPen, points);
        }
        else
        {
            mainPen.Color = mainPenColor;
            mainBrush.Color = mainFillColor;
            mainPen.Width = mainPenWidth;

            Point[] points = new Point[pointsNumber];
            polygonPoints.Values.CopyTo(points, 0);

            g.DrawLines(mainPen, points);
        }
    }

    //Установить очередную точку многоугольника
    public override void SetPoint(Point point)
    {
        polygonPoints[++pointsNumber] = point;

        shapePoints = new Point[pointsNumber];
        polygonPoints.Values.CopyTo(shapePoints, 0);
    }

    public override void SetPoints()
    {
        polygonPoints = new Dictionary<int, Point>();
        int count = 0;

        foreach (var point in shapePoints)
        {
            polygonPoints[++count] = point;
        }
    }

    //Очистить информацию о точках многоугольника
    public override void ClearPoints()
    {
        pointsNumber = 0;
        polygonPoints.Clear();
        shapePoints = null;
    }

    //Фигура сложная
    public override bool isComplex()
    {
        return true;
    }

    //Метод для создания копии объекта фигуры
    public override Shape Clone()
    {
        var clonePolygonPoints = new Dictionary<int, Point>(polygonPoints);
        var newShape = (Polygon)this.MemberwiseClone();
        newShape.polygonPoints = clonePolygonPoints;
        return newShape;
    }
}
