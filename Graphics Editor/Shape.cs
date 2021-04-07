//Абстрактный класс "Фигура"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public abstract class Shape
{
    public Color aMainPenColor { get; set; }    //Цвет пера
    public Color aMainFillColor { get; set; }   //Цвет заливки
    public float aMainPenWidth { get; set; }    //Толщина пера

    protected Color aPreShowPenColor { get; set; }    //Цвет пера предпросмотра
    protected Color aPreShowFillColor { get; set; }   //Цвет заливки предпросмотра
    protected float aPreShowPenWidth { get; set; }    //Толщина пера предпросмотра

    protected Pen mainPen;                  //Объект пера
    protected Pen preShowPen;               //Объект пера предпросмотра фигуры
    protected SolidBrush mainBrush;         //Объект кисти
    protected SolidBrush preShowBrush;      //Объект кисти предпросмотра фигуры

    public bool isComplex;                  //Флаг, сложная ли фигура
    public bool isFinish;                   //Флаг, конец рисования фигуры
    public Dictionary<int, Point> Location; //Словарь точек, описывающих положение фигуры
    public int pointsNumber;                //Количество точек, описывающих положение фигуры

    //Режим рисования фигуры(обычный, режим предпросмотра)
    public enum TShowMode { MAIN_MODE, PRE_SHOW };
    public TShowMode showMode;

    public Shape()
    {
        isFinish = false;
        isComplex = false;
        pointsNumber = 0;
        Location = new Dictionary<int, Point>();
    }

    //Абстрактный метод для отрисовки фигуры
    public abstract void Draw(Graphics g);
}