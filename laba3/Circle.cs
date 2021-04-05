//Класс "Окружность"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Circle : Shape
{
    public Point p0 { set; get; }           //Координаты центра круга
    public float cirWidth { set; get; }     //Ширина квадрата, в который вписан круг
    public float cirHeight { set; get; }    //Высота прямоугольника, в который вписан круг
    public float radius { set; get; }       //Радиус круга

    //Конструктор
    public Circle(float width = 1) : this(Color.Black, Color.White, width) { }
    public Circle(Color penColor, Color fillColor, float width = 1)
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

    //Метод отрисовки окружности по точке центра и радиусу
    public void Draw(Graphics g, float x0, float y0, float radius)
    {
        if (showMode == TShowMode.MAIN_MODE)
        {
            g.FillEllipse(mainBrush, x0 - radius, y0 - radius, radius * 2, radius * 2);
            g.DrawEllipse(mainPen, x0 - radius, y0 - radius, radius * 2, radius * 2);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            g.FillEllipse(preShowBrush, x0 - radius, y0 - radius, radius * 2, radius * 2);
            g.DrawEllipse(preShowPen, x0 - radius, y0 - radius, radius * 2, radius * 2);
        }
    }

    //Отрисовка круга по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (showMode == TShowMode.MAIN_MODE)
        {
            g.FillEllipse(mainBrush, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
            g.DrawEllipse(mainPen, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            g.FillEllipse(preShowBrush, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
            g.DrawEllipse(preShowPen, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
        }
    }
}