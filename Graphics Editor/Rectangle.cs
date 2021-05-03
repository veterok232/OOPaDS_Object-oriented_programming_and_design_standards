//Класс "Прямоугольник"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Graphics_Editor
{
    public class Rectangle : Shape
    {
        private Point p0;           //Координаты верхнего левого угла
        private Point p1;           //Координаты нижнего правого угла
        private int recWidth;       //Ширина прямоугольника
        private int recHeight;      //Высота прямоугольника

        //Конструктор
        public Rectangle()
        {
            mainPen = new Pen(mainPenColor, mainPenWidth);
            mainBrush = new SolidBrush(mainFillColor);
            preShowPen = new Pen(preShowPenColor, preShowPenWidth);
            preShowBrush = new SolidBrush(preShowFillColor);
        }

        public Rectangle(float width = 1) : this(Color.Black, Color.White, width) { }

        public Rectangle(Color penColor, Color fillColor, float width = 1)
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

        //Отрисовка прямоугольника по данным из полей класса
        public override void Draw(Graphics g)
        {
            if (pointsNumber != 2)
                return;

            int recWidth0 = p1.X - p0.X;
            int recHeight0 = p1.Y - p0.Y;
            Point oldPosition = new Point(p0.X, p0.Y);

            if (recWidth0 < 0)
                p0.X = p0.X + recWidth0;
            if (recHeight0 < 0)
                p0.Y = p0.Y + recHeight0;

            recWidth = Math.Abs(recWidth0);
            recHeight = Math.Abs(recHeight0);

            if (showMode == TShowMode.MAIN_MODE)
            {
                mainPen.Color = mainPenColor;
                mainBrush.Color = mainFillColor;
                mainPen.Width = mainPenWidth;

                g.FillRectangle(mainBrush, p0.X, p0.Y, recWidth, recHeight);
                g.DrawRectangle(mainPen, p0.X, p0.Y, recWidth, recHeight);
            }
            else if (showMode == TShowMode.PRE_SHOW)
            {
                preShowPen.Color = Color.FromArgb(150, preShowPenColor);
                preShowBrush.Color = Color.FromArgb(150, preShowFillColor);
                preShowPen.Width = preShowPenWidth;

                g.FillRectangle(preShowBrush, p0.X, p0.Y, recWidth, recHeight);
                g.DrawRectangle(preShowPen, p0.X, p0.Y, recWidth, recHeight);
            }

            p0 = oldPosition;
        }

        //Установить очередную точку прямоугольника
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

        public override void SetPoints()
        {
            p0 = point1;
            p1 = point2;
        }

        //Очистить информацию о точках прямоугольника
        public override void ClearPoints()
        {
            pointsNumber = 0;
            p0 = Point.Empty;
            p1 = Point.Empty;
            point1 = Point.Empty;
            point2 = Point.Empty;
            recHeight = 0;
            recWidth = 0;
        }

        //Фигура не сложная
        public override bool isComplex()
        {
            return false;
        }

        //Метод для создания копии объекта фигуры
        public override Shape Clone()
        {
            return (Rectangle)this.MemberwiseClone();
        }
    }
}