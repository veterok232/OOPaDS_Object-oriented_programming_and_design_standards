//Класс "Прямоугольник"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Rectangle : Shape
{
    private Point p0;           //Координаты верхнего левого угла
    private int recWidth;       //Ширина прямоугольника
    private int recHeight;      //Высота прямоугольника

    //Конструктор
    public Rectangle(float width = 1) : this(Color.Black, Color.White, width) { }
    public Rectangle(Color penColor, Color fillColor, float width = 1)
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

    //Отрисовка прямоугольника по данным из полей класса
    public override void Draw(Graphics g)
    {
        int recWidth0 = Location[2].X - Location[1].X;
        int recHeight0 = Location[2].Y - Location[1].Y;
        Point position = new Point(Location[1].X, Location[1].Y);

        if (recWidth0 < 0)
            position.X = Location[1].X + recWidth0;
        if (recHeight0 < 0)
            position.Y = Location[1].Y + recHeight0;

        p0 = position;

        recWidth = Math.Abs(recWidth0);
        recHeight = Math.Abs(recHeight0);

        if (showMode == TShowMode.MAIN_MODE)
        {
            mainPen.Color = aMainPenColor;
            mainBrush.Color = aMainFillColor;
            mainPen.Width = aMainPenWidth; 

            g.FillRectangle(mainBrush, p0.X, p0.Y, recWidth, recHeight);
            g.DrawRectangle(mainPen, p0.X, p0.Y, recWidth, recHeight);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            preShowPen.Color = Color.FromArgb(150, aMainPenColor);
            preShowBrush.Color = Color.FromArgb(150, aMainFillColor);
            preShowPen.Width = aMainPenWidth;

            g.FillRectangle(preShowBrush, p0.X, p0.Y, recWidth, recHeight);
            g.DrawRectangle(preShowPen, p0.X, p0.Y, recWidth, recHeight);
        }
        
    }
}
