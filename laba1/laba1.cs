//Первая лабораторная работа по ООП
//В качестве средства рисования был выбран модуль System.Drawing
//Рисование происходит на Windows Forms

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace laba1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            //Привязываем переменную типа Graphics к компоненту Panel
            g = cDrawField.CreateGraphics();
        }
        //Объект класса Graphics
        Graphics g;
        
        //Событие показа формы
        private void frmMain_Shown(object sender, EventArgs e)
        {
            //Создание объекта Линия, цвет красный, толщина 3, и его отрисовка
            var line = new Line(Color.Red, 3);
            line.Draw(g, 50, 50, 100, 100);

            //Создание объекта Ломаная, цвет лесной зеленый, толщина 4, и его отрисовка
            var brokenLine = new BrokenLine(Color.ForestGreen, 4);
            //Массив точек ломаной
            Point[] brokenLine_points =
            {
                new Point(450, 50),
                new Point(490, 75),
                new Point(470, 100),
                new Point(510, 100)
            };
            //Отрисовка ломаной
            brokenLine.Draw(g, brokenLine_points);

            //Объект эллипс
            var ellipse = new Ellipse(Color.Green, Color.Blue, 10);
            ellipse.Draw(g, 150, 50, 50, 50);

            //Объект прямоугольник
            var rectangle = new Rectangle(Color.Black, Color.Red, 3);
            rectangle.Draw(g, 250, 50, 50, 50);

            //Массив вершин многоугольника
            Point[] polygon_points =
            {
                new Point(360, 50),
                new Point(390, 50),
                new Point(400, 75),
                new Point(390, 100),
                new Point(360, 100),
                new Point(350, 75)
            };

            //Объект многоугольник
            var polygon = new Polygon(Color.Magenta, Color.White, 3);
            polygon.Draw(g, polygon_points);

            //Объект окружность
            var circle = new Circle(Color.DarkTurquoise, Color.Crimson, 5);
            circle.Draw(g, 250, 300, 100);
        }
    }
}

//Класс линии
public class Line
{
    private Color aPenColor;    //Цвет линии
    private float aPenWidth;    //Толщина линии
    private Pen myPen;          //Объект пера

    //Конструктор класса линии
    public Line(float width = 2) : this(Color.Black, width) { }
    public Line(Color penColor, float width = 2)
    {
        aPenColor = penColor;
        aPenWidth = width;
        myPen = new Pen(aPenColor, aPenWidth);
    }

    //Метод отрисовки линии
    public void Draw(Graphics g, float x0, float y0, float x1, float y1)
    {
        g.DrawLine(myPen, x0, y0, x1, y1);
    }

    //Метод установки цвета линии
    public void SetPenColor(Color color)
    {
        aPenColor = color;
        myPen.Color = color;
    }

    //Метод установки толщины линии
    public void SetPenWidth(float width)
    {
        aPenWidth = width;
        myPen.Width = width;
    }
}

//Класс ломаной
public class BrokenLine
{
    private Color aPenColor;    //Цвет пера
    private float aPenWidth;    //Толщина пера
    private Pen myPen;          //Объект пера

    //Конструктор
    public BrokenLine(float width = 2) : this(Color.Black, width) { }
    public BrokenLine(Color color, float width = 2)
    {
        aPenColor = color;
        aPenWidth = width;
        myPen = new Pen(aPenColor, aPenWidth);
    }

    //Метод отрисовки ломаной по массиву точек
    public void Draw(Graphics g, Point[] points)
    {
        g.DrawLines(myPen, points);
    }

    //Установка цвета пера
    public void SetPenColor(Color color)
    {
        aPenColor = color;
        myPen.Color = color;
    }

    //Установка толщины пера
    public void SetPenWidth(float width)
    {
        aPenWidth = width;
        myPen.Width = width;
    }
}

//Класс эллипса
public class Ellipse
{
    private Color aPenColor;    //Цвет пера
    private Color aFillColor;   //Цвет заливки
    private float aPenWidth;    //Толщина пера
    private Pen myPen;          //Объект пера
    private SolidBrush myBrush; //Объект кисти

    //Конструктор
    public Ellipse(float width = 2) : this(Color.Black, Color.White, width) { }
    public Ellipse(Color penColor, Color fillColor, float width = 2)
    {
        aPenColor = penColor;
        aFillColor = fillColor;
        aPenWidth = width;
        myPen = new Pen(aPenColor, aPenWidth);
        myBrush = new SolidBrush(aFillColor);
    }

    //Метод отрисовки эллипса
    public void Draw(Graphics g, float x0, float y0, float width, float height)
    {
        g.FillEllipse(myBrush, x0, y0, width, height);
        g.DrawEllipse(myPen, x0, y0, width, height); 
    }

    public void SetPenColor(Color color)
    {
        aPenColor = color;
        myPen.Color = color;
    }

    public void SetPenWidth(float width)
    {
        aPenWidth = width;
        myPen.Width = width;
    }

    public void SetBrushColor(Color color)
    {
        aFillColor = color;
        myBrush.Color = color;
    }
}

//Класс окружности
public class Circle
{
    private Color aPenColor;    //Цвет пера
    private float aPenWidth;    //Толщина пера
    private Color aFillColor;   //Цвет заливки
    private Pen myPen;          //Объект пера
    private SolidBrush myBrush; //Объект кисти

    //Конструктор
    public Circle(float width = 2) : this(Color.Black, Color.White, width) { }
    public Circle(Color penColor, Color fillColor, float width = 2)
    {
        aPenColor = penColor;
        aPenWidth = width;
        aFillColor = fillColor;
        myPen = new Pen(aPenColor, aPenWidth);
        myBrush = new SolidBrush(aFillColor);
    }

    //Метод отрисовки окружности по точке центра и радиусу
    public void Draw(Graphics g, float x0, float y0, float radius)
    {
        g.FillEllipse(myBrush, x0 - radius, y0 - radius, radius * 2, radius * 2);
        g.DrawEllipse(myPen, x0 - radius, y0 - radius, radius * 2, radius * 2);
    }

    public void SetPenColor(Color color)
    {
        aPenColor = color;
        myPen.Color = color;
    }

    public void SetPenWidth(float width)
    {
        aPenWidth = width;
        myPen.Width = width;
    }

    public void SetBrushColor(Color color)
    {
        aFillColor = color;
        myBrush.Color = color;
    }
}

//Класс прямоугольника
public class Rectangle
{
    private Color aPenColor;    //Цвет пера
    private float aPenWidth;    //Толщина пера
    private Color aFillColor;   //Цвет заливки
    private Pen myPen;          //Объект пера
    private SolidBrush myBrush; //Объект кисти

    //Конструктор
    public Rectangle(float width = 2) : this(Color.Black, Color.White, width) { }
    public Rectangle(Color penColor, Color fillColor, float width = 2)
    {
        aPenColor = penColor;
        aPenWidth = width;
        aFillColor = fillColor;
        myPen = new Pen(aPenColor, aPenWidth);
        myBrush = new SolidBrush(aFillColor);
    }

    //Метод отрисовки прямоугольника по левой верхней точке и значениям ширины и высоты
    public void Draw(Graphics g, float x0, float y0, float width, float height)
    {
        g.FillRectangle(myBrush, x0, y0, width, height);
        g.DrawRectangle(myPen, x0, y0, width, height);
    }

    public void SetPenColor(Color color)
    {
        aPenColor = color;
        myPen.Color = color;
    }

    public void SetPenWidth(float width)
    {
        aPenWidth = width;
        myPen.Width = width;
    }

    public void SetBrushColor(Color color)
    {
        aFillColor = color;
        myBrush.Color = color;
    }
}

//Класс многоугольника
public class Polygon
{
    private Color aPenColor;    //Цвет пера
    private float aPenWidth;    //Толщина пера
    private Color aFillColor;   //Цвет заливки
    private Pen myPen;          //Объект пера
    private SolidBrush myBrush; //Объект кисти

    //Конструктор
    public Polygon(float width = 2) : this(Color.Black, Color.White, width) { }
    public Polygon(Color penColor, Color fillColor, float width = 2)
    {
        aPenColor = penColor;
        aPenWidth = width;
        aFillColor = fillColor;
        myPen = new Pen(aPenColor, aPenWidth);
        myBrush = new SolidBrush(aFillColor);
    }

    //Метод отрисовки многоугольника по массиву вершин
    public void Draw(Graphics g, Point[] points)
    {
        g.FillPolygon(myBrush, points);
        g.DrawPolygon(myPen, points);
    }

    public void SetPenColor(Color color)
    {
        aPenColor = color;
        myPen.Color = color;
    }

    public void SetPenWidth(float width)
    {
        aPenWidth = width;
        myPen.Width = width;
    }

    public void SetBrushColor(Color color)
    {
        aFillColor = color;
        myBrush.Color = color;
    }
}