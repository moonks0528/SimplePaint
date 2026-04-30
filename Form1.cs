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

        Bitmap canvas;
        Graphics g;

        public SimplePaint()
        {
            InitializeComponent();

            btnLine.Click += btnLine_Click;
            btnRectangle.Click += btnRectangle_Click;
            btnCircle.Click += btnCircle_Click;

            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;

            cmbColor.Items.Add("Black 검정");
            cmbColor.Items.Add("Red 빨강");
            cmbColor.Items.Add("Blue 파랑");
            cmbColor.Items.Add("Green 초록");

            cmbColor.SelectedIndex = 0;

            trbLineWidth.Scroll += trbLineWidth_Scroll;

            trbLineWidth.Minimum = 1;
            trbLineWidth.Maximum = 20;
            trbLineWidth.Value = 2;


            cmbColor.SelectedIndex = 0;

            this.Load += Form1_Load;

            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseUp += picCanvas_MouseUp;
            picCanvas.Paint += picCanvas_Paint;

            panelTop.BringToFront();

            panelMain.Dock = DockStyle.Fill;
            panelMain.Padding = new Padding(20);

            picCanvas.Dock = DockStyle.Fill;



            panelTop.Dock = DockStyle.Top;
            panelTop.Height = 200;

            btnOpenFile.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSaveFile.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            cmbColor.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            trbLineWidth.Anchor = AnchorStyles.Top | AnchorStyles.Left;


            btnLine.BackgroundImage = Properties.Resources.Line;
            btnLine.BackgroundImageLayout = ImageLayout.Zoom;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;

            btnCircle.BackgroundImage = Properties.Resources.Circle;
            btnCircle.BackgroundImageLayout = ImageLayout.Zoom;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;

            btnRectangle.BackgroundImage = Properties.Resources.Rectangle;
            btnRectangle.BackgroundImageLayout = ImageLayout.Zoom;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;

            btnLine.BackgroundImage = Properties.Resources.Line;
            btnLine.BackgroundImageLayout = ImageLayout.Zoom;

            btnRectangle.BackgroundImage = Properties.Resources.Rectangle;
            btnRectangle.BackgroundImageLayout = ImageLayout.Zoom;

            btnCircle.BackgroundImage = Properties.Resources.Circle;
            btnCircle.BackgroundImageLayout = ImageLayout.Zoom;





        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = new Bitmap(picCanvas.Width, picCanvas.Height);
            g = Graphics.FromImage(canvas);

            g.Clear(Color.White); // 배경 흰색

            picCanvas.Image = canvas;
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;

            startPoint = e.Location;
            endPoint = e.Location;
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                endPoint = e.Location;
                picCanvas.Invalidate(); // 다시 그리기 요청
            }
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            endPoint = e.Location;

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

            picCanvas.Invalidate(); // 다시 그리기
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;

            using Pen pen = new Pen(currentColor, currentThickness);

            int x = Math.Min(startPoint.X, endPoint.X);
            int y = Math.Min(startPoint.Y, endPoint.Y);
            int w = Math.Abs(startPoint.X - endPoint.X);
            int h = Math.Abs(startPoint.Y - endPoint.Y);

            if (currentShape == "Line")
                e.Graphics.DrawLine(pen, startPoint, endPoint);

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

    }
}
