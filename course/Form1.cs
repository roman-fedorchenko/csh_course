using System.Security.Cryptography; // Для SHA256
using NAudio.Wave;                  // Для роботи з мікрофоном
using System.Text;

namespace course
{
    struct SPoint
    {
        public double x; // вхідний x
        public double y; // результат функції f(x)
        public double q; // випадкова величина

        public SPoint(double x, double y, double q)
        {
            this.x = x;
            this.y = y;
            this.q = q;
        }
        public string Stringify()
        {
            return $"x: {x:F2}, y: {y:F4}, q: {q:F4}";
        }
    }

    public partial class Form1 : Form
    {
        private List<SPoint> F1List = new List<SPoint>(); // Масив для збереження результатів функції f1
        private List<SPoint> F2List = new List<SPoint>(); // Масив для збереження результатів функції f2
        private int F1counter = 0;                        // Лічильник для функції f1
        private int F2counter = 0;                        // Лічильник для функції f2
        StringBuilder errorMessages = new StringBuilder();// Для накопичення повідомлень про помилки
        // Функції для обчислення значень f1 та f2
        public double f1(double x, double q)
        {
            return Math.Sqrt(Math.Cos(q * x));
        }
        public double f2(double x, double a, double q)
        {
            return q / (Math.Log10(a - x));
        }

        // Метод для отримання випадкового числа з мікрофона
        public int GetMicrophoneSeed()
        {
            byte[] audioBuffer = null;

            try
            {
                using (var waveIn = new WaveInEvent())
                {
                    waveIn.WaveFormat = new WaveFormat(44100, 16, 1);
                    waveIn.DataAvailable += (s, args) =>
                    {
                        if (audioBuffer == null && args.BytesRecorded > 0)
                        {
                            audioBuffer = new byte[args.BytesRecorded];
                            Array.Copy(args.Buffer, audioBuffer, args.BytesRecorded);
                        }
                    };
                    waveIn.StartRecording();
                    System.Threading.Thread.Sleep(40);
                    waveIn.StopRecording();
                }
                if (audioBuffer == null || audioBuffer.Length == 0)
                {
                    return Guid.NewGuid().GetHashCode();
                }
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(audioBuffer);
                    return BitConverter.ToInt32(hashBytes, 0);
                }
            }
            catch
            {
                return Guid.NewGuid().GetHashCode();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(numXmin, "Початкове (мінімальне) значення аргументу X інтервалу обчислень");
            toolTip1.SetToolTip(numXmax, "Кінцеве (максимальне) значення аргументу X інтервалу обчислень");
            toolTip1.SetToolTip(numdX, "Крок приросту аргументу X (dx) для циклу розрахунку");
            toolTip1.SetToolTip(numA, "Математична константа А, необхідна для розрахунку функції F2");
            toolTip1.SetToolTip(menuStrip2, "Головне меню програми для навігації та виклику графіків");
            numXmin.MouseWheel += NumericUpDown_MouseWheel;
            numXmax.MouseWheel += NumericUpDown_MouseWheel;
            numdX.MouseWheel += NumericUpDown_MouseWheel;
            numA.MouseWheel += NumericUpDown_MouseWheel;
            numXmin.ValueChanged += OnAnyInputChanged;
            numXmax.ValueChanged += OnAnyInputChanged;
            numA.ValueChanged += OnAnyInputChanged;
            numdX.ValueChanged += OnAnyInputChanged;
            ValidateInputs();
        }
        private void OnAnyInputChanged(object sender, EventArgs e)
        {
            ValidateInputs();
        }
        // Обробник колеса миші для NumericUpDown
        private void NumericUpDown_MouseWheel(object sender, MouseEventArgs e)
        {
            NumericUpDown numBox = (NumericUpDown)sender;
            decimal newValue = e.Delta > 0 ? numBox.Value + numBox.Increment : numBox.Value - numBox.Increment;
            numBox.Value = Math.Clamp(newValue, numBox.Minimum, numBox.Maximum);
            ((HandledMouseEventArgs)e).Handled = true;
        }
        // Обробник кнопки "Обчислити"
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            F1listBox.Items.Clear();
            F2listBox.Items.Clear();
            F1List.Clear();
            F2List.Clear();
            F1counter = 0;
            F2counter = 0;
            errorMessages.Clear();
            int hardwareSeed = GetMicrophoneSeed();
            Random trueRand = new Random(hardwareSeed);
            double xmin = (double)numXmin.Value, xmax = (double)numXmax.Value, dx = (double)numdX.Value, a = (double)numA.Value, q;
            if (xmin >= xmax)
            {
                MessageBox.Show("Xmin повинен бути меншим за Xmax!", "Помилка логіки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label5.Text = "Функція F1: 0";
                label6.Text = "Функція F2: 0";
                return;
            }
            if (dx <= 0)
            {
                MessageBox.Show("Крок dx повинен бути більшим за 0!", "Помилка логіки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label5.Text = "Функція F1: 0";
                label6.Text = "Функція F2: 0";
                return;
            }
            for (double x = xmin; x <= xmax; x += dx)
            {
                q = trueRand.NextDouble();
                if (q > 0 && q <= 0.35)
                {
                    if (Math.Cos(q * x) >= 0)
                    {
                        F1List.Add(new SPoint(x, f1(x, q), q));
                        F1counter++;
                        F1listBox.Items.Add(F1List.Last().Stringify());
                    }
                    else
                    {
                        errorMessages.AppendLine($"Функція f1(x): Неможливо взяти корінь з від'ємного числа: {Math.Cos(q * x):F2}<0 " + $"Поточні дані: x = {x:F2}, q = {q:F4}");
                    }
                }
                else if (q > 0.35 && q <= 1.0)
                {
                    if (a - x <= 0)
                    {
                        errorMessages.AppendLine($"Функція f2(x): Порушено ОДЗ логарифма a - x  > 0: {a - x:F2}<0 " + $"Поточні дані: x = {x:F2}, a = {a:F2}, q = {q:F4}");
                    }
                    else if (Math.Abs(a - x - 1) < 0.00001)
                    {
                        errorMessages.AppendLine($"Функція f2(x): Порушено ОДЗ логарифма a - x != 1: {a - x:F2}=1 " + $"Поточні дані: x = {x:F2}, a = {a:F2}, q = {q:F4}");
                    }
                    else
                    {
                        F2List.Add(new SPoint(x, f2(x, a, q), q));
                        F2counter++;
                        F2listBox.Items.Add(F2List.Last().Stringify());
                    }
                }
            }
            label5.Text = $"Функція F1: {F1counter}";
            label6.Text = $"Функція F2: {F2counter}";
            if (errorMessages.Length > 0)
            {
                Form errorForm = new Form();
                errorForm.Text = "Виявлено неможливість обчислення!";
                errorForm.Size = new Size(500, 350);
                errorForm.StartPosition = FormStartPosition.CenterParent;
                errorForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                errorForm.MaximizeBox = false;
                errorForm.MinimizeBox = false;
                TextBox txtErrors = new TextBox();
                txtErrors.Multiline = true;
                txtErrors.ReadOnly = true;
                txtErrors.SelectionStart = 0;
                txtErrors.ScrollBars = ScrollBars.Vertical;

                txtErrors.Location = new Point(15, 15);
                txtErrors.Size = new Size(455, 230);
                txtErrors.Text = errorMessages.ToString();
                txtErrors.Font = new Font("Segoe UI", 9.5f);

                Button btnOk = new Button();
                btnOk.Text = "ОК";
                btnOk.Location = new Point(200, 265);
                btnOk.Size = new Size(90, 30);
                btnOk.Click += (s, args) => errorForm.Close();

                errorForm.Controls.Add(txtErrors);
                errorForm.Controls.Add(btnOk);

                errorForm.ShowDialog();
                errorForm.Dispose();
            }
        }
        // Обробник пункту меню "Автор"
        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form formAuth = new Form();
            formAuth.Text = "Про автора";
            formAuth.Size = new Size(300, 420);
            formAuth.StartPosition = FormStartPosition.CenterParent;
            formAuth.FormBorderStyle = FormBorderStyle.FixedDialog;
            formAuth.MaximizeBox = false;
            formAuth.MinimizeBox = false;

            PictureBox pbPhoto = new PictureBox();
            pbPhoto.Location = new Point(40, 20);
            pbPhoto.Size = new Size(200, 250);
            pbPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPhoto.Image = Properties.Resources.photo;
            Label lblInfo = new Label();
            lblInfo.Location = new Point(20, 290);
            lblInfo.Size = new Size(240, 50);
            lblInfo.TextAlign = ContentAlignment.TopCenter;
            lblInfo.Font = new Font("Arial", 11, FontStyle.Bold);
            lblInfo.Text = "Студент: Федорченко Р.С.\nГрупа: ЦТ-43-5";

            Button btnClose = new Button();
            btnClose.Text = "OK";
            btnClose.Location = new Point(100, 350);
            btnClose.Size = new Size(80, 25);

            btnClose.Click += (s, args) => formAuth.Close();

            formAuth.Controls.Add(pbPhoto);
            formAuth.Controls.Add(lblInfo);
            formAuth.Controls.Add(btnClose);

            formAuth.ShowDialog();
            formAuth.Dispose();
        }
        // Функція кольору для першого графіка (Синьо-Зелений)
        private Color GetColorForF1(double q)
        {
            int factor = (int)((q / 0.35) * 255);
            factor = Math.Clamp(factor, 0, 255);
            return Color.FromArgb(255, 0, factor, 255 - factor);
        }
        // Функція кольору для другого графіка (Жовто-Червоний)
        private Color GetColorForF2(double q)
        {
            int factor = (int)(((q - 0.35) / 0.65) * 255);
            factor = Math.Clamp(factor, 0, 255);
            return Color.FromArgb(255, 255, 255 - factor, 0);
        }
        // Метод для відображення скупчення точок на графіку
        private void DrawPointCloud(List<SPoint> points, string plotTitle, Func<double, Color> colorCalculator)
        {
            formsPlot1.Plot.Clear();
            if (points == null || points.Count == 0)
            {
                formsPlot1.Plot.Title("Немає даних для відображення");
                formsPlot1.Refresh();
                return;
            }
            ScottPlot.MarkerShape globalShape = ScottPlot.MarkerShape.FilledCircle;
            float globalSize = 7;
            foreach (var pt in points)
            {
                Color dotColor = colorCalculator(pt.q);
                var marker = formsPlot1.Plot.Add.Marker(pt.x, pt.y);
                marker.Shape = globalShape;
                marker.Size = globalSize;
                marker.Color = new ScottPlot.Color(dotColor.R, dotColor.G, dotColor.B, 255);
            }
            formsPlot1.Plot.Title(plotTitle);
            formsPlot1.Plot.XLabel("Аргумент X");
            formsPlot1.Plot.YLabel("Результат Y");
            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Refresh();
        }
        // Обробник для графіка F1
        private void graphF1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F1List.Count == 0)
            {
                MessageBox.Show("Масив F1 порожній! Спочатку натисніть кнопку обчислення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DrawPointCloud(F1List, "Скупчення точок для  F1(x)=(cos(q*x))^(1/2)", GetColorForF1);
        }
        // Обробник для графіка F2
        private void graphF2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F2List.Count == 0)
            {
                MessageBox.Show("Масив F2 порожній! Спочатку натисніть кнопку обчислення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DrawPointCloud(F2List, "Скупчення точок для F2(x)=q/(log(a-x))", GetColorForF2);
        }
        // Метод для валідації вхідних даних та відображення попереджень
        private void ValidateInputs()
        {
            WarninglistBox.Items.Clear();
            numXmin.BackColor = SystemColors.Window;
            numXmax.BackColor = SystemColors.Window;
            numA.BackColor = SystemColors.Window;
            numdX.BackColor = SystemColors.Window;
            double xmin = (double)numXmin.Value;
            double xmax = (double)numXmax.Value;
            double a = (double)numA.Value;
            double dx = (double)numdX.Value;
            bool xmaxIsCriticalError = false;
            if (xmin >= xmax)
            {
                WarninglistBox.Items.Add("Xmin повинен бути меншим за Xmax");
                numXmin.BackColor = Color.LightPink;
                numXmax.BackColor = Color.LightPink;
                xmaxIsCriticalError = true;
            }
            if (xmax >= a)
            {
                WarninglistBox.Items.Add("A бажано бути більшим за Xmax");
                numA.BackColor = Color.LightYellow;
                if (!xmaxIsCriticalError)
                {
                    numXmax.BackColor = Color.LightYellow;
                }
            }
            if (dx > (xmax - xmin) && xmax > xmin)
            {
                WarninglistBox.Items.Add("Виставте менший крок dX");
                numdX.BackColor = Color.LightYellow;
            }
            groupBox3.Visible = WarninglistBox.Items.Count > 0;
        }
    }
}
