namespace SimplePaint
{
    partial class SimplePaint
    {

        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblAppName = new Label();
            grpSelect = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnLine = new Button();
            grpColor = new GroupBox();
            cmbColor = new ComboBox();
            grpThick = new GroupBox();
            trbLineWidth = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            picCanvas = new PictureBox();
            panelTop = new Panel();
            panelMain = new Panel();
            grpSelect.SuspendLayout();
            grpColor.SuspendLayout();
            grpThick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            panelTop.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("맑은 고딕", 25.875F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblAppName.ForeColor = Color.FromArgb(0, 0, 192);
            lblAppName.Location = new Point(12, 9);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(429, 92);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "Simple Paint";
            // 
            // grpSelect
            // 
            grpSelect.Controls.Add(btnCircle);
            grpSelect.Controls.Add(btnRectangle);
            grpSelect.Controls.Add(btnLine);
            grpSelect.Location = new Point(3, 5);
            grpSelect.Name = "grpSelect";
            grpSelect.Size = new Size(454, 192);
            grpSelect.TabIndex = 1;
            grpSelect.TabStop = false;
            grpSelect.Text = "도형 선택";
            // 
            // btnCircle
            // 
            btnCircle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCircle.BackgroundImageLayout = ImageLayout.Center;
            btnCircle.Location = new Point(298, 38);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(140, 139);
            btnCircle.TabIndex = 2;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            // 
            // btnRectangle
            // 
            btnRectangle.BackgroundImageLayout = ImageLayout.Center;
            btnRectangle.Location = new Point(152, 38);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(140, 139);
            btnRectangle.TabIndex = 1;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = true;
            // 
            // btnLine
            // 
            btnLine.BackgroundImageLayout = ImageLayout.Center;
            btnLine.ImageAlign = ContentAlignment.TopCenter;
            btnLine.Location = new Point(6, 38);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(140, 139);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // grpColor
            // 
            grpColor.Controls.Add(cmbColor);
            grpColor.Location = new Point(463, 5);
            grpColor.Name = "grpColor";
            grpColor.Size = new Size(276, 192);
            grpColor.TabIndex = 2;
            grpColor.TabStop = false;
            grpColor.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            cmbColor.FormattingEnabled = true;
            cmbColor.Location = new Point(17, 87);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(242, 53);
            cmbColor.TabIndex = 5;
            // 
            // grpThick
            // 
            grpThick.Controls.Add(trbLineWidth);
            grpThick.Location = new Point(745, 5);
            grpThick.Name = "grpThick";
            grpThick.Size = new Size(316, 192);
            grpThick.TabIndex = 2;
            grpThick.TabStop = false;
            grpThick.Text = "선 두께";
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(6, 87);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(304, 90);
            trbLineWidth.TabIndex = 5;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.FromArgb(255, 255, 128);
            btnOpenFile.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnOpenFile.Location = new Point(1067, 82);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(140, 112);
            btnOpenFile.TabIndex = 3;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = SystemColors.ActiveCaption;
            btnSaveFile.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            btnSaveFile.Location = new Point(1213, 82);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(140, 112);
            btnSaveFile.TabIndex = 4;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            btnSaveFile.Click += btnSaveFile_Click;
            // 
            // picCanvas
            // 
            picCanvas.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            picCanvas.BackColor = Color.White;
            picCanvas.Location = new Point(3, 3);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(1382, 674);
            picCanvas.TabIndex = 5;
            picCanvas.TabStop = false;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(grpSelect);
            panelTop.Controls.Add(grpColor);
            panelTop.Controls.Add(btnSaveFile);
            panelTop.Controls.Add(grpThick);
            panelTop.Controls.Add(btnOpenFile);
            panelTop.Location = new Point(31, 123);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1388, 212);
            panelTop.TabIndex = 6;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(picCanvas);
            panelMain.Location = new Point(31, 361);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1388, 707);
            panelMain.TabIndex = 7;
            // 
            // SimplePaint
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1581, 754);
            Controls.Add(panelMain);
            Controls.Add(panelTop);
            Controls.Add(lblAppName);
            Name = "SimplePaint";
            Text = "Simple Paint v1.0";
            grpSelect.ResumeLayout(false);
            grpColor.ResumeLayout(false);
            grpThick.ResumeLayout(false);
            grpThick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            panelTop.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private GroupBox grpSelect;
        private GroupBox grpColor;
        private GroupBox grpThick;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnLine;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private ComboBox cmbColor;
        private TrackBar trbLineWidth;
        private PictureBox picCanvas;
        private Panel panelTop;
        private Panel panelMain;
    }
}
