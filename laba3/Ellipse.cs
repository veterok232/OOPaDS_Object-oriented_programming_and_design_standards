using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Ellipse : Shape
{
    public Point p0 { set; get; }           //Координаты левого верхнего угла прямоугольника, в который вписан эллипс
    public float ellWidth { set; get; }     //Ширина прямоугольника, в который вписан эллипс
    public float ellHeight { set; get; }    //Высота прямоугольника, в который вписан эллипс

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

    //Метод отрисовки эллипса
    public override void Draw(Graphics g, float x0, float y0, float width, float height)
    {
        if (showMode == TShowMode.MAIN_MODE)
        {
            g.FillEllipse(mainBrush, x0, y0, width, height);
            g.DrawEllipse(mainPen, x0, y0, width, height);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            g.FillEllipse(preShowBrush, x0, y0, width, height);
            g.DrawEllipse(preShowPen, x0, y0, width, height);
        }
    }

    //Отрисока эллипса по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (showMode == TShowMode.MAIN_MODE)
        {
            g.FillEllipse(mainBrush, p0.X, p0.Y, ellWidth, ellHeight);
            g.DrawEllipse(mainPen, p0.X, p0.Y, ellWidth, ellHeight);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            g.FillEllipse(preShowBrush, p0.X, p0.Y, ellWidth, ellHeight);
            g.DrawEllipse(preShowPen, p0.X, p0.Y, ellWidth, ellHeight);
        }
    }
}