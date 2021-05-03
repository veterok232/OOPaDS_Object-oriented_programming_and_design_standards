//Класс "Окружность"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Graphics_Editor
{
    public class Circle : Shape
    {
        private Point p0;           //Координаты центра круга
        private Point p1;           //Координаты края круга
        private int cirWidth;       //Ширина прямоугольника, описанного вокруг круга
        private int cirHeight;      //Высота прямоугольника, описанного вокруг круга
        private float radius;       //Радиус круга

        //Конструктор
        public Circle()
        {
            mainPen = new Pen(mainPenColor, mainPenWidth);
            mainBrush = new SolidBrush(mainFillColor);
            preShowPen = new Pen(preShowPenColor, preShowPenWidth);
            preShowBrush = new SolidBrush(preShowFillColor);
        }

        public Circle(float width = 1) : this(Color.Black, Color.White, width) { }

        public Circle(Color penColor, Color fillColor, float width = 1)
        {
            aMainPenColor = penColor;
            aMainPenWidth = width;
            aMainFillColor = fillColor;
            aPreShowPenWidth = width;
            mainBrush = new SolidBrush(mainFillColor);
            mainPen = new Pen(mainPenColor, mainPenWidth);
            aPreShowPenColor = Color.FromArgb(150, penColor);
            preShowPen = new Pen(preShowPenColor, preShowPenWidth);
            aPreShowFillColor = Color.FromArgb(150, fillColor);
            preShowBrush = new SolidBrush(preShowFillColor);
            showMode = TShowMode.MAIN_MODE;
        }

        //Отрисовка круга по данным из полей класса
        public override void Draw(Graphics g)
        {
            if (pointsNumber != 2)
                return;

            cirWidth = Math.Abs(p1.X - p0.X);
            cirHeight = Math.Abs(p1.Y - p0.Y);
            radius = (float)Math.Round(Math.Sqrt((double)cirWidth * cirWidth + cirHeight * cirHeight));

            if (showMode == TShowMode.MAIN_MODE)
            {
                mainPen.Color = mainPenColor;
                mainBrush.Color = mainFillColor;
                mainPen.Width = mainPenWidth;

                g.FillEllipse(mainBrush, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
                g.DrawEllipse(mainPen, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
            }
            else if (showMode == TShowMode.PRE_SHOW)
            {
                preShowPen.Color = Color.FromArgb(150, preShowPenColor);
                preShowBrush.Color = Color.FromArgb(150, preShowFillColor);
                preShowPen.Width = preShowPenWidth;

                g.FillEllipse(preShowBrush, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
                g.DrawEllipse(preShowPen, p0.X - radius, p0.Y - radius, radius * 2, radius * 2);
            }
        }

        //Установить очередную точку круга
        public override void SetPoint(Point point)
        {
            if (pointsNumber == 0)
            {
                p0 = point;
                point1 = point;
            }
            else
            {
                p1 = point;
                point2 = point;
            }

            if (pointsNumber < 2)
                pointsNumber++;
        }

        //Очистить информацию о точках круга
        public override void ClearPoints()
        {
            pointsNumber = 0;
            p0 = Point.Empty;
            p1 = Point.Empty;
            point1 = Point.Empty;
            point2 = Point.Empty;
            cirWidth = 0;
            cirHeight = 0;
        }

        public override void SetPoints()
        {
            p0 = point1;
            p1 = point2;
        }

        //Фигура не сложная
        public override bool isComplex()
        {
            return false;
        }

        //Метод для создания копии объекта фигуры
        public override Shape Clone()
        {
            return (Circle)this.MemberwiseClone();
        }
    }
}