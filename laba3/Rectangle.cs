//Класс "Прямоугольник"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Rectangle : Shape
{
    public Point p0 { set; get; }           //Координаты верхнего левого угла
    public float recWidth { set; get; }     //Ширина прямоугольника
    public float recHeight { set; get; }    //Высота прямоугольника

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

    //Метод отрисовки прямоугольника по левой верхней точке и значениям ширины и высоты
    public override void Draw(Graphics g, float x0, float y0, float width, float height)
    {
        if (showMode == TShowMode.MAIN_MODE)
        {
            g.FillRectangle(mainBrush, x0, y0, width, height);
            g.DrawRectangle(mainPen, x0, y0, width, height);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            g.FillRectangle(preShowBrush, x0, y0, width, height);
            g.DrawRectangle(preShowPen, x0, y0, width, height);
        }
    }

    //Отрисовка прямоугольника по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (showMode == TShowMode.MAIN_MODE)
        {
            g.FillRectangle(mainBrush, p0.X, p0.Y, recWidth, recHeight);
            g.DrawRectangle(mainPen, p0.X, p0.Y, recWidth, recHeight);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            g.FillRectangle(preShowBrush, p0.X, p0.Y, recWidth, recHeight);
            g.DrawRectangle(preShowPen, p0.X, p0.Y, recWidth, recHeight);
        }
        
    }
}
