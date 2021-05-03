//Класс "Ломаная"

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Graphics_Editor
{
    public class BrokenLine : Shape
    {
        private Dictionary<int, Point> linePoints;  //Словарь точек ломаной

        //Конструктор
        public BrokenLine()
        {
            mainPen = new Pen(mainPenColor, mainPenWidth);
            preShowPen = new Pen(preShowPenColor, preShowPenWidth);
        }

        public BrokenLine(float width = 1) : this(Color.Black, width) { }
        public BrokenLine(Color penColor, float width = 1)
        {
            aMainPenColor = penColor;
            aMainPenWidth = width;
            aPreShowPenWidth = width;
            mainPen = new Pen(mainPenColor, mainPenWidth);
            aPreShowPenColor = Color.FromArgb(150, penColor);
            preShowPen = new Pen(preShowPenColor, preShowPenWidth);
            showMode = TShowMode.MAIN_MODE;
            linePoints = new Dictionary<int, Point>();
        }

        //Отрисовка ломаной по данным из полей класса
        public override void Draw(Graphics g)
        {
            if (pointsNumber < 2)
                return;

            mainPen.Color = mainPenColor;
            mainPen.Width = mainPenWidth;

            Point[] points = new Point[pointsNumber];
            linePoints.Values.CopyTo(points, 0);
            g.DrawLines(mainPen, points);
        }

        //Установить очередную точку ломаной
        public override void SetPoint(Point point)
        {
            linePoints[++pointsNumber] = point;

            shapePoints = new Point[pointsNumber];
            linePoints.Values.CopyTo(shapePoints, 0);
        }

        public override void SetPoints()
        {
            linePoints = new Dictionary<int, Point>();
            int count = 0;

            foreach (var point in shapePoints)
            {
                linePoints[++count] = point;
            }
        }

        //Очистить информацию о точках ломаной
        public override void ClearPoints()
        {
            pointsNumber = 0;
            linePoints.Clear();
            shapePoints = null;
        }

        //Фигура сложная
        public override bool isComplex()
        {
            return true;
        }

        //Метод для создания копии объекта фигуры
        public override Shape Clone()
        {
            var cloneLinePoints = new Dictionary<int, Point>(linePoints);
            var newShape = (BrokenLine)this.MemberwiseClone();
            newShape.linePoints = cloneLinePoints;
            return newShape;
        }
    }
}