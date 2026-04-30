namespace SimplePaint
{
    public partial class SimplePaint : Form
    {
        Point startPoint;
        Point endPoint;
        bool isDrawing = false;

        string currentShape = "Line";
        Color currentColor = Color.Black;
        int currentThickness = 2;

        Bitmap canvas;1
        Graphics g;

        float zoom = 1.0f;




        public SimplePaint()
        {
            InitializeComponent();

            // 이벤트 연결
            btnLine.Click += btnLine_Click;
            btnRectangle.Click += btnRectangle_Click;
            btnCircle.Click += btnCircle_Click;

            
            

            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            trbLineWidth.Scroll += trbLineWidth_Scroll;

            this.Load += Form1_Load;

            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseUp += picCanvas_MouseUp;
            picCanvas.Paint += picCanvas_Paint;

            panelMain.MouseWheel += panelMain_MouseWheel;
            picCanvas.MouseWheel += panelMain_MouseWheel;

            this.MouseWheel += panelMain_MouseWheel;

            panelMain.MouseEnter += (s, e) => panelMain.Focus();
            picCanvas.MouseEnter += (s, e) => panelMain.Focus();

            panelMain.TabStop = true;

            // 색상 설정
            cmbColor.Items.Add("Black 검정");
            cmbColor.Items.Add("Red 빨강");
            cmbColor.Items.Add("Blue 파랑");
            cmbColor.Items.Add("Green 초록");
            cmbColor.SelectedIndex = 0;

            // 선 두께 설정
            trbLineWidth.Minimum = 1;
            trbLineWidth.Maximum = 20;
            trbLineWidth.Value = 2;

            // 레이아웃 설정
            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 200;

            panelMain.Dock = DockStyle.Fill;
            panelMain.Padding = new Padding(0);
            panelMain.AutoScroll = true;

            picCanvas.Dock = DockStyle.None;
            picCanvas.Location = new Point(0, 0);
            picCanvas.SizeMode = PictureBoxSizeMode.StretchImage;

            // 버튼 이미지 설정
            btnLine.BackgroundImage = Properties.Resources.Line;
            btnLine.BackgroundImageLayout = ImageLayout.Zoom;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;

            btnRectangle.BackgroundImage = Properties.Resources.Rectangle;
            btnRectangle.BackgroundImageLayout = ImageLayout.Zoom;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;

            btnCircle.BackgroundImage = Properties.Resources.Circle;
            btnCircle.BackgroundImageLayout = ImageLayout.Zoom;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;

            panelMain.AutoScroll = true;
            panelMain.Padding = new Padding(0);

            picCanvas.Dock = DockStyle.None;
            picCanvas.Location = new Point(0, 0);
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(panelMain.ClientSize.Width, panelMain.ClientSize.Height);
            g = Graphics.FromImage(canvas);
            g.Clear(Color.White);

            picCanvas.Image = canvas;
            picCanvas.Size = new Size(panelMain.ClientSize.Width, panelMain.ClientSize.Height);
            picCanvas.Location = new Point(0, 0);

            panelMain.AutoScrollMinSize = picCanvas.Size;
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;

            startPoint = ToCanvasPoint(e.Location);
            endPoint = ToCanvasPoint(e.Location);
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                
                endPoint = ToCanvasPoint(e.Location);
                picCanvas.Invalidate(); 
            }
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            endPoint = ToCanvasPoint(e.Location);

            using Pen pen = new Pen(currentColor, currentThickness);

            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);
            int w = Math.Abs(startPoint.X - endPoint.X);
            int h = Math.Abs(startPoint.Y - endPoint.Y);

            if (currentShape == "Line")
                g.DrawLine(pen, startPoint, endPoint);

            else if (currentShape == "Rectangle")
                g.DrawRectangle(pen, x, y, w, h);

            else if (currentShape == "Circle")
                g.DrawEllipse(pen, x, y, w, h);

            picCanvas.Invalidate();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;

            using Pen pen = new Pen(currentColor, currentThickness * zoom);

            Point previewStart = new Point(
                (int)(startPoint.X * zoom),
                (int)(startPoint.Y * zoom)
            );

            Point previewEnd = new Point(
                (int)(endPoint.X * zoom),
                (int)(endPoint.Y * zoom)
            );

            int x = Math.Min(previewStart.X, previewEnd.X);
            int y = Math.Min(previewStart.Y, previewEnd.Y);
            int w = Math.Abs(previewStart.X - previewEnd.X);
            int h = Math.Abs(previewStart.Y - previewEnd.Y);

            if (currentShape == "Line")
                e.Graphics.DrawLine(pen, previewStart, previewEnd);

            else if (currentShape == "Rectangle")
                e.Graphics.DrawRectangle(pen, x, y, w, h);

            else if (currentShape == "Circle")
                e.Graphics.DrawEllipse(pen, x, y, w, h);
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            currentShape = "Line";
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentShape = "Rectangle";
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentShape = "Circle";
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbColor.Text.Split(' ')[0];
            currentColor = Color.FromName(selected);
        }
        private void trbLineWidth_Scroll(object sender, EventArgs e)
        {
            currentThickness = trbLineWidth.Value;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "이미지 파일|*.png;*.jpg;*.bmp";
            openDialog.Title = "이미지 열기";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap loadedImage = new Bitmap(openDialog.FileName);

                canvas = new Bitmap(loadedImage);
                g = Graphics.FromImage(canvas);

                picCanvas.Image = canvas;

                picCanvas.Image = canvas;

                zoom = 1.0f;

                picCanvas.Size = new Size(
                    (int)(canvas.Width * zoom),
                    (int)(canvas.Height * zoom)
                );

                picCanvas.Location = new Point(0, 0);
                panelMain.AutoScrollMinSize = picCanvas.Size;
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "PNG 파일|*.png|JPG 파일|*.jpg|BMP 파일|*.bmp";
            saveDialog.Title = "이미지 저장";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                canvas.Save(saveDialog.FileName);
            }
        }
        private void panelMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) != Keys.Control)
                return;

            if (canvas == null)
                return;

            // 확대 / 축소
            if (e.Delta > 0)
                zoom += 0.1f;
            else
                zoom -= 0.1f;

            // 범위 제한
            if (zoom < 0.2f) zoom = 0.2f;
            if (zoom > 5.0f) zoom = 5.0f;

            // 크기 적용
            picCanvas.Size = new Size(
                (int)(canvas.Width * zoom),
                (int)(canvas.Height * zoom)
            );

            // 스크롤 영역 갱신
            panelMain.AutoScrollMinSize = picCanvas.Size;
        }
        private Point ToCanvasPoint(Point p)
        {
            return new Point(
                (int)(p.X / zoom),
                (int)(p.Y / zoom)
            );
        }
    }
    
}
