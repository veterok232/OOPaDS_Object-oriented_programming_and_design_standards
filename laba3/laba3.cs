//Первая лабораторная работа по ООП
//В качестве средства рисования был выбран модуль System.Drawing
//Рисование происходит на Windows Forms

//Вторая лабораторная работа по ООП
//В данной лабораторной работе был написан абстрактный класс для фигур, а также отдельные классы для 
//разных типов фигур
//Также разработана начальная версия графического пользовательского интерфейса, который еще будет дорабатываться

//Третья лабораторная работа по ООП
//В данной лабораторной работе была реализована возможность рисования фигур с помощью мыши, а также реализован
//предпросмотр фигур при рисовании.


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
        private Graphics graphics;                       //
        private Dictionary<int, Bitmap> pictures;        //Словарь битмапов для разных вкладок
        private Dictionary<int, RadioButton> tabButtons; //Словарь кнопок для вкладок
        private int activeTab;                           //Номер текущей активной вкладки
        private int picturesCounter = 0;                 //Количество открытых вкладок

        //Текущая выбранная фигура
        enum eCurrentShape { shLine, shBrokenLine, shRectangle, shPolygon, shEllipse, shCircle };
        private eCurrentShape currentShape;

        private Dictionary<int, Shape> shapes;      //Словарь объектов фигур
        private Shape shapeInProgress = null;       //Объект текущей рисуемой фигуры
        private Shape preShowShape = null;          //Объект предпросмотра текущей рисуемой фигуры
        private int shapesNumber = 0;               //Количество нарисованных фигур
        private Bitmap preShowBuffer;               //Битмап для сохранения предыдущего состояния поля рисования
                                                    //для реализации предпросмотра

        //Конструктор формы
        public frmMain()
        {
            InitializeComponent();

            //Словарь для сохранения битмапов для разных вкладок
            pictures = new Dictionary<int, Bitmap>();

            //Создание битмапа для первой вкладки
            var currPicture = new Bitmap(cDrawField.Width, cDrawField.Height);
            picturesCounter++;
            cDrawField.Image = currPicture;
            pictures[picturesCounter] = currPicture;

            //Загрузка в Graphics Image из PictureBox
            graphics = Graphics.FromImage(cDrawField.Image);
            graphics.Clear(Color.White);

            //Словарь радио-кнопок для вкладок
            tabButtons = new Dictionary<int, RadioButton>();

            //Создание кнопки для первой вкладки
            var tab = new RadioButton();
            tabsPanel.Controls.Add(tab);
            tab.Appearance = Appearance.Button;
            tab.Checked = true;
            tab.Width = 150;
            tab.Height = 26;
            tab.Margin = new Padding(0, 1, 10, 1);
            tab.Name = "tabBtn" + picturesCounter;
            tab.Text = "New picture";

            tabButtons[picturesCounter] = tab;
            tab.Click += tabOnClick;
            activeTab = 1;

            //Настройка скролла для панели вкладок
            tabsPanel.VerticalScroll.Value = tabsPanel.Height;
            tabsPanel.VerticalScroll.SmallChange = tabsPanel.Height;

            toolPanelBtn_Line.Checked = true;

            shapes = new Dictionary<int, Shape>();
            currentShape = eCurrentShape.shLine;
        }

        //Создание новой картинки
        private void menuStripItemFile_Create_Click(object sender, EventArgs e)
        {
            //Корректировка размеров области рисования
            cDrawField.Width = cPanelDrawField.Width;
            cDrawField.Height = cPanelDrawField.Height;

            //Создание нового битмапа
            var currPicture = new Bitmap(cDrawField.Width, cDrawField.Height);

            //Сохранение в словарь созданного битмапа
            picturesCounter++;
            cDrawField.Image = currPicture;
            pictures[picturesCounter] = currPicture;

            //Загрузка в Graphics Image из PictureBox
            graphics = Graphics.FromImage(cDrawField.Image);
            graphics.Clear(Color.White);

            //Создание кнопки новой вкладки
            var tab = new RadioButton();
            tabsPanel.Controls.Add(tab);
            tab.Appearance = Appearance.Button;
            tab.Checked = true;
            tab.Width = 150;
            tab.Height = 26;
            tab.Margin = new Padding(0, 1, 10, 1);
            tab.Name = "tabBtn" + picturesCounter;
            tab.Text = "New picture";

            tabButtons[picturesCounter] = tab;
            tab.Click += tabOnClick;

            //Сброс фокуса
            btnResetTab.Focus();
        }

        //Событие клика по вкладке
        private void tabOnClick(object sender, EventArgs e)
        {
            if (sender is RadioButton tab)
            {
                int tabNumber = Int32.Parse(tab.Name.Remove(0, 6));
                Bitmap currPicture = pictures[tabNumber];
                cDrawField.Image = currPicture;
                graphics = Graphics.FromImage(cDrawField.Image);
                activeTab = tabNumber;
                tabButtons[tabNumber].Checked = true;
                cDrawField.Refresh();
            }
        }

        //Открытие картинки из файла
        private void menuStripItemFile_Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            // получаем выбранный файл
            string filename = openFileDialog.FileName;
            cDrawField.Image = Image.FromFile(filename);
           
            var currPicture = new Bitmap(Math.Max(cDrawField.Image.Width, cDrawField.Width), Math.Max(cDrawField.Image.Height, cDrawField.Height));
            picturesCounter++;
            currPicture = (Bitmap)cDrawField.Image;
            pictures[picturesCounter] = currPicture;

            graphics = Graphics.FromImage(cDrawField.Image);

            var tab = new RadioButton();
            tabsPanel.Controls.Add(tab);
            tab.Appearance = Appearance.Button;
            tab.Checked = true;
            tab.Width = 150;
            tab.Height = 26;
            tab.Margin = new Padding(0, 1, 10, 1);
            tab.Name = "tabBtn" + picturesCounter;
            tab.Text = filename;

            tabButtons[picturesCounter] = tab;
            tab.Click += tabOnClick;
            activeTab = picturesCounter;
            cDrawField.Refresh();

            //Сброс фокуса
            btnResetTab.Focus();
        }

        //---------------Пункт Файл в Главном меню-------------------------------

        //Сохранение картинки в файл
        private void menuStripItemFile_Save_Click(object sender, EventArgs e)
        {
            if (cDrawField.Image != null) //если в pictureBox есть изображение
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        cDrawField.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                        tabButtons[activeTab].Text = saveFileDialog.FileName;
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Сохранение как картинки в файл
        private void menuStripItemFile_SaveAs_Click(object sender, EventArgs e)
        {
            if (cDrawField.Image != null) //если в pictureBox есть изображение
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        cDrawField.Image.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                        tabButtons[activeTab].Text = saveFileDialog.FileName;
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Закрытие активной вкладки
        private void menuStripItemFile_ExitCurrent_Click(object sender, EventArgs e)
        {
            if (picturesCounter > 1)
            {
                pictures.Remove(activeTab);
                tabButtons[activeTab].Dispose();
                tabButtons.Remove(activeTab);
                picturesCounter--;

                var keys = new List<int>();
                foreach (var tab in tabButtons)
                {
                    if (tab.Key > activeTab)
                        keys.Add(tab.Key);
                }

                foreach (int key in keys)
                {
                    RadioButton tempButton = tabButtons[key];
                    tempButton.Name = "tabBtn" + (key - 1);
                    tabButtons.Remove(key);
                    tabButtons[key - 1] = tempButton;

                    Bitmap tempBitmap = pictures[key];
                    pictures.Remove(key);
                    pictures[key - 1] = tempBitmap;
                }

                tabOnClick(tabButtons[picturesCounter], EventArgs.Empty);
            }
            else
            { 
                MessageBox.Show("Осталась одна вкладка!");
            }
        }

        //Выход из программы
        private void menuStripItemFile_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //---------------Пункт Инструменты в Главном меню--------------------------------

        private void menuStripDrawing_Line_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Line.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = eCurrentShape.shLine;
        }

        private void menuStripDrawing_BrokenLine_Click(object sender, EventArgs e)
        {
            toolPanelBtn_BrokenLine.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = eCurrentShape.shBrokenLine;
        }

        private void menuStripDrawing_Rectangle_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Rectangle.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = eCurrentShape.shRectangle;
        }

        private void menuStripDrawing_Polygon_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Polygon.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = eCurrentShape.shPolygon;
        }

        private void menuStripDrawing_Ellipse_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Ellipse.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = eCurrentShape.shEllipse;
        }

        private void menuStripDrawing_Circle_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Circle.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = eCurrentShape.shCircle;
        }

        //---------------Кнопки на панели инструментов--------------------------------

        private void toolPanelBtn_Line_Click(object sender, EventArgs e)
        {
            currentShape = eCurrentShape.shLine;
            shapeInProgress = null;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_BrokenLine_Click(object sender, EventArgs e)
        {
            currentShape = eCurrentShape.shBrokenLine;
            shapeInProgress = null;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_Rectangle_Click(object sender, EventArgs e)
        {
            currentShape = eCurrentShape.shRectangle;
            shapeInProgress = null;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_Polygon_Click(object sender, EventArgs e)
        {
            currentShape = eCurrentShape.shPolygon;
            shapeInProgress = null;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_Ellipse_Click(object sender, EventArgs e)
        {
            currentShape = eCurrentShape.shEllipse;
            shapeInProgress = null;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_Circle_Click(object sender, EventArgs e)
        {
            currentShape = eCurrentShape.shCircle;
            shapeInProgress = null;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        //----------------------------------------------------------------------

        //Выбор цвета линии
        private void toolPanelBtn_LineColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_Line.ShowDialog() == DialogResult.Cancel)
                return;
        }

        //Выбор цвета заливки
        private void toolPanelBtn_FillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog_Fill.ShowDialog() == DialogResult.Cancel)
                return;
        }

        //-----------------------Начало рисования фигур------------------------
        private void startLineDraw(int x1, int y1)
        {
            var line = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            line.p1 = new Point(x1, y1);
            shapes.Add(shapesNumber, line);
            shapeInProgress = new Line();
            shapeInProgress = line;
        }

        private void startPreShowLineDraw(int x1, int y1)
        {
            var preShow = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShow.showMode = Shape.TShowMode.PRE_SHOW;
            preShow.p1 = new Point(x1, y1);
            preShowShape = preShow;
        }

        private void startBrokenLineDraw(int x1, int y1)
        {
            var brokenLine = new BrokenLine(colorDialog_Line.Color, (float)selectLineWidth.Value);
            Point cursorPosition = new Point(x1, y1);
            brokenLine.linePoints.Add(brokenLine.linePoints.Count, cursorPosition);
            shapes.Add(shapesNumber, brokenLine);
            shapeInProgress = new BrokenLine();
            shapeInProgress = brokenLine;
        }

        private void startPreShowBrokenLineDraw(int x1, int y1)
        {
            startPreShowLineDraw(x1, y1);
        }

        private void startRectangleDraw(int x0, int y0)
        {
            var rectangle = new Rectangle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            rectangle.p0 = new Point(x0, y0);
            shapes.Add(shapesNumber, rectangle);
            shapeInProgress = new Rectangle();
            shapeInProgress = rectangle;
        }

        private void startPreShowRectangleDraw(int x0, int y0)
        {
            var preShow = new Rectangle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            preShow.showMode = Shape.TShowMode.PRE_SHOW;
            preShow.p0 = new Point(x0, y0);
            preShowShape = preShow;
        }

        private void startPolygonDraw(int x1, int y1)
        {
            var polygon = new Polygon(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            Point cursorPosition = new Point(x1, y1);
            polygon.polygonPoints.Add(polygon.polygonPoints.Count, cursorPosition);
            shapes.Add(shapesNumber, polygon);
            shapeInProgress = new Polygon();
            shapeInProgress = polygon;
        }

        private void startPreShowPolygonDraw(int x1, int y1)
        {
            startPreShowLineDraw(x1, y1);
        }

        private void startEllipseDraw(int x0, int y0)
        {
            var ellipse = new Ellipse(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            ellipse.p0 = new Point(x0, y0);
            shapes.Add(shapesNumber, ellipse);
            shapeInProgress = new Ellipse();
            shapeInProgress = ellipse;
        }

        private void startPreShowEllipseDraw(int x0, int y0)
        {
            var preShow = new Ellipse(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            preShow.showMode = Shape.TShowMode.PRE_SHOW;
            preShow.p0 = new Point(x0, y0);
            preShowShape = preShow;
        }

        private void startCircleDraw(int x0, int y0)
        {
            var circle = new Circle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            circle.p0 = new Point(x0, y0);
            shapes.Add(shapesNumber, circle);
            shapeInProgress = new Circle();
            shapeInProgress = circle;
        }

        private void startPreShowCircleDraw(int x0, int y0)
        {
            var preShow = new Circle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            preShow.showMode = Shape.TShowMode.PRE_SHOW;
            preShow.p0 = new Point(x0, y0);
            preShowShape = preShow;
        }

        //Отмена рисования фигуры
        private void cancelDrawing()
        {
            preShowShape = null;
            shapeInProgress = null;
            shapes.Remove(shapesNumber);
        }

        //--------Продолжение или завершение рисования фигур---------
        private void continueLineDraw(int x2, int y2)
        {
            preShowShape = null;
            var line = (Line)shapes[shapesNumber];
            line.p2 = new Point(x2, y2);
            line.Draw(graphics);
            shapes[shapesNumber++] = line;
            shapeInProgress = null;
            preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
        }

        private void changeStartPreShowLineDraw(int x, int y)
        {
            var preShow = (Line)preShowShape;
            preShow.p1 = new Point(x, y);
            preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
        }

        private void continueBrokenLineDraw(int x, int y)
        {
            var brokenLine = (BrokenLine)shapes[shapesNumber];
            Point cursorPosition = new Point(x, y);
            brokenLine.linePoints.Add(brokenLine.linePoints.Count, cursorPosition);
            brokenLine.Draw(graphics);
        }

        private void finishBrokenLineDraw()
        {
            var brokenLine = (BrokenLine)shapes[shapesNumber];
            if (brokenLine.linePoints.Count < 2)
            {
                cancelDrawing();
                return;
            }

            shapesNumber++;
            shapeInProgress = null;
            preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
        }

        private void continueRectangleDraw(int x, int y)
        {
            var rectangle = (Rectangle)shapes[shapesNumber];
            int width = x - rectangle.p0.X;
            int height = y - rectangle.p0.Y;
            Point position = new Point(rectangle.p0.X, rectangle.p0.Y);

            if (width < 0)
                position.X = rectangle.p0.X + width;
            if (height < 0)
                position.Y = rectangle.p0.Y + height;

            rectangle.p0 = position;

            rectangle.recWidth = Math.Abs(width);
            rectangle.recHeight = Math.Abs(height);
            rectangle.Draw(graphics);
            shapes[shapesNumber++] = rectangle;
            shapeInProgress = null;
            preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
        }

        private void continuePolygonDraw(int x, int y)
        {
            var polygon = (Polygon)shapes[shapesNumber];
            Point cursorPosition = new Point(x, y);
            polygon.polygonPoints.Add(polygon.polygonPoints.Count, cursorPosition);
            polygon.Draw(graphics);
            preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
        }

        private void finishPolygonDraw()
        {
            var polygon = (Polygon)shapes[shapesNumber];

            if (polygon.polygonPoints.Count < 2)
            {
                cancelDrawing();
                return;
            }
                

            polygon.isFinish = true;
            polygon.Draw(graphics);
            shapesNumber++;
            shapeInProgress = null;
            preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
        }

        private void continueEllipseDraw(int x, int y)
        {
            var ellipse = (Ellipse)shapes[shapesNumber];
            ellipse.ellWidth = x - ellipse.p0.X;
            ellipse.ellHeight = y - ellipse.p0.Y;
            ellipse.Draw(graphics);
            shapes[shapesNumber++] = ellipse;
            shapeInProgress = null;
            preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
        }

        private void continueCircleDraw(int x, int y)
        {
            var circle = (Circle)shapes[shapesNumber];
            circle.cirWidth = Math.Abs(x - circle.p0.X);
            circle.cirHeight = Math.Abs(y - circle.p0.Y);
            circle.radius = (float)Math.Round(Math.Sqrt((double)circle.cirWidth * circle.cirWidth + circle.cirHeight * circle.cirHeight));
            circle.Draw(graphics);
            shapes[shapesNumber++] = circle;
            shapeInProgress = null;
            preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
        }

        private void cDrawField_MouseClick(object sender, MouseEventArgs e)
        {
            if (shapeInProgress == null)
            {
                preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);

                switch (currentShape)
                {
                    case eCurrentShape.shLine:
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                startLineDraw(e.X, e.Y);
                                startPreShowLineDraw(e.X, e.Y);
                            }
                                
                            break;
                        }
                    case eCurrentShape.shBrokenLine:
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                startBrokenLineDraw(e.X, e.Y);
                                startPreShowBrokenLineDraw(e.X, e.Y);
                            }
                            
                            break;
                        }
                    case eCurrentShape.shRectangle:
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                startRectangleDraw(e.X, e.Y);
                                startPreShowRectangleDraw(e.X, e.Y);
                            }
                                
                            break;
                        }
                    case eCurrentShape.shPolygon:
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                startPolygonDraw(e.X, e.Y);
                                startPreShowPolygonDraw(e.X, e.Y);
                            }

                            break;
                        }
                    case eCurrentShape.shEllipse:
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                startEllipseDraw(e.X, e.Y);
                                startPreShowEllipseDraw(e.X, e.Y);
                            }
                                
                            break;
                        }
                    case eCurrentShape.shCircle:
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                startCircleDraw(e.X, e.Y);
                                startPreShowCircleDraw(e.X, e.Y);
                            }

                            break;
                        }
                }
            }
            else
            {
                pictures[activeTab] = new Bitmap(preShowBuffer);
                cDrawField.Image = pictures[activeTab];
                graphics = Graphics.FromImage(cDrawField.Image);

                switch (currentShape)
                {
                    case eCurrentShape.shLine:
                        {
                            if (e.Button == MouseButtons.Left)
                                continueLineDraw(e.X, e.Y);
                            else if (e.Button == MouseButtons.Right)
                                cancelDrawing();
                                
                            break;
                        }
                    case eCurrentShape.shBrokenLine:
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                continueBrokenLineDraw(e.X, e.Y);
                                changeStartPreShowLineDraw(e.X, e.Y);
                            }
                            else if (e.Button == MouseButtons.Right)
                                finishBrokenLineDraw();

                            break;
                        }
                    case eCurrentShape.shRectangle:
                        {
                            if (e.Button == MouseButtons.Left)
                                continueRectangleDraw(e.X, e.Y);
                            else if (e.Button == MouseButtons.Right)
                                cancelDrawing();
                                
                            break;
                        }
                    case eCurrentShape.shPolygon:
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                continuePolygonDraw(e.X, e.Y);
                                changeStartPreShowLineDraw(e.X, e.Y);

                            }
                            else if (e.Button == MouseButtons.Right)
                                finishPolygonDraw();

                            break;
                        }
                    case eCurrentShape.shEllipse:
                        {
                            if (e.Button == MouseButtons.Left)
                                continueEllipseDraw(e.X, e.Y);
                            else if (e.Button == MouseButtons.Right)
                                cancelDrawing();

                            break;
                        }
                    case eCurrentShape.shCircle:
                        {
                            if (e.Button == MouseButtons.Left)
                                continueCircleDraw(e.X, e.Y);
                            else if (e.Button == MouseButtons.Right)
                                cancelDrawing();

                            break;
                        }
                }
            }

            cDrawField.Refresh();
        }

        private void continuePreShowLineDraw(int x, int y)
        {
            var preShow = (Line)preShowShape;
            preShow.showMode = Shape.TShowMode.PRE_SHOW;
            preShow.p2 = new Point(x, y);
            preShow.Draw(graphics);
        }

        private void continuePreShowBrokenLineDraw(int x, int y)
        {
            continuePreShowLineDraw(x, y);
        }

        private void continuePreShowRectangleDraw(int x, int y)
        {
            var preShow = (Rectangle)preShowShape;
            preShow.showMode = Shape.TShowMode.PRE_SHOW;

            int width = x - preShow.p0.X;
            int height = y - preShow.p0.Y;
            var position = new Point(preShow.p0.X, preShow.p0.Y);
            var oldPosition = new Point(position.X, position.Y);

            if (width < 0)
                position.X = preShow.p0.X + width;
            if (height < 0)
                position.Y = preShow.p0.Y + height;

            preShow.p0 = position;

            preShow.recWidth = Math.Abs(width);
            preShow.recHeight = Math.Abs(height);
            preShow.Draw(graphics);
            preShow.p0 = oldPosition;
        }

        private void continuePreShowPolygonDraw(int x, int y)
        {
            continuePreShowLineDraw(x, y);
        }

        private void continuePreShowEllipseDraw(int x, int y)
        {
            var preShow = (Ellipse)preShowShape;
            preShow.showMode = Shape.TShowMode.PRE_SHOW;
            preShow.ellWidth = x - preShow.p0.X;
            preShow.ellHeight = y - preShow.p0.Y;
            preShow.Draw(graphics);
        }

        private void continuePreShowCircleDraw(int x, int y)
        {
            var preShow = (Circle)preShowShape;
            preShow.showMode = Shape.TShowMode.PRE_SHOW;
            preShow.cirWidth = Math.Abs(x - preShow.p0.X);
            preShow.cirHeight = Math.Abs(y - preShow.p0.Y);
            preShow.radius = (float)Math.Round(Math.Sqrt((double)preShow.cirWidth * preShow.cirWidth + preShow.cirHeight * preShow.cirHeight));
            preShow.Draw(graphics);
        }

        private void cDrawField_MouseMove(object sender, MouseEventArgs e)
        {
            if (shapeInProgress != null)
            {
                pictures[activeTab] = new Bitmap(preShowBuffer);
                cDrawField.Image = pictures[activeTab];
                graphics = Graphics.FromImage(cDrawField.Image);

                switch (currentShape)
                {
                    case eCurrentShape.shLine:
                        {
                            continuePreShowLineDraw(e.X, e.Y);
                            break;
                        }
                    case eCurrentShape.shBrokenLine:
                        {
                            continuePreShowBrokenLineDraw(e.X, e.Y);
                            break;
                        }
                    case eCurrentShape.shRectangle:
                        {
                            continuePreShowRectangleDraw(e.X, e.Y);
                            break;
                        }
                    case eCurrentShape.shPolygon:
                        {
                            continuePreShowPolygonDraw(e.X, e.Y);
                            break;
                        }
                    case eCurrentShape.shEllipse:
                        {
                            continuePreShowEllipseDraw(e.X, e.Y);
                            break;
                        }
                    case eCurrentShape.shCircle:
                        {
                            continuePreShowCircleDraw(e.X, e.Y);
                            break;
                        }
                }
                cDrawField.Refresh();
            }
        }

        //Событие показа формы
        private void frmMain_Shown(object sender, EventArgs e)
        {
            cDrawField.Refresh();
        }
    }
}