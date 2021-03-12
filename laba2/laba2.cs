//Первая лабораторная работа по ООП
//В качестве средства рисования был выбран модуль System.Drawing
//Рисование происходит на Windows Forms

//Вторая лабораторная работа по ООП
//В данной лабораторной работе был написан абстрактный класс для фигур, а также отдельные классы для 
//разных типов фигур
//Также разработана начальная версия графического пользовательского интерфейса, который еще будет дорабатываться


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

            //------Реализация-------
        }

        private void menuStripDrawing_BrokenLine_Click(object sender, EventArgs e)
        {
            toolPanelBtn_BrokenLine.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            //------Реализация-------
        }

        private void menuStripDrawing_Rectangle_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Rectangle.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            //------Реализация-------
        }

        private void menuStripDrawing_Polygon_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Polygon.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            //------Реализация-------
        }

        private void menuStripDrawing_Ellipse_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Ellipse.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            //------Реализация-------
        }

        private void menuStripDrawing_Circle_Click(object sender, EventArgs e)
        {
            toolPanelBtn_Circle.Checked = true;

            //Сброс фокуса
            btnResetTab.Focus();

            //------Реализация-------
        }

        //---------------Кнопки на панели инструментов--------------------------------

        private void toolPanelBtn_Line_Click(object sender, EventArgs e)
        {
            //------Реализация-------
        }

        private void toolPanelBtn_BrokenLine_Click(object sender, EventArgs e)
        {
            //------Реализация-------
        }

        private void toolPanelBtn_Rectangle_Click(object sender, EventArgs e)
        {
            //------Реализация-------
        }

        private void toolPanelBtn_Polygon_Click(object sender, EventArgs e)
        {
            //------Реализация-------
        }

        private void toolPanelBtn_Ellipse_Click(object sender, EventArgs e)
        {
            //------Реализация-------
        }

        private void toolPanelBtn_Circle_Click(object sender, EventArgs e)
        {
            //------Реализация-------
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

        //---------------------------------------------------------------------

        //Нажатие на область рисования
        private void cDrawField_Click(object sender, EventArgs e)
        {
            frmMain_Shown(this, EventArgs.Empty);
        }

        //Событие показа формы
        private void frmMain_Shown(object sender, EventArgs e)
        {

            //Создание объекта Линия, цвет красный, толщина 3, и его отрисовка
            Line line = new Line(Color.Red, 3);
            line.Draw(graphics, 50, 50, 100, 100);

            //Создание объекта Ломаная, цвет лесной зеленый, толщина 4, и его отрисовка
            BrokenLine brokenLine = new BrokenLine(Color.ForestGreen, 4);
            //Массив точек ломаной
            Point[] brokenLine_points =
            {
                new Point(450, 50),
                new Point(490, 75),
                new Point(470, 100),
                new Point(510, 100)
            };
            //Отрисовка ломаной
            brokenLine.Draw(graphics, brokenLine_points);

            //Объект эллипс
            Ellipse ellipse = new Ellipse(Color.Green, Color.Blue, 10);
            ellipse.Draw(graphics, 150, 50, 50, 50);

            //Объект прямоугольник
            Rectangle rectangle = new Rectangle(Color.Black, Color.Red, 3);
            rectangle.Draw(graphics, 250, 50, 50, 50);

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
            Polygon polygon = new Polygon(Color.Magenta, Color.White, 3);
            polygon.Draw(graphics, polygon_points);

            //Объект окружность
            Circle circle = new Circle(Color.DarkTurquoise, Color.Crimson, 5);
            circle.Draw(graphics, 250, 300, 100);

            cDrawField.Refresh();
        }
    }
}