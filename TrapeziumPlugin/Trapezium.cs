//Класс "Трапеция"
//Данный класс компилируется в .dll библиотеку

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Graphics_Editor;

namespace TrapeziumPlugin
{
    public class Trapezium : Shape
    {
        private Point p1;           //Координаты верхнего левого угла
        private Point p2;           //Координаты нижнего правого угла

        //Конструктор
        public Trapezium()
        {
            mainPen = new Pen(mainPenColor, mainPenWidth);
            mainBrush = new SolidBrush(mainFillColor);
            preShowPen = new Pen(preShowPenColor, preShowPenWidth);
            preShowBrush = new SolidBrush(preShowFillColor);
        }

        public Trapezium(float width = 1) : this(Color.Black, Color.White, width) { }

        public Trapezium(Color penColor, Color fillColor, float width = 1)
        {
            aMainPenColor = penColor;
            aMainPenWidth = width;
            aMainFillColor = fillColor;
            aPreShowPenWidth = width;
            aPreShowPenColor = Color.FromArgb(150, penColor);
            aPreShowFillColor = Color.FromArgb(150, fillColor);

            mainBrush = new SolidBrush(mainFillColor);
            mainPen = new Pen(mainPenColor, mainPenWidth);
            preShowPen = new Pen(preShowPenColor, preShowPenWidth);
            preShowBrush = new SolidBrush(preShowFillColor);
            showMode = TShowMode.MAIN_MODE;
        }

        //Отрисовка трапеции по данным из полей класса
        public override void Draw(Graphics g)
        {
            if (pointsNumber != 2)
                return;

            // Массив точек
            var trapezium_points = new Point[] { new Point(p1.X + (p2.X - p1.X) / 4, p1.Y),
                                           new Point(p2.X - (p2.X - p1.X) / 4, p1.Y),
                                           p2,
                                           new Point(p1.X, p2.Y) };

            if (showMode == TShowMode.MAIN_MODE)
            {
                mainPen.Color = mainPenColor;
                mainBrush.Color = mainFillColor;
                mainPen.Width = mainPenWidth;

                g.FillPolygon(mainBrush, trapezium_points);
                g.DrawPolygon(mainPen, trapezium_points);
            }
            else if (showMode == TShowMode.PRE_SHOW)
            {
                preShowPen.Color = Color.FromArgb(150, preShowPenColor);
                preShowBrush.Color = Color.FromArgb(150, preShowFillColor);
                preShowPen.Width = preShowPenWidth;

                g.FillPolygon(preShowBrush, trapezium_points);
                g.DrawPolygon(preShowPen, trapezium_points);
            }
        }

        //Установить очередную точку трапеции
        public override void SetPoint(Point point)
        {
            if (pointsNumber == 0)
            {
                p1 = point;
                point1 = point;
            }
            else
            {
                p2 = point;
                point2 = point;
            }

            if (pointsNumber < 2)
                pointsNumber++;
        }

        public override void SetPoints()
        {
            p1 = point1;
            p2 = point2;
        }

        //Очистить информацию о точках трапеции
        public override void ClearPoints()
        {
            pointsNumber = 0;
            p1 = Point.Empty;
            p2 = Point.Empty;
            point1 = Point.Empty;
            point2 = Point.Empty;
        }

        //Фигура не сложная
        public override bool isComplex()
        {
            return false;
        }

        //Метод для создания копии объекта фигуры
        public override Shape Clone()
        {
            return (Trapezium)this.MemberwiseClone();
        }
    }
}
