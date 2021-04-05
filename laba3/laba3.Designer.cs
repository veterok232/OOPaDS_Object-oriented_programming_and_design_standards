namespace laba1
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuStripItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemFile_Create = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemFile_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripItemFile_ExitCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItem_Drawing = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDrawing_Line = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDrawing_BrokenLine = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDrawing_Rectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDrawing_Polygon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDrawing_Ellipse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripDrawing_Circle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSytripItem_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripTools_LineWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripTools_LineColor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripTools_FillColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripTools_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripTools_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSytripItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.selectLineWidth = new System.Windows.Forms.NumericUpDown();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolPanelBtn_Line = new System.Windows.Forms.RadioButton();
            this.toolPanelBtn_BrokenLine = new System.Windows.Forms.RadioButton();
            this.toolPanelBtn_Rectangle = new System.Windows.Forms.RadioButton();
            this.toolPanelBtn_Polygon = new System.Windows.Forms.RadioButton();
            this.toolPanelBtn_Ellipse = new System.Windows.Forms.RadioButton();
            this.toolPanelBtn_Circle = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolPanelBtn_LineColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolPanelBtn_FillColor = new System.Windows.Forms.Button();
            this.tabsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog_Line = new System.Windows.Forms.ColorDialog();
            this.colorDialog_Fill = new System.Windows.Forms.ColorDialog();
            this.cDrawField = new System.Windows.Forms.PictureBox();
            this.btnResetTab = new System.Windows.Forms.Button();
            this.cPanelDrawField = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectLineWidth)).BeginInit();
            this.toolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cDrawField)).BeginInit();
            this.cPanelDrawField.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItem_File,
            this.menuStripItem_Drawing,
            this.menuSytripItem_Tools,
            this.menuSytripItem_About});
            this.menuStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.ShowItemToolTips = true;
            this.menuStripMain.Size = new System.Drawing.Size(1342, 28);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "Главное меню";
            // 
            // menuStripItem_File
            // 
            this.menuStripItem_File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuStripItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItemFile_Create,
            this.menuStripItemFile_Open,
            this.menuStripItemFile_Save,
            this.menuStripItemFile_SaveAs,
            this.toolStripSeparator2,
            this.menuStripItemFile_ExitCurrent,
            this.menuStripItemFile_Exit});
            this.menuStripItem_File.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripItem_File.Name = "menuStripItem_File";
            this.menuStripItem_File.Size = new System.Drawing.Size(59, 24);
            this.menuStripItem_File.Text = "Файл";
            // 
            // menuStripItemFile_Create
            // 
            this.menuStripItemFile_Create.Image = ((System.Drawing.Image)(resources.GetObject("menuStripItemFile_Create.Image")));
            this.menuStripItemFile_Create.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripItemFile_Create.Name = "menuStripItemFile_Create";
            this.menuStripItemFile_Create.Size = new System.Drawing.Size(211, 26);
            this.menuStripItemFile_Create.Text = "Создать";
            this.menuStripItemFile_Create.Click += new System.EventHandler(this.menuStripItemFile_Create_Click);
            // 
            // menuStripItemFile_Open
            // 
            this.menuStripItemFile_Open.Image = ((System.Drawing.Image)(resources.GetObject("menuStripItemFile_Open.Image")));
            this.menuStripItemFile_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripItemFile_Open.Name = "menuStripItemFile_Open";
            this.menuStripItemFile_Open.Size = new System.Drawing.Size(211, 26);
            this.menuStripItemFile_Open.Text = "Открыть";
            this.menuStripItemFile_Open.Click += new System.EventHandler(this.menuStripItemFile_Open_Click);
            // 
            // menuStripItemFile_Save
            // 
            this.menuStripItemFile_Save.Image = ((System.Drawing.Image)(resources.GetObject("menuStripItemFile_Save.Image")));
            this.menuStripItemFile_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripItemFile_Save.Name = "menuStripItemFile_Save";
            this.menuStripItemFile_Save.Size = new System.Drawing.Size(211, 26);
            this.menuStripItemFile_Save.Text = "Сохранить";
            this.menuStripItemFile_Save.Click += new System.EventHandler(this.menuStripItemFile_Save_Click);
            // 
            // menuStripItemFile_SaveAs
            // 
            this.menuStripItemFile_SaveAs.Image = ((System.Drawing.Image)(resources.GetObject("menuStripItemFile_SaveAs.Image")));
            this.menuStripItemFile_SaveAs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripItemFile_SaveAs.Name = "menuStripItemFile_SaveAs";
            this.menuStripItemFile_SaveAs.Size = new System.Drawing.Size(211, 26);
            this.menuStripItemFile_SaveAs.Text = "Сохранить как";
            this.menuStripItemFile_SaveAs.Click += new System.EventHandler(this.menuStripItemFile_SaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // menuStripItemFile_ExitCurrent
            // 
            this.menuStripItemFile_ExitCurrent.Name = "menuStripItemFile_ExitCurrent";
            this.menuStripItemFile_ExitCurrent.Size = new System.Drawing.Size(211, 26);
            this.menuStripItemFile_ExitCurrent.Text = "Закрыть текущий";
            this.menuStripItemFile_ExitCurrent.Click += new System.EventHandler(this.menuStripItemFile_ExitCurrent_Click);
            // 
            // menuStripItemFile_Exit
            // 
            this.menuStripItemFile_Exit.Image = ((System.Drawing.Image)(resources.GetObject("menuStripItemFile_Exit.Image")));
            this.menuStripItemFile_Exit.Name = "menuStripItemFile_Exit";
            this.menuStripItemFile_Exit.Size = new System.Drawing.Size(211, 26);
            this.menuStripItemFile_Exit.Text = "Выход";
            this.menuStripItemFile_Exit.Click += new System.EventHandler(this.menuStripItemFile_Exit_Click);
            // 
            // menuStripItem_Drawing
            // 
            this.menuStripItem_Drawing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuStripItem_Drawing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripDrawing_Line,
            this.menuStripDrawing_BrokenLine,
            this.menuStripDrawing_Rectangle,
            this.menuStripDrawing_Polygon,
            this.menuStripDrawing_Ellipse,
            this.menuStripDrawing_Circle});
            this.menuStripItem_Drawing.Name = "menuStripItem_Drawing";
            this.menuStripItem_Drawing.Size = new System.Drawing.Size(98, 24);
            this.menuStripItem_Drawing.Text = "Рисование";
            // 
            // menuStripDrawing_Line
            // 
            this.menuStripDrawing_Line.Image = ((System.Drawing.Image)(resources.GetObject("menuStripDrawing_Line.Image")));
            this.menuStripDrawing_Line.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripDrawing_Line.Name = "menuStripDrawing_Line";
            this.menuStripDrawing_Line.Size = new System.Drawing.Size(203, 26);
            this.menuStripDrawing_Line.Text = "Отрезок";
            this.menuStripDrawing_Line.Click += new System.EventHandler(this.menuStripDrawing_Line_Click);
            // 
            // menuStripDrawing_BrokenLine
            // 
            this.menuStripDrawing_BrokenLine.Image = ((System.Drawing.Image)(resources.GetObject("menuStripDrawing_BrokenLine.Image")));
            this.menuStripDrawing_BrokenLine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripDrawing_BrokenLine.Name = "menuStripDrawing_BrokenLine";
            this.menuStripDrawing_BrokenLine.Size = new System.Drawing.Size(203, 26);
            this.menuStripDrawing_BrokenLine.Text = "Ломаная";
            this.menuStripDrawing_BrokenLine.Click += new System.EventHandler(this.menuStripDrawing_BrokenLine_Click);
            // 
            // menuStripDrawing_Rectangle
            // 
            this.menuStripDrawing_Rectangle.Image = ((System.Drawing.Image)(resources.GetObject("menuStripDrawing_Rectangle.Image")));
            this.menuStripDrawing_Rectangle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripDrawing_Rectangle.Name = "menuStripDrawing_Rectangle";
            this.menuStripDrawing_Rectangle.Size = new System.Drawing.Size(203, 26);
            this.menuStripDrawing_Rectangle.Text = "Прямоугольник";
            this.menuStripDrawing_Rectangle.Click += new System.EventHandler(this.menuStripDrawing_Rectangle_Click);
            // 
            // menuStripDrawing_Polygon
            // 
            this.menuStripDrawing_Polygon.Image = ((System.Drawing.Image)(resources.GetObject("menuStripDrawing_Polygon.Image")));
            this.menuStripDrawing_Polygon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripDrawing_Polygon.Name = "menuStripDrawing_Polygon";
            this.menuStripDrawing_Polygon.Size = new System.Drawing.Size(203, 26);
            this.menuStripDrawing_Polygon.Text = "Многоугольник";
            this.menuStripDrawing_Polygon.Click += new System.EventHandler(this.menuStripDrawing_Polygon_Click);
            // 
            // menuStripDrawing_Ellipse
            // 
            this.menuStripDrawing_Ellipse.Image = ((System.Drawing.Image)(resources.GetObject("menuStripDrawing_Ellipse.Image")));
            this.menuStripDrawing_Ellipse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripDrawing_Ellipse.Name = "menuStripDrawing_Ellipse";
            this.menuStripDrawing_Ellipse.Size = new System.Drawing.Size(203, 26);
            this.menuStripDrawing_Ellipse.Text = "Эллипс";
            this.menuStripDrawing_Ellipse.Click += new System.EventHandler(this.menuStripDrawing_Ellipse_Click);
            // 
            // menuStripDrawing_Circle
            // 
            this.menuStripDrawing_Circle.Image = ((System.Drawing.Image)(resources.GetObject("menuStripDrawing_Circle.Image")));
            this.menuStripDrawing_Circle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripDrawing_Circle.Name = "menuStripDrawing_Circle";
            this.menuStripDrawing_Circle.Size = new System.Drawing.Size(203, 26);
            this.menuStripDrawing_Circle.Text = "Окружность";
            this.menuStripDrawing_Circle.Click += new System.EventHandler(this.menuStripDrawing_Circle_Click);
            // 
            // menuSytripItem_Tools
            // 
            this.menuSytripItem_Tools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuSytripItem_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripTools_LineWidth,
            this.menuStripTools_LineColor,
            this.menuStripTools_FillColor,
            this.toolStripSeparator1,
            this.menuStripTools_Undo,
            this.menuStripTools_Redo});
            this.menuSytripItem_Tools.Name = "menuSytripItem_Tools";
            this.menuSytripItem_Tools.Size = new System.Drawing.Size(117, 24);
            this.menuSytripItem_Tools.Text = "Инструменты";
            // 
            // menuStripTools_LineWidth
            // 
            this.menuStripTools_LineWidth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripTools_LineWidth.Name = "menuStripTools_LineWidth";
            this.menuStripTools_LineWidth.Size = new System.Drawing.Size(203, 26);
            this.menuStripTools_LineWidth.Text = "Толщина линии";
            // 
            // menuStripTools_LineColor
            // 
            this.menuStripTools_LineColor.Image = ((System.Drawing.Image)(resources.GetObject("menuStripTools_LineColor.Image")));
            this.menuStripTools_LineColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripTools_LineColor.Name = "menuStripTools_LineColor";
            this.menuStripTools_LineColor.Size = new System.Drawing.Size(203, 26);
            this.menuStripTools_LineColor.Text = "Цвет линии";
            // 
            // menuStripTools_FillColor
            // 
            this.menuStripTools_FillColor.Image = ((System.Drawing.Image)(resources.GetObject("menuStripTools_FillColor.Image")));
            this.menuStripTools_FillColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuStripTools_FillColor.Name = "menuStripTools_FillColor";
            this.menuStripTools_FillColor.Size = new System.Drawing.Size(203, 26);
            this.menuStripTools_FillColor.Text = "Цвет заливки";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // menuStripTools_Undo
            // 
            this.menuStripTools_Undo.Image = ((System.Drawing.Image)(resources.GetObject("menuStripTools_Undo.Image")));
            this.menuStripTools_Undo.Name = "menuStripTools_Undo";
            this.menuStripTools_Undo.Size = new System.Drawing.Size(203, 26);
            this.menuStripTools_Undo.Text = "Undo";
            // 
            // menuStripTools_Redo
            // 
            this.menuStripTools_Redo.Image = ((System.Drawing.Image)(resources.GetObject("menuStripTools_Redo.Image")));
            this.menuStripTools_Redo.Name = "menuStripTools_Redo";
            this.menuStripTools_Redo.Size = new System.Drawing.Size(203, 26);
            this.menuStripTools_Redo.Text = "Redo";
            // 
            // menuSytripItem_About
            // 
            this.menuSytripItem_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuSytripItem_About.Name = "menuSytripItem_About";
            this.menuSytripItem_About.Size = new System.Drawing.Size(118, 24);
            this.menuSytripItem_About.Text = "О программе";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 26);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 26);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(225, 26);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(32, 19);
            this.toolStripMenuItem4.Text = "toolStripMenuItem4";
            // 
            // selectLineWidth
            // 
            this.selectLineWidth.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectLineWidth.Location = new System.Drawing.Point(433, 10);
            this.selectLineWidth.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.selectLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selectLineWidth.Name = "selectLineWidth";
            this.selectLineWidth.Size = new System.Drawing.Size(80, 30);
            this.selectLineWidth.TabIndex = 3;
            this.selectLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "imgonline-com-ua-Transparent-backgr-DK0KNEzhiEgqMkI.png");
            this.imageList1.Images.SetKeyName(1, "imgonline-com-ua-Transparent-backgr-lJggdOZDOe9hherY.png");
            this.imageList1.Images.SetKeyName(2, "pixlr-bg-result (6).png");
            this.imageList1.Images.SetKeyName(3, "pixlr-bg-result (1).png");
            this.imageList1.Images.SetKeyName(4, "pixlr-bg-result (7).png");
            this.imageList1.Images.SetKeyName(5, "pixlr-bg-result (5).png");
            this.imageList1.Images.SetKeyName(6, "colorscm_8928.png");
            // 
            // toolPanel
            // 
            this.toolPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolPanel.Controls.Add(this.toolPanelBtn_Line);
            this.toolPanel.Controls.Add(this.toolPanelBtn_BrokenLine);
            this.toolPanel.Controls.Add(this.toolPanelBtn_Rectangle);
            this.toolPanel.Controls.Add(this.toolPanelBtn_Polygon);
            this.toolPanel.Controls.Add(this.toolPanelBtn_Ellipse);
            this.toolPanel.Controls.Add(this.toolPanelBtn_Circle);
            this.toolPanel.Controls.Add(this.label1);
            this.toolPanel.Controls.Add(this.selectLineWidth);
            this.toolPanel.Controls.Add(this.label2);
            this.toolPanel.Controls.Add(this.toolPanelBtn_LineColor);
            this.toolPanel.Controls.Add(this.label3);
            this.toolPanel.Controls.Add(this.toolPanelBtn_FillColor);
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolPanel.Location = new System.Drawing.Point(0, 28);
            this.toolPanel.Margin = new System.Windows.Forms.Padding(0);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolPanel.Size = new System.Drawing.Size(1342, 50);
            this.toolPanel.TabIndex = 5;
            // 
            // toolPanelBtn_Line
            // 
            this.toolPanelBtn_Line.Appearance = System.Windows.Forms.Appearance.Button;
            this.toolPanelBtn_Line.ImageIndex = 0;
            this.toolPanelBtn_Line.ImageList = this.imageList1;
            this.toolPanelBtn_Line.Location = new System.Drawing.Point(10, 7);
            this.toolPanelBtn_Line.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.toolPanelBtn_Line.Name = "toolPanelBtn_Line";
            this.toolPanelBtn_Line.Size = new System.Drawing.Size(36, 36);
            this.toolPanelBtn_Line.TabIndex = 16;
            this.toolPanelBtn_Line.TabStop = true;
            this.toolPanelBtn_Line.UseVisualStyleBackColor = true;
            this.toolPanelBtn_Line.Click += new System.EventHandler(this.toolPanelBtn_Line_Click);
            // 
            // toolPanelBtn_BrokenLine
            // 
            this.toolPanelBtn_BrokenLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.toolPanelBtn_BrokenLine.ImageIndex = 1;
            this.toolPanelBtn_BrokenLine.ImageList = this.imageList1;
            this.toolPanelBtn_BrokenLine.Location = new System.Drawing.Point(52, 7);
            this.toolPanelBtn_BrokenLine.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.toolPanelBtn_BrokenLine.Name = "toolPanelBtn_BrokenLine";
            this.toolPanelBtn_BrokenLine.Size = new System.Drawing.Size(36, 36);
            this.toolPanelBtn_BrokenLine.TabIndex = 11;
            this.toolPanelBtn_BrokenLine.TabStop = true;
            this.toolPanelBtn_BrokenLine.UseVisualStyleBackColor = true;
            this.toolPanelBtn_BrokenLine.Click += new System.EventHandler(this.toolPanelBtn_BrokenLine_Click);
            // 
            // toolPanelBtn_Rectangle
            // 
            this.toolPanelBtn_Rectangle.Appearance = System.Windows.Forms.Appearance.Button;
            this.toolPanelBtn_Rectangle.ImageIndex = 2;
            this.toolPanelBtn_Rectangle.ImageList = this.imageList1;
            this.toolPanelBtn_Rectangle.Location = new System.Drawing.Point(94, 7);
            this.toolPanelBtn_Rectangle.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.toolPanelBtn_Rectangle.Name = "toolPanelBtn_Rectangle";
            this.toolPanelBtn_Rectangle.Size = new System.Drawing.Size(36, 36);
            this.toolPanelBtn_Rectangle.TabIndex = 12;
            this.toolPanelBtn_Rectangle.TabStop = true;
            this.toolPanelBtn_Rectangle.UseVisualStyleBackColor = true;
            this.toolPanelBtn_Rectangle.Click += new System.EventHandler(this.toolPanelBtn_Rectangle_Click);
            // 
            // toolPanelBtn_Polygon
            // 
            this.toolPanelBtn_Polygon.Appearance = System.Windows.Forms.Appearance.Button;
            this.toolPanelBtn_Polygon.ImageIndex = 3;
            this.toolPanelBtn_Polygon.ImageList = this.imageList1;
            this.toolPanelBtn_Polygon.Location = new System.Drawing.Point(136, 7);
            this.toolPanelBtn_Polygon.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.toolPanelBtn_Polygon.Name = "toolPanelBtn_Polygon";
            this.toolPanelBtn_Polygon.Size = new System.Drawing.Size(36, 36);
            this.toolPanelBtn_Polygon.TabIndex = 13;
            this.toolPanelBtn_Polygon.TabStop = true;
            this.toolPanelBtn_Polygon.UseVisualStyleBackColor = true;
            this.toolPanelBtn_Polygon.Click += new System.EventHandler(this.toolPanelBtn_Polygon_Click);
            // 
            // toolPanelBtn_Ellipse
            // 
            this.toolPanelBtn_Ellipse.Appearance = System.Windows.Forms.Appearance.Button;
            this.toolPanelBtn_Ellipse.ImageIndex = 4;
            this.toolPanelBtn_Ellipse.ImageList = this.imageList1;
            this.toolPanelBtn_Ellipse.Location = new System.Drawing.Point(178, 7);
            this.toolPanelBtn_Ellipse.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.toolPanelBtn_Ellipse.Name = "toolPanelBtn_Ellipse";
            this.toolPanelBtn_Ellipse.Size = new System.Drawing.Size(36, 36);
            this.toolPanelBtn_Ellipse.TabIndex = 14;
            this.toolPanelBtn_Ellipse.TabStop = true;
            this.toolPanelBtn_Ellipse.UseVisualStyleBackColor = true;
            this.toolPanelBtn_Ellipse.Click += new System.EventHandler(this.toolPanelBtn_Ellipse_Click);
            // 
            // toolPanelBtn_Circle
            // 
            this.toolPanelBtn_Circle.Appearance = System.Windows.Forms.Appearance.Button;
            this.toolPanelBtn_Circle.ImageIndex = 5;
            this.toolPanelBtn_Circle.ImageList = this.imageList1;
            this.toolPanelBtn_Circle.Location = new System.Drawing.Point(220, 7);
            this.toolPanelBtn_Circle.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.toolPanelBtn_Circle.Name = "toolPanelBtn_Circle";
            this.toolPanelBtn_Circle.Size = new System.Drawing.Size(36, 36);
            this.toolPanelBtn_Circle.TabIndex = 15;
            this.toolPanelBtn_Circle.TabStop = true;
            this.toolPanelBtn_Circle.UseVisualStyleBackColor = true;
            this.toolPanelBtn_Circle.Click += new System.EventHandler(this.toolPanelBtn_Circle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(270, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 12, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Толщина линий:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(521, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 12, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Цвет линий:";
            // 
            // toolPanelBtn_LineColor
            // 
            this.toolPanelBtn_LineColor.ImageIndex = 6;
            this.toolPanelBtn_LineColor.ImageList = this.imageList1;
            this.toolPanelBtn_LineColor.Location = new System.Drawing.Point(652, 7);
            this.toolPanelBtn_LineColor.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.toolPanelBtn_LineColor.Name = "toolPanelBtn_LineColor";
            this.toolPanelBtn_LineColor.Size = new System.Drawing.Size(36, 36);
            this.toolPanelBtn_LineColor.TabIndex = 8;
            this.toolPanelBtn_LineColor.UseVisualStyleBackColor = true;
            this.toolPanelBtn_LineColor.Click += new System.EventHandler(this.toolPanelBtn_LineColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(702, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 12, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Цвет заливки:";
            // 
            // toolPanelBtn_FillColor
            // 
            this.toolPanelBtn_FillColor.ImageIndex = 6;
            this.toolPanelBtn_FillColor.ImageList = this.imageList1;
            this.toolPanelBtn_FillColor.Location = new System.Drawing.Point(851, 7);
            this.toolPanelBtn_FillColor.Margin = new System.Windows.Forms.Padding(0, 7, 6, 0);
            this.toolPanelBtn_FillColor.Name = "toolPanelBtn_FillColor";
            this.toolPanelBtn_FillColor.Size = new System.Drawing.Size(36, 36);
            this.toolPanelBtn_FillColor.TabIndex = 10;
            this.toolPanelBtn_FillColor.UseVisualStyleBackColor = true;
            this.toolPanelBtn_FillColor.Click += new System.EventHandler(this.toolPanelBtn_FillColor_Click);
            // 
            // tabsPanel
            // 
            this.tabsPanel.AutoScroll = true;
            this.tabsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabsPanel.Location = new System.Drawing.Point(0, 78);
            this.tabsPanel.Name = "tabsPanel";
            this.tabsPanel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.tabsPanel.Size = new System.Drawing.Size(1342, 30);
            this.tabsPanel.TabIndex = 6;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.CheckPathExists = false;
            this.saveFileDialog.DefaultExt = "jpg";
            this.saveFileDialog.FileName = "New_picture";
            this.saveFileDialog.Filter = "JPG files|*.jpg|PNG files|*.png|BMP files|*.bmp";
            this.saveFileDialog.Title = "Сохранить файл";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Открыть файл";
            // 
            // colorDialog_Line
            // 
            this.colorDialog_Line.FullOpen = true;
            // 
            // colorDialog_Fill
            // 
            this.colorDialog_Fill.Color = System.Drawing.Color.White;
            this.colorDialog_Fill.FullOpen = true;
            // 
            // cDrawField
            // 
            this.cDrawField.BackColor = System.Drawing.Color.White;
            this.cDrawField.Location = new System.Drawing.Point(0, 0);
            this.cDrawField.Name = "cDrawField";
            this.cDrawField.Size = new System.Drawing.Size(1342, 613);
            this.cDrawField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cDrawField.TabIndex = 7;
            this.cDrawField.TabStop = false;
            this.cDrawField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cDrawField_MouseClick);
            this.cDrawField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cDrawField_MouseMove);
            // 
            // btnResetTab
            // 
            this.btnResetTab.Location = new System.Drawing.Point(1320, 115);
            this.btnResetTab.Name = "btnResetTab";
            this.btnResetTab.Size = new System.Drawing.Size(0, 0);
            this.btnResetTab.TabIndex = 8;
            this.btnResetTab.UseVisualStyleBackColor = true;
            // 
            // cPanelDrawField
            // 
            this.cPanelDrawField.AutoScroll = true;
            this.cPanelDrawField.AutoSize = true;
            this.cPanelDrawField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cPanelDrawField.Controls.Add(this.cDrawField);
            this.cPanelDrawField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cPanelDrawField.Location = new System.Drawing.Point(0, 108);
            this.cPanelDrawField.Name = "cPanelDrawField";
            this.cPanelDrawField.Size = new System.Drawing.Size(1342, 613);
            this.cPanelDrawField.TabIndex = 9;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 721);
            this.Controls.Add(this.cPanelDrawField);
            this.Controls.Add(this.btnResetTab);
            this.Controls.Add(this.tabsPanel);
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.menuStripMain);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphics";
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectLineWidth)).EndInit();
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cDrawField)).EndInit();
            this.cPanelDrawField.ResumeLayout(false);
            this.cPanelDrawField.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuStripItem_File;
        private System.Windows.Forms.ToolStripMenuItem menuStripItem_Drawing;
        private System.Windows.Forms.ToolStripMenuItem menuSytripItem_Tools;
        private System.Windows.Forms.ToolStripMenuItem menuSytripItem_About;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemFile_Create;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemFile_;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemFile_Open;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemFile_Save;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemFile_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuStripDrawing_Line;
        private System.Windows.Forms.ToolStripMenuItem menuStripDrawing_;
        private System.Windows.Forms.ToolStripMenuItem menuStripDrawing_BrokenLine;
        private System.Windows.Forms.ToolStripMenuItem menuStripDrawing_Rectangle;
        private System.Windows.Forms.ToolStripMenuItem menuStripDrawing_Polygon;
        private System.Windows.Forms.ToolStripMenuItem menuStripDrawing_Ellipse;
        private System.Windows.Forms.ToolStripMenuItem menuStripDrawing_Circle;
        private System.Windows.Forms.ToolStripMenuItem menuStripTools_FillColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuStripTools_Undo;
        private System.Windows.Forms.ToolStripMenuItem menuStripTools_Redo;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem menuStripTools_LineWidth;
        private System.Windows.Forms.ToolStripMenuItem menuStripTools_LineColor;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemFile_Exit;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.NumericUpDown selectLineWidth;
        private System.Windows.Forms.FlowLayoutPanel toolPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button toolPanelBtn_LineColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button toolPanelBtn_FillColor;
        private System.Windows.Forms.FlowLayoutPanel tabsPanel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ColorDialog colorDialog_Line;
        private System.Windows.Forms.ColorDialog colorDialog_Fill;
        private System.Windows.Forms.PictureBox cDrawField;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemFile_ExitCurrent;
        private System.Windows.Forms.Button btnResetTab;
        private System.Windows.Forms.Panel cPanelDrawField;
        private System.Windows.Forms.RadioButton toolPanelBtn_Line;
        private System.Windows.Forms.RadioButton toolPanelBtn_BrokenLine;
        private System.Windows.Forms.RadioButton toolPanelBtn_Rectangle;
        private System.Windows.Forms.RadioButton toolPanelBtn_Polygon;
        private System.Windows.Forms.RadioButton toolPanelBtn_Ellipse;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton toolPanelBtn_Circle;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

