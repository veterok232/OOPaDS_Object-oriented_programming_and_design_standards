//Абстрактный класс "Фигура"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

public abstract class Shape
{
    protected Color aPenColor { get; set; }    //Цвет пера
    protected Color aFillColor { get; set; }   //Цвет заливки
    protected float aPenWidth { get; set; }    //Толщина пера

    protected Pen myPen;          //Объект пера
    protected SolidBrush myBrush; //Объект кисти

    protected Point aLocation { get; set; }    //Левый верхний угол фигуры

    //Абстрактный метод для отрисовки фигуры
    public abstract void Draw(Graphics g, float x1, float y1, float x2, float y2);
}