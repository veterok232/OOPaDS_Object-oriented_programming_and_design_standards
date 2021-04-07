using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Ellipse : Shape
{
    private Point p0;           //Координаты левого верхнего угла прямоугольника, в который вписан эллипс
    private int ellWidth;       //Ширина прямоугольника, в который вписан эллипс
    private int ellHeight;      //Высота прямоугольника, в который вписан эллипс

    //Конструктор
    public Ellipse(float width = 1) : this(Color.Black, Color.White, width) { }
    public Ellipse(Color penColor, Color fillColor, float width = 1)
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
    }

    //Отрисока эллипса по данным из полей класса
    public override void Draw(Graphics g)
    {
        p0 = Location[1];
        ellWidth = Location[2].X - Location[1].X;
        ellHeight = Location[2].Y - Location[1].Y;

        if (showMode == TShowMode.MAIN_MODE)
        {
            mainPen.Color = aMainPenColor;
            mainBrush.Color = aMainFillColor;
            mainPen.Width = aMainPenWidth;

            g.FillEllipse(mainBrush, p0.X, p0.Y, ellWidth, ellHeight);
            g.DrawEllipse(mainPen, p0.X, p0.Y, ellWidth, ellHeight);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            preShowPen.Color = Color.FromArgb(150, aMainPenColor);
            preShowBrush.Color = Color.FromArgb(150, aMainFillColor);
            preShowPen.Width = aMainPenWidth;

            g.FillEllipse(preShowBrush, p0.X, p0.Y, ellWidth, ellHeight);
            g.DrawEllipse(preShowPen, p0.X, p0.Y, ellWidth, ellHeight);
        }
    }
}