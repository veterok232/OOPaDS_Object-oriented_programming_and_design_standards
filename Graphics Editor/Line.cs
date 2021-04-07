//Класс "Отрезок"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public class Line : Shape
{
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

    //Отрисовка линии по данным из полей класса
    public override void Draw(Graphics g)
    {
        if (showMode == TShowMode.MAIN_MODE)
        {
            mainPen.Color = aMainPenColor;
            mainPen.Width = aMainPenWidth;

            g.DrawLine(mainPen, Location[1], Location[2]);
        }
        else if (showMode == TShowMode.PRE_SHOW)
        {
            preShowPen.Color = Color.FromArgb(150, aMainPenColor);
            preShowPen.Width = aMainPenWidth;

            g.DrawLine(preShowPen, Location[1], Location[2]);
        }   
    }
}

