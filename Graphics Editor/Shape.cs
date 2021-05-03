//Абстрактный класс "Фигура"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Graphics_Editor
{
    public abstract class Shape
    {
        public Color mainPenColor;
        public Color mainFillColor;
        public float mainPenWidth;
        public Color preShowPenColor;
        public Color preShowFillColor;
        public float preShowPenWidth;


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

        //Пара точек для простых фигур
        public Point point1;
        public Point point2;

        //Массив точек для сложных фигур
        public Point[] shapePoints;

        public int PointsNumber                 //Количество точек, описывающих положение фигуры
        {
            get
            {
                return pointsNumber;
            }
            set
            {
                pointsNumber = value;
            }
        }

        //Режим рисования фигуры(обычный, режим предпросмотра)
        public enum TShowMode { MAIN_MODE, PRE_SHOW };
        public TShowMode showMode;

        public abstract bool isComplex();        //Метод возвращает константу сложная ли фигура

        public Shape()
        {

        }

        //Абстрактный метод для создания копии объекта фигуры
        public abstract Shape Clone();

        //Абстрактный метод для отрисовки фигуры
        public abstract void Draw(Graphics g);

        //Установить следующую точку фигуры
        public abstract void SetPoint(Point point);

        //Перенести точки фигуры из общего класса в дочерний
        public abstract void SetPoints();

        //Очистить информацию о точках фигуры 
        public abstract void ClearPoints();
    }
}