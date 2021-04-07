//Класс "Окружность"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Circle : Shape
{
    private Point p0;           //Координаты центра круга
    private int cirWidth;       //Ширина прямоугольника, описанного вокруг круга
    private int cirHeight;      //Высота прямоугольника, описанного вокруг круга
    private float radius;       //Радиус круга

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

    //Отрисовка круга по данным из полей класса
    public override void Draw(Graphics g)
    {
        p0 = Location[1];
        cirWidth = Math.Abs(Location[2].X - Location[1].X);
        cirHeight = Math.Abs(Location[2].Y - Location[1].Y);
        radius = (float)Math.Round(Math.Sqrt((double)cirWidth * cirWidth + cirHeight * cirHeight));

        if (showMode == TShowMode.MAIN_MODE)
        {
            mainPen.Color = aMainPenColor;
            mainBrush.Color = aMainFillColor;
            mainPen.Width = aMainPenWidth;

            g.FillEllipse(mainBrush, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
            g.DrawEllipse(mainPen, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            preShowPen.Color = Color.FromArgb(150, aMainPenColor);
            preShowBrush.Color = Color.FromArgb(150, aMainFillColor);
            preShowPen.Width = aMainPenWidth;

            g.FillEllipse(preShowBrush, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
            g.DrawEllipse(preShowPen, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
        }
    }
}