using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Ellipse : Shape
{
    private Point p0;           //Координаты левого верхнего угла прямоугольника, в который вписан эллипс
    private Point p1;           //Координаты правого нижнего угла прямоугольника, в который вписан эллипс
    private int ellWidth;       //Ширина прямоугольника, в который вписан эллипс
    private int ellHeight;      //Высота прямоугольника, в который вписан эллипс

    //Конструктор
    public Ellipse()
    {
        mainPen = new Pen(mainPenColor, mainPenWidth);
        mainBrush = new SolidBrush(mainFillColor);
        preShowPen = new Pen(preShowPenColor, preShowPenWidth);
        preShowBrush = new SolidBrush(preShowFillColor);
    }
    public Ellipse(float width = 1) : this(Color.Black, Color.White, width) { }
    public Ellipse(Color penColor, Color fillColor, float width = 1)
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
    }

    //Отрисока эллипса по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (pointsNumber != 2)
            return;

        ellWidth = p1.X - p0.X;
        ellHeight = p1.Y - p0.Y;

        if (showMode == TShowMode.MAIN_MODE)
        {
            mainPen.Color = mainPenColor;
            mainBrush.Color = mainFillColor;
            mainPen.Width = mainPenWidth;

            g.FillEllipse(mainBrush, p0.X, p0.Y, ellWidth, ellHeight);
            g.DrawEllipse(mainPen, p0.X, p0.Y, ellWidth, ellHeight);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            preShowPen.Color = Color.FromArgb(150, preShowPenColor);
            preShowBrush.Color = Color.FromArgb(150, preShowFillColor);
            preShowPen.Width = preShowPenWidth;

            g.FillEllipse(preShowBrush, p0.X, p0.Y, ellWidth, ellHeight);
            g.DrawEllipse(preShowPen, p0.X, p0.Y, ellWidth, ellHeight);
        }
    }

    //Установить очередную точку эллипса
    public override void SetPoint(Point point)
    {
        if (pointsNumber == 0)
        {
            p0 = point;
            point1 = point;
        }
        else
        {
            p1 = point;
            point2 = point;
        }

        if (pointsNumber < 2)
            pointsNumber++;
    }

    public override void SetPoints()
    {
        p0 = point1;
        p1 = point2;
    }

    //Очистить информацию о точках эллипса
    public override void ClearPoints()
    {
        pointsNumber = 0;
        p0 = Point.Empty;
        p1 = Point.Empty;
        point1 = Point.Empty;
        point2 = Point.Empty;
        ellWidth = 0;
        ellHeight = 0;
    }

    //Фигура не сложная
    public override bool isComplex()
    {
        return false;
    }

    //Метод для создания копии объекта фигуры
    public override Shape Clone()
    {
        return (Ellipse)this.MemberwiseClone();
    }
}