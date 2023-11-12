using System;
using System.Diagnostics.Metrics;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Penetration_C_
{
    public partial class Form1 : Form
    {

        private bool isDragging = false;
        private Point lastCursorPosition;

        private bool isResizing = false;
        private Point resizeStart;
        private Size originalSize;

        PictureBox pictureBox1;

        Chart line_attacks, histogram_attacks;
        Bitmap b_line, b_column, b_final;


        public Form1()
        {
            InitializeComponent();

            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = Int32.MaxValue;

            numericUpDown2.Minimum = 1;
            numericUpDown2.Maximum = Int32.MaxValue;

            numericUpDown3.Minimum = 1;
            numericUpDown3.Maximum = Int32.MaxValue;
        }

        int prev = 0;
        int curr = 1;
        System.Timers.Timer myTimer;
        bool status1 = false;

        int min_value, max_value;
        int[] values_lines;

        ChartArea chartArea, histogramArea;


        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(0, 100);
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.Height = this.Size.Height;
            pictureBox1.Width = this.Size.Width;
            //pictureBox1.BackColor = Color.Red;
            this.Controls.Add(pictureBox1);


            panel1.Width = pictureBox1.Width;
            panel1.Height = pictureBox1.Height - 139;
            panel1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int success_treshold = (int)numericUpDown1.Value;
            int intervals = (int)numericUpDown2.Value;
            int number_servers = (int)numericUpDown3.Value;

            myTimer = new System.Timers.Timer();
            myTimer.Interval = 500;
            myTimer.Elapsed += myElapsed;
            myTimer.AutoReset = true;
            myTimer.Start();

            createAttackGraphs_Panel(success_treshold, intervals, number_servers);

            myTimer.Stop();

        }



        private void myElapsed(object sender, ElapsedEventArgs e)
        {
            curr++;
        }

        private void myRefresh()
        {
            if (status1)
            {
                chartArea.AxisY.Maximum = max_value;
                chartArea.AxisY.Minimum = min_value;
                chartArea.AxisY.Interval = 10;
                histogramArea.AxisX.Maximum = max_value;
                histogramArea.AxisX.Minimum = min_value;
                histogramArea.AxisX.Interval = 10;

                /*
                int temp;
                max_histogram = 0;
                for (int i = 0; i < values_lines.Length; i++)
                {
                    temp = values_lines.Count(s => s == values_lines[i]);
                    if (temp > max_histogram) { max_histogram = temp; }
                }
                histogramArea.AxisY.Maximum = max_histogram * 1.05;
                */

                this.line_attacks.DrawToBitmap(this.b_line, new Rectangle(0, 0, panel1.Width / 2, panel1.Height));
                this.histogram_attacks.DrawToBitmap(this.b_column, new Rectangle(panel1.Width / 2, 0, panel1.Width, panel1.Height));
                
                this.b_line.MakeTransparent(Color.White);
                this.b_column.MakeTransparent(Color.White);

                using (Graphics g = Graphics.FromImage(this.b_final))
                {
                    g.Clear(Color.Transparent);
                    g.DrawImage(this.b_line, new Rectangle(0, 0, panel1.Width, panel1.Height));
                    g.DrawImage(this.b_column, new Rectangle(0, 0, panel1.Width, panel1.Height));
                }
                
                this.panel1.BackgroundImage = this.b_final;
                this.panel1.BackgroundImageLayout = ImageLayout.Stretch;
                this.panel1.Refresh();
            }
            prev = curr;
        }



        private void createAttackGraphs_Panel(int success_treshold, int intervals, int number_servers)
        {
            status1 = true;

            // Create the Chart for the security score 
            line_attacks = new Chart();
            line_attacks.Width = panel1.Width / 2;
            line_attacks.Height = panel1.Height;

            // Create chart for security scores
            chartArea = new ChartArea("SecurityChart");
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;
            chartArea.AxisY.LabelStyle.Format = "0";
            line_attacks.ChartAreas.Add(chartArea);


            // Create chart for the histogram
            histogram_attacks = new Chart();
            histogram_attacks.Width = panel1.Width / 2;
            histogram_attacks.Height = panel1.Height;
            histogramArea = new ChartArea("HistogramChart");
            histogramArea.AxisY.Minimum = 0;
            histogramArea.AxisX.MajorGrid.LineWidth = 0;
            histogramArea.AxisY.MajorGrid.LineWidth = 0;
            histogram_attacks.ChartAreas.Add(histogramArea);


            // Create bitmap that will contain both charts
            b_line = new Bitmap(panel1.Width, panel1.Height);
            b_column = new Bitmap(panel1.Width, panel1.Height);
            b_final = new Bitmap(panel1.Width, panel1.Height);


            // Variables for the security score chart
            Series[] lines_array = new Series[number_servers];
            values_lines = new int[number_servers];
            Random rnd = new Random();


            // Initialization of security score chart
            for (int i = 0; i < lines_array.Length; i++)
            {
                Series line_series = new Series();
                lines_array[i] = line_series;
                line_series.Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                line_series.ChartType = SeriesChartType.Line;
                line_attacks.Series.Add(line_series);
                line_series.Points.AddXY(0, 0);
                values_lines[i] = 0;
            }


            // Add success treshold to chart 
            StripLine success_line = new StripLine();
            success_line.Interval = 0;
            success_line.IntervalOffset = success_treshold;
            success_line.StripWidth = 0.1;
            success_line.BackColor = Color.Green;
            chartArea.AxisY.StripLines.Add(success_line);
            myRefresh();

            // Add negative tresholds to chart
            for (int i = 2, j = -10; i < 11; i++)
            {
                StripLine negative_line = new StripLine();
                negative_line.Interval = 0;
                negative_line.IntervalOffset = j*i;
                negative_line.StripWidth = 0.1;
                negative_line.BackColor = Color.Red;
                chartArea.AxisY.StripLines.Add(negative_line);
                myRefresh();
            }


            min_value = 0;
            max_value = 0;
            int[] success_mask = new int[number_servers];
            int[] failure_mask = new int[number_servers];
            // Simulation to draw chart
            for (int i = 1; i < intervals + 1; i++)
            {
                for (int j = 0; j < number_servers; j++)
                {
                    Series series = lines_array[j];

                    if (rnd.NextDouble() >= 0.5)
                    {
                        series.Points.AddXY(i, values_lines[j] - 1);
                        values_lines[j] -= 1;
                        if (values_lines[j] <= min_value) min_value = values_lines[j];
                        if (values_lines[j] <= -20 && failure_mask[j] == 0) failure_mask[j] = 1;
                        if (values_lines[j] <= -30 && failure_mask[j] == 1) failure_mask[j] = 2;
                        if (values_lines[j] <= -40 && failure_mask[j] == 2) failure_mask[j] = 3;
                        if (values_lines[j] <= -50 && failure_mask[j] == 3) failure_mask[j] = 4;
                        if (values_lines[j] <= -60 && failure_mask[j] == 4) failure_mask[j] = 5;
                        if (values_lines[j] <= -70 && failure_mask[j] == 5) failure_mask[j] = 6;
                        if (values_lines[j] <= -80 && failure_mask[j] == 6) failure_mask[j] = 7;
                        if (values_lines[j] <= -90 && failure_mask[j] == 7) failure_mask[j] = 8;
                        if (values_lines[j] <= -100 && failure_mask[j] == 8) failure_mask[j] = 9;
                    }
                    else
                    {
                        series.Points.AddXY(i, values_lines[j] + 1);
                        values_lines[j] += 1;
                        if (values_lines[j] >= max_value) max_value = values_lines[j];
                        if (values_lines[j] == success_treshold && failure_mask[j] == 0) success_mask[j] = 1;
                    }
                    line_attacks.Series.Append(series);
                    line_attacks.Update();
                }
                if (prev != curr) myRefresh();
            }
            myRefresh();


            // Draw histogram for success
            Series histogram_success_series = new Series();
            histogram_success_series.ChartType = SeriesChartType.Bar;
            histogram_success_series.Color = Color.Green;
            histogram_success_series["PointWidth"] = "1";
            histogram_success_series.SmartLabelStyle.IsMarkerOverlappingAllowed = false;
            histogram_success_series.Points.Add(new DataPoint(success_treshold, success_mask.Count(s => s == 1)));
            histogram_success_series.Label = success_mask.Count(s => s == 1).ToString();
            histogram_attacks.Series.Add(histogram_success_series);
            histogram_attacks.Update();
            myRefresh();


            // Draw histogram for fail
            int[] frequencies = new int[9];
            for (int i = 0; i < number_servers; i++)
            {
                if (success_mask[i] == 1) continue;
                for (int j = 0; j < failure_mask[i]; j++) { frequencies[j]++; }
            }
            
            for (int i = 0, j = -20; i < frequencies.Length; i++, j-=10)
            {
                Series histogram_fail_series = new Series();
                histogram_fail_series.ChartType = SeriesChartType.Bar;
                histogram_fail_series.Color = Color.Red;
                histogram_fail_series["PointWidth"] = "1";
                histogram_fail_series.SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                histogram_fail_series.Points.Add(new DataPoint(j, frequencies[i]));
                histogram_fail_series.Label = "P = " + j + " freq = " + frequencies[i].ToString();
                histogram_attacks.Series.Add(histogram_fail_series);
                histogram_attacks.Update();
                myRefresh();
            }
            

            status1 = false;
        }



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.panel1.BringToFront();
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = e.Location;
            }

            if (e.Button == MouseButtons.Right)
            {
                isResizing = true;
                resizeStart = e.Location;
                originalSize = this.panel1.Size;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - lastCursorPosition.X;
                int deltaY = e.Y - lastCursorPosition.Y;
                panel1.Left += deltaX;
                panel1.Top += deltaY;
            }

            if (isResizing)
            {
                int deltaX = e.X - resizeStart.X;
                int deltaY = e.Y - resizeStart.Y;

                // Calcola la nuova dimensione del pannello in base allo spostamento del mouse.
                int newWidth = originalSize.Width + deltaX;
                int newHeight = originalSize.Height + deltaY;

                if (newWidth > 0 && newHeight > 0)
                {
                    this.panel1.Size = new Size(newWidth, newHeight);
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            isResizing = false;

        }
    }
}