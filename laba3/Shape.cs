//Абстрактный класс "Фигура"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public abstract class Shape
{
    protected Color aMainPenColor { get; set; }    //Цвет пера
    protected Color aMainFillColor { get; set; }   //Цвет заливки
    protected float aMainPenWidth { get; set; }    //Толщина пера

    protected Color aPreShowPenColor { get; set; }    //Цвет пера предпросмотра
    protected Color aPreShowFillColor { get; set; }   //Цвет заливки предпросмотра
    protected float aPreShowPenWidth { get; set; }    //Толщина пера предпросмотра

    protected Pen mainPen;                  //Объект пера
    protected Pen preShowPen;               //Объект пера предпросмотра фигуры
    protected SolidBrush mainBrush;         //Объект кисти
    protected SolidBrush preShowBrush;      //Объект кисти предпросмотра фигуры

    //Режим рисования фигуры(обычный, режим предпросмотра)
    public enum TShowMode { MAIN_MODE, PRE_SHOW };
    public TShowMode showMode;

    //Абстрактный метод для отрисовки фигуры
    public abstract void Draw(Graphics g, float x1, float y1, float x2, float y2);
    public abstract void Draw(Graphics g);
}