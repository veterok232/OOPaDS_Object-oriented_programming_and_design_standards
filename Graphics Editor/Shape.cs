//Абстрактный класс "Фигура"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public abstract class Shape
{
    protected Color mainPenColor;
    protected Color mainFillColor;
    protected float mainPenWidth;
    protected Color preShowPenColor;
    protected Color preShowFillColor;
    protected float preShowPenWidth;


    public Color aMainPenColor //Цвет пера 
    {
        set
        {
            mainPenColor = value;
        }
    }    
    public Color aMainFillColor    //Цвет заливки
    {
        set
        {
            mainFillColor = value;
        }
    }
    public float aMainPenWidth     //Толщина пера
    {
        set
        {
            mainPenWidth = value;
        }
    }

    public Color aPreShowPenColor    //Цвет пера предпросмотра
    {
        set
        {
            preShowPenColor = value;
        }
    }
    public Color aPreShowFillColor   //Цвет заливки предпросмотра
    {
        set
        {
            preShowFillColor = value;
        }
    }
    public float aPreShowPenWidth    //Толщина пера предпросмотра
    {
        set
        {
            preShowPenWidth = value;
        }
    }

    protected Pen mainPen;                  //Объект пера
    protected Pen preShowPen;               //Объект пера предпросмотра фигуры
    protected SolidBrush mainBrush;         //Объект кисти
    protected SolidBrush preShowBrush;      //Объект кисти предпросмотра фигуры

    public bool isFinish;                   //Флаг, конец рисования фигуры
    protected int pointsNumber;
    public int PointsNumber                 //Количество точек, описывающих положение фигуры
    {
        get
        {
            return pointsNumber;
        }
    } 

    //Режим рисования фигуры(обычный, режим предпросмотра)
    public enum TShowMode { MAIN_MODE, PRE_SHOW };
    public TShowMode showMode;

    public abstract bool isComplex();        //Метод возвращает константу сложная ли фигура

    public Shape()
    {
        isFinish = false;
        pointsNumber = 0;
    }

    //Абстрактный метод для отрисовки фигуры
    public abstract void Draw(Graphics g);

    //Установить следующую точку фигуры
    public abstract void SetPoint(Point point);
    
    //Очистить информацию о точках фигуры 
    public abstract void ClearPoints();
}