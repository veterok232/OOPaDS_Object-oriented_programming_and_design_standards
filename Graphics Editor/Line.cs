//Класс "Отрезок"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Line : Shape
{
    private Point p1;   //Первая точка отрезка
    private Point p2;   //Вторая точка отрезка

    public Line(float width = 1) : this(Color.Black, width) { }
    public Line(Color penColor, float width = 1)
    {
        aMainPenColor = penColor;
        aMainPenWidth = width;
        aPreShowPenWidth = width;
        mainPen = new Pen(mainPenColor, mainPenWidth);
        aPreShowPenColor = Color.FromArgb(150, penColor);
        preShowPen = new Pen(preShowPenColor, preShowPenWidth);
        showMode = TShowMode.MAIN_MODE;
    }

    //Отрисовка линии по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (pointsNumber != 2)
            return;

        if (showMode == TShowMode.MAIN_MODE)
        {
            mainPen.Color = mainPenColor;
            mainPen.Width = mainPenWidth;

            g.DrawLine(mainPen, p1, p2);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            preShowPen.Color = Color.FromArgb(150, preShowPenColor);
            preShowPen.Width = preShowPenWidth;

            g.DrawLine(preShowPen, p1, p2);
        }
    }

    //Установить очередную точку отрезка
    public override void SetPoint(Point point)
    {
        if (pointsNumber == 0)
            p1 = point;
        else
            p2 = point;

        if (pointsNumber < 2)
            pointsNumber++;
    }

    //Очистить информацию о точках отрезка
    public override void ClearPoints()
    {
        pointsNumber = 0;
        p1 = Point.Empty;
        p2 = Point.Empty;
    }

    //Фигура не сложная
    public override bool isComplex()
    {
        return false;
    }

    //Метод для создания копии объекта фигуры
    public override Shape Clone()
    {
        return (Line)this.MemberwiseClone();
    }
}

