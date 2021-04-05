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
        aMainPenColor = penColor;
        aMainPenWidth = width;
        mainPen = new Pen(aMainPenColor, aMainPenWidth);
        aPreShowPenColor = Color.FromArgb(150, penColor);
        preShowPen = new Pen(aPreShowPenColor, aMainPenWidth);
        showMode = TShowMode.MAIN_MODE;
    }

    //Метод отрисовки линии
    public override void Draw(Graphics g, float x1, float y1, float x2, float y2)
    {
        if (showMode == TShowMode.MAIN_MODE)
            g.DrawLine(mainPen, x1, y1, x2, y2);
        else if (showMode == TShowMode.PRE_SHOW)
            g.DrawLine(preShowPen, x1, y1, x2, y2);
    }

    //Отрисовка линии по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (showMode == TShowMode.MAIN_MODE)
            g.DrawLine(mainPen, p1, p2);
        else if (showMode == TShowMode.PRE_SHOW)
            g.DrawLine(preShowPen, p1, p2);
    }
}

