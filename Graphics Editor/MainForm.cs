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
        private Graphics graphics;                       
        private Dictionary<int, Bitmap> pictures;        //Словарь битмапов для разных вкладок
        private Dictionary<int, RadioButton> tabButtons; //Словарь кнопок для вкладок
        private int activeTab;                           //Номер текущей активной вкладки
        private int picturesCounter = 0;                 //Количество открытых вкладок

        private Shape currentShape;                 //Объект текущей рисуемой фигуры
        private bool shapeInProgress = false;       //Флаг, рисуется ли текущая фигура

        private Dictionary<int, Shape> shapes;      //Словарь объектов фигур
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
            currentShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            shapeInProgress = false;
            preShowShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;
            preShowBuffer = new Bitmap(cDrawField.Image);
        }

        //Отмена рисования текущей фигуры
        private void cancelDrawing()
        {
            pictures[activeTab] = new Bitmap(preShowBuffer);
            cDrawField.Image = pictures[activeTab];
            graphics = Graphics.FromImage(cDrawField.Image);

            currentShape.ClearPoints();
            preShowShape.ClearPoints();
            shapeInProgress = false;
        }

        //Создание новой картинки
        private void menuStripItemFile_Create_Click(object sender, EventArgs e)
        {
            //Сохранение текущего поля рисования
            cancelDrawing();
            pictures[activeTab] = new Bitmap((Bitmap)cDrawField.Image);

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
            activeTab = picturesCounter;

            preShowBuffer = new Bitmap(cDrawField.Image);
            //Сброс фокуса
            btnResetTab.Focus();
        }

        //Событие клика по вкладке
        private void tabOnClick(object sender, EventArgs e)
        {
            if (sender is RadioButton tab)
            {
                cancelDrawing();
                pictures[activeTab] = new Bitmap(cDrawField.Image);
                int tabNumber = Int32.Parse(tab.Name.Remove(0, 6));
                Bitmap currPicture = pictures[tabNumber];
                cDrawField.Image = currPicture;
                graphics = Graphics.FromImage(cDrawField.Image);
                activeTab = tabNumber;
                tabButtons[tabNumber].Checked = true;

                preShowBuffer = new Bitmap(cDrawField.Image);
                cDrawField.Refresh();
            }
        }

        //Открытие картинки из файла
        private void menuStripItemFile_Open_Click(object sender, EventArgs e)
        {
            cancelDrawing();

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
            cancelDrawing();

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
            cancelDrawing();

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
            cancelDrawing();

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

            currentShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            shapeInProgress = false;
            preShowShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void menuStripDrawing_BrokenLine_Click(object sender, EventArgs e)
        {
            toolPanelBtn_BrokenLine.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = new BrokenLine(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShowShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;
            shapeInProgress = false;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void menuStripDrawing_Rectangle_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Rectangle.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = new Rectangle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            shapeInProgress = false;
            preShowShape = new Rectangle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void menuStripDrawing_Polygon_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Polygon.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = new Polygon(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value); ;
            preShowShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;
            shapeInProgress = false;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            };
        }

        private void menuStripDrawing_Ellipse_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Ellipse.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = new Ellipse(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value); ;
            shapeInProgress = false;
            preShowShape = new Ellipse(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void menuStripDrawing_Circle_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Circle.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            currentShape = new Circle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value); ;
            shapeInProgress = false;
            preShowShape = new Circle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        //---------------Кнопки на панели инструментов--------------------------------

        private void toolPanelBtn_Line_Click(object sender, EventArgs e)
        {
            currentShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            shapeInProgress = false;
            preShowShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_BrokenLine_Click(object sender, EventArgs e)
        {
            currentShape = new BrokenLine(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShowShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;
            shapeInProgress = false;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_Rectangle_Click(object sender, EventArgs e)
        {
            currentShape = new Rectangle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            shapeInProgress = false;
            preShowShape = new Rectangle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_Polygon_Click(object sender, EventArgs e)
        {
            currentShape = new Polygon(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value); ;
            preShowShape = new Line(colorDialog_Line.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;
            shapeInProgress = false;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_Ellipse_Click(object sender, EventArgs e)
        {
            currentShape = new Ellipse(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value); ;
            shapeInProgress = false;
            preShowShape = new Ellipse(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;

            if (shapes.ContainsKey(shapesNumber))
            {
                shapes.Remove(shapesNumber);
            }
        }

        private void toolPanelBtn_Circle_Click(object sender, EventArgs e)
        {
            currentShape = new Circle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value); ;
            shapeInProgress = false;
            preShowShape = new Circle(colorDialog_Line.Color, colorDialog_Fill.Color, (float)selectLineWidth.Value);
            preShowShape.showMode = Shape.TShowMode.PRE_SHOW;

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

        private void cDrawField_MouseClick(object sender, MouseEventArgs e)
        {
            //Если фигура еще не в процессе рисования
            if (!shapeInProgress)
            {
                //Сохраняем текущее состояние поля рисования
                preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);

                //По нажатию ЛКМ модифицируем положение фигуры
                if (e.Button == MouseButtons.Left)
                {
                    currentShape.aMainPenColor = colorDialog_Line.Color;
                    currentShape.aMainFillColor = colorDialog_Fill.Color;
                    currentShape.aMainPenWidth = (float)selectLineWidth.Value;
                    currentShape.SetPoint(e.Location);
                    currentShape.isFinish = false;
                    shapeInProgress = true;

                    preShowShape.aPreShowPenColor = colorDialog_Line.Color;
                    preShowShape.aPreShowFillColor = colorDialog_Fill.Color;
                    preShowShape.aPreShowPenWidth = (float)selectLineWidth.Value;
                    preShowShape.SetPoint(e.Location);
                    preShowShape.isFinish = false;
                }
            }
            else
            {
                //Убираем предпросмотр
                pictures[activeTab] = new Bitmap(preShowBuffer);
                cDrawField.Image = pictures[activeTab];
                graphics = Graphics.FromImage(cDrawField.Image);

                //Если нажата ЛКМ
                if (e.Button == MouseButtons.Left)
                {
                    //Если фигура сложная, то продолжаем рисование
                    if (currentShape.isComplex())
                    {
                        currentShape.SetPoint(e.Location);
                        currentShape.Draw(graphics);
                        preShowShape.ClearPoints();
                        preShowShape.SetPoint(e.Location);
                        preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
                    }
                    //иначе, заканчиваем рисование фигуры
                    else
                    {
                        preShowShape.ClearPoints();
                        currentShape.SetPoint(e.Location);
                        currentShape.isFinish = true;
                        currentShape.Draw(graphics);
                        shapes[shapesNumber++] = currentShape;
                        currentShape.ClearPoints();
                        shapeInProgress = false;
                        preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
                    }
                }
                //Если нажата ПКМ
                else if (e.Button == MouseButtons.Right)
                {
                    //Если фигура сложная, то завершаем ее рисование
                    if (currentShape.isComplex())
                    {
                        if (currentShape.PointsNumber < 2)
                        {
                            currentShape.ClearPoints();
                            preShowShape.ClearPoints();
                            shapeInProgress = false;
                        }
                        else
                        {
                            currentShape.isFinish = true;
                            currentShape.Draw(graphics);
                            shapes[shapesNumber++] = currentShape;
                            preShowShape.ClearPoints();
                            currentShape.ClearPoints();
                            shapeInProgress = false;
                            preShowBuffer = new Bitmap((Bitmap)cDrawField.Image);
                        }
                    }
                    //Иначе, отменяем рисование фигуры
                    else
                    {
                        currentShape.ClearPoints();
                        preShowShape.ClearPoints();
                        shapeInProgress = false;
                    }
                }
            }

            cDrawField.Refresh();
        }

        //При движении мыши
        private void cDrawField_MouseMove(object sender, MouseEventArgs e)
        {
            //Если фигура в процессе рисования, то рисуем предпросмотр
            if (shapeInProgress)
            {
                pictures[activeTab] = new Bitmap(preShowBuffer);
                cDrawField.Image = pictures[activeTab];
                graphics = Graphics.FromImage(cDrawField.Image);

                preShowShape.SetPoint(e.Location);
                preShowShape.Draw(graphics);
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