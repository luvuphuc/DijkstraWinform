﻿using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Xml;

namespace DijkstraWinform
{
    public partial class Form1 : Form
    {
        private TextBox[,] textBoxMatrix;
        private Dijkstra dijkstra;
        private int dem = 0;
        private List<Point> nodeLocations = new List<Point>();
        public Form1()
        {
            InitializeComponent();
            countMatrix.Validating += countMatrix_Validating;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox1.CreateGraphics();
            pictureBox1.BackColor = Color.White;
            showText.Text = "Choose file have .txt";
            showText.ReadOnly = true;
            pictureBox1.MouseClick += pictureBox1_Click;
        }
        public void LoadMatrix(int n)
        {
            ptnMatrix.Controls.Clear();
            textBoxMatrix = new TextBox[10, 10]; // khoi tao ma tran

            Control oldControl = new Control() { Width = 0, Height = 0, Location = new Point(0, 0) };

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //do dai cho textbox
                    TextBox textBox = new TextBox() { Width = 50, Height = 50 };
                    textBox.Location = new Point(oldControl.Location.X + oldControl.Width, oldControl.Location.Y);
                    //hien thi gia tri cho tung o textbox
                    textBox.Text = "0";

                    ptnMatrix.Controls.Add(textBox);
                    textBoxMatrix[i, j] = textBox; // luu gia tri
                    oldControl = textBox;
                }
                oldControl = new Control() { Width = 0, Height = 0, Location = new Point(0, oldControl.Location.Y + 50) };
            }
        }

        //lay gia tri va tao ma tran 
        private void GetMatrixValues(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string value = textBoxMatrix[i, j].Text;
                    int weight = int.Parse(value);
                    dijkstra.createEdge(i, j, weight);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //xu ly khi click vao nut ok cua tao ma tran ben trai
            int n = int.Parse(countMatrix.Text);
            dijkstra = new Dijkstra(n);
            LoadMatrix(n);
        }
        private void countMatrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void countMatrix_Validating(object sender, CancelEventArgs e)
        {
            int n;
            if (!int.TryParse(countMatrix.Text, out n) || n < 1 || n > 10)
            {
                countMatrix.Text = "10";
            }
        }
        //xu ly khi click vao nut tao ma tran
        private void graphBtn_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(countMatrix.Text, out n) && n > 0 && n <= 10)
            {

                if (textBoxMatrix == null)
                {
                    LoadMatrix(n);
                }
                if (dijkstra == null)
                {
                    dijkstra = new Dijkstra(n);
                }
                GetMatrixValues(n);
                var graph = dijkstra.GetGraph();
                List<int> shortestPath = null;
                DrawGraph(graph, shortestPath);
            }
            else
            {
                MessageBox.Show("Số lượng điểm cần phải từ 1-10!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawGraph(Dictionary<int, List<Tuple<int, int>>> graph, List<int> shortestPath)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);

                int radius = 25;    //ban kinh cua nut
                int padding = 10;
                Dictionary<int, Point> vertexPositions = new Dictionary<int, Point>();  //luu cac dinh
                HashSet<Tuple<int, int>> processedEdges = new HashSet<Tuple<int, int>>();   //luu cac canh
                int circleCount = graph.Count;
                int centerX = pictureBox1.Width / 2;
                int centerY = pictureBox1.Height / 2;
                double angleIncrement = 2 * Math.PI / circleCount;

                int i = 0;

                foreach (var kvp in graph)
                {
                    double angle = i * angleIncrement;
                    int x = (int)(centerX + Math.Cos(angle) * (pictureBox1.Width / 3));
                    int y = (int)(centerY + Math.Sin(angle) * (pictureBox1.Height / 3));

                    //ve vong tron
                    Brush nodeBrush = Brushes.LightSkyBlue;
                    g.FillEllipse(nodeBrush, x - radius, y - radius, 2 * radius, 2 * radius);

                    //ve so thu tu
                    Font labelFont = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);
                    int labelX = x - (int)(g.MeasureString(kvp.Key.ToString(), labelFont).Width / 2);
                    int labelY = y - (int)(g.MeasureString(kvp.Key.ToString(), labelFont).Height / 2);

                    g.DrawString(kvp.Key.ToString(), labelFont, Brushes.White, labelX, labelY);
                    //luu vi tri cac nut
                    vertexPositions.Add(kvp.Key, new Point(x, y));
                    i++;
                }

                foreach (var kvp in graph)
                {
                    int sourceVertex = kvp.Key;
                    Point sourcePoint = vertexPositions[sourceVertex];

                    foreach (var edge in kvp.Value)
                    {
                        int targetVertex = edge.Item1;
                        Point targetPoint = vertexPositions[targetVertex];
                        int weight = edge.Item2;
                        Tuple<int, int> edgeTuple = new Tuple<int, int>(sourceVertex, targetVertex);

                        //ve duong noi
                        g.DrawLine(new Pen(Color.Black, 2), sourcePoint, targetPoint);
                        processedEdges.Add(edgeTuple);
                        //ve trong so
                        Font weightFont = new Font(DefaultFont.FontFamily, 14, FontStyle.Regular);
                        int offset = 20;
                        int labelX = (sourcePoint.X + targetPoint.X) / 2;
                        int labelY = (sourcePoint.Y + targetPoint.Y) / 2;

                        double slope = (double)(targetPoint.Y - sourcePoint.Y) / (targetPoint.X - sourcePoint.X);
                        //dat vi tri trong so
                        if (slope >= -1 && slope <= 1)
                        {
                            labelY -= (int)(g.MeasureString(weight.ToString(), weightFont).Height / 2) + offset;
                        }
                        else
                        {
                            labelX -= (int)(g.MeasureString(weight.ToString(), weightFont).Width / 2) + offset;
                        }

                        g.DrawString(weight.ToString(), weightFont, Brushes.Black, labelX, labelY);
                    }
                }

                // ve nut them 1 lan nua de layer nut len duong thang
                foreach (var kvp in graph)
                {
                    double angle = i * angleIncrement;
                    int x = (int)(centerX + Math.Cos(angle) * (pictureBox1.Width / 3));
                    int y = (int)(centerY + Math.Sin(angle) * (pictureBox1.Height / 3));

                    Brush nodeBrush = Brushes.LightSkyBlue;
                    g.FillEllipse(nodeBrush, x - radius, y - radius, 2 * radius, 2 * radius);

                    Font labelFont = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);
                    int labelX = x - (int)(g.MeasureString(kvp.Key.ToString(), labelFont).Width / 2);
                    int labelY = y - (int)(g.MeasureString(kvp.Key.ToString(), labelFont).Height / 2);

                    g.DrawString(kvp.Key.ToString(), labelFont, Brushes.White, labelX, labelY);
                    nodeLocations.Add(new Point(x, y));
                    i++;
                }
            }
        }

        // xu ly file
        private void importFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Select a text file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LoadFromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tải file!!!! {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //xu ly doc file
        private void LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length >= 1 && int.TryParse(lines[0], out int n))
            {
                countMatrix.Text = n.ToString();    //so luong diem
                dijkstra = new Dijkstra(n);
                LoadMatrix(n);
                for (int i = 1; i <= n && i < lines.Length; i++)    //can bat dau dong 1 vi dong 0 la so luong
                {
                    string[] values = lines[i].Split(' ');
                    for (int j = 0; j < n && j < values.Length; j++)
                    {
                        //kiem tra dk cho gtri ma tran
                        if (int.TryParse(values[j], out int weight))
                        {
                            dijkstra.createEdge(i - 1, j, weight);
                            textBoxMatrix[i - 1, j].Text = weight.ToString();
                        }
                    }
                }

                showText.Text = filePath;
            }
            else
            {
                MessageBox.Show("File không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void find_Click(object sender, EventArgs e)
        {
            int nodeCount;
            if (int.TryParse(countMatrix.Text, out nodeCount) && nodeCount > 0 && nodeCount <= 10)
            {
                if (textBoxMatrix == null)
                {
                    LoadMatrix(nodeCount);
                }

                //khoi tao dijkstra neu ko co dijkstra (hdt)
                if (dijkstra == null)
                {
                    dijkstra = new Dijkstra(int.Parse(countMatrix.Text));
                }

                GetMatrixValues(nodeCount);
                var graph = dijkstra.GetGraph();

                //lay gia tri diem dau, diem cuoi
                int startNodeValue, endNodeValue;
                if (int.TryParse(startNode.Text, out startNodeValue) && int.TryParse(endNode.Text, out endNodeValue))
                {
                    //kiem tra diem dau, cuoi hop le hay khong
                    if (startNodeValue >= 0 && startNodeValue < nodeCount && endNodeValue >= 0 && endNodeValue < nodeCount)
                    {
                        //xu ly dijkstra
                        if (dijkstraAlgorithm.Checked)
                        {

                            List<int> shortestPath;
                            int pathCost;

                            dijkstra.DijkstraAlgorithm(startNodeValue, endNodeValue, out shortestPath, out pathCost);
                            if (shortestPath != null)
                            {
                                // Hien thi ket qua khi co duong di ngan nhat
                                result.Text = $"{string.Join(" -> ", shortestPath)}";
                                cost.Text = $"{pathCost}";

                                // doi mau cac diem va duong di
                                using (Graphics g = pictureBox1.CreateGraphics())
                                {
                                    int radius = 25;

                                    // giu nguyen mau cho cac duong di ko thuoc duong di ngan nhat
                                    foreach (var entry in graph)
                                    {
                                        int sourceVertex = entry.Key;
                                        List<Tuple<int, int>> edges = entry.Value;

                                        foreach (var edge in edges)
                                        {
                                            int targetVertex = edge.Item1;

                                            Point sourcePoint = nodeLocations[sourceVertex];
                                            Point targetPoint = nodeLocations[targetVertex];

                                            Tuple<int, int> edgeTuple = new Tuple<int, int>(sourceVertex, targetVertex);

                                            if (!shortestPath.Contains(sourceVertex) || !shortestPath.Contains(targetVertex))
                                            {
                                                g.DrawLine(new Pen(Color.Black, 2), sourcePoint, targetPoint);
                                            }
                                        }
                                    }

                                    // Doi mau cac canh thuoc duong di
                                    for (int i = 0; i < shortestPath.Count - 1; i++)
                                    {
                                        int sourceVertex = shortestPath[i];
                                        int targetVertex = shortestPath[i + 1];
                                        Point sourcePoint = nodeLocations[sourceVertex];
                                        Point targetPoint = nodeLocations[targetVertex];

                                        Tuple<int, int> edgeTuple = new Tuple<int, int>(sourceVertex, targetVertex);

                                        g.DrawLine(new Pen(Color.Red, 2), sourcePoint, targetPoint);
                                    }

                                    // Doi mau cac nut thuoc duong di
                                    foreach (var vertex in shortestPath)
                                    {
                                        Point center = nodeLocations[vertex];
                                        Brush nodeBrush = Brushes.Red;
                                        g.FillEllipse(nodeBrush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

                                        Font labelFont = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);
                                        int labelX = center.X - (int)(g.MeasureString(vertex.ToString(), labelFont).Width / 2);
                                        int labelY = center.Y - (int)(g.MeasureString(vertex.ToString(), labelFont).Height / 2);
                                        g.DrawString(vertex.ToString(), labelFont, Brushes.White, labelX, labelY);
                                    }

                                    // Doi mau cac nut khong thuoc duong di
                                    for (int vertex = 0; vertex < nodeLocations.Count; vertex++)
                                    {
                                        if (!shortestPath.Contains(vertex))
                                        {
                                            Point center = nodeLocations[vertex];
                                            Brush nodeBrush = Brushes.LightSkyBlue;
                                            g.FillEllipse(nodeBrush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

                                            Font labelFont = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);
                                            int labelX = center.X - (int)(g.MeasureString(vertex.ToString(), labelFont).Width / 2);
                                            int labelY = center.Y - (int)(g.MeasureString(vertex.ToString(), labelFont).Height / 2);
                                            g.DrawString(vertex.ToString(), labelFont, Brushes.White, labelX, labelY);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                result.Text = $"Không có đường đi nào";
                                cost.Text = "0";
                            }

                        }
                        //floyd-washall
                        else if (floydAlgorithm.Checked)
                        {

                            List<int> shortestPath;
                            int pathCost;

                            dijkstra.FloydAlgorithm(startNodeValue, endNodeValue, out shortestPath, out pathCost);

                            // Hien thi ket qua khi co duong di ngan nhat
                            if (shortestPath != null)
                            {
                                result.Text = $"{string.Join(" -> ", shortestPath)}";
                                cost.Text = $"{pathCost}";

                                // doi mau cac diem va duong di
                                using (Graphics g = pictureBox1.CreateGraphics())
                                {
                                    int radius = 25;

                                    // giu nguyen mau cho cac duong di ko thuoc duong di ngan nhat
                                    foreach (var entry in graph)
                                    {
                                        int sourceVertex = entry.Key;
                                        List<Tuple<int, int>> edges = entry.Value;

                                        foreach (var edge in edges)
                                        {
                                            int targetVertex = edge.Item1;

                                            Point sourcePoint = nodeLocations[sourceVertex];
                                            Point targetPoint = nodeLocations[targetVertex];

                                            Tuple<int, int> edgeTuple = new Tuple<int, int>(sourceVertex, targetVertex);

                                            if (!shortestPath.Contains(sourceVertex) || !shortestPath.Contains(targetVertex))
                                            {
                                                g.DrawLine(new Pen(Color.Black, 2), sourcePoint, targetPoint);
                                            }
                                        }
                                    }

                                    // Doi mau cac canh thuoc duong di
                                    for (int i = 0; i < shortestPath.Count - 1; i++)
                                    {
                                        int sourceVertex = shortestPath[i];
                                        int targetVertex = shortestPath[i + 1];
                                        Point sourcePoint = nodeLocations[sourceVertex];
                                        Point targetPoint = nodeLocations[targetVertex];

                                        Tuple<int, int> edgeTuple = new Tuple<int, int>(sourceVertex, targetVertex);

                                        g.DrawLine(new Pen(Color.Red, 2), sourcePoint, targetPoint);
                                    }

                                    // Doi mau cac nut thuoc duong di
                                    foreach (var vertex in shortestPath)
                                    {
                                        Point center = nodeLocations[vertex];
                                        Brush nodeBrush = Brushes.Red;
                                        g.FillEllipse(nodeBrush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

                                        Font labelFont = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);
                                        int labelX = center.X - (int)(g.MeasureString(vertex.ToString(), labelFont).Width / 2);
                                        int labelY = center.Y - (int)(g.MeasureString(vertex.ToString(), labelFont).Height / 2);
                                        g.DrawString(vertex.ToString(), labelFont, Brushes.White, labelX, labelY);
                                    }

                                    // Doi mau cac nut khong thuoc duong di
                                    for (int vertex = 0; vertex < nodeLocations.Count; vertex++)
                                    {
                                        if (!shortestPath.Contains(vertex))
                                        {
                                            Point center = nodeLocations[vertex];
                                            Brush nodeBrush = Brushes.LightSkyBlue;
                                            g.FillEllipse(nodeBrush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
                                            Font labelFont = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);
                                            int labelX = center.X - (int)(g.MeasureString(vertex.ToString(), labelFont).Width / 2);
                                            int labelY = center.Y - (int)(g.MeasureString(vertex.ToString(), labelFont).Height / 2);
                                            g.DrawString(vertex.ToString(), labelFont, Brushes.White, labelX, labelY);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                result.Text = $"Không có đường đi nào";
                                cost.Text = "0";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Giá trị không hợp lệ. Hãy nhập giá trị khác.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Giá trị không hợp lệ. Hãy nhập giá trị khác.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Số lượng điểm cần phải từ 1-10!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //xu ly nut xoa do thi
        private void delGraph_Click(object sender, EventArgs e)
        {
            // Xoa do thi
            pictureBox1.CreateGraphics().Clear(Color.White);
            //xu ly cac bien
            dem = 0;
            nodeLocations.Clear();
            dijkstra = null;
            textBoxMatrix = null; ;
            ptnMatrix.Controls.Clear();
            Refresh();
        }
        //ham ve nut
        private void CreateNode(Point location)
        {
            int radius = 25;

            using (Graphics g = pictureBox1.CreateGraphics())
            {
                Brush nodeBrush = Brushes.LightSkyBlue;
                g.FillEllipse(nodeBrush, location.X - radius, location.Y - radius, 2 * radius, 2 * radius);

                Font labelFont = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);
                int labelX = location.X - (int)(g.MeasureString(dem.ToString(), labelFont).Width / 2);
                int labelY = location.Y - (int)(g.MeasureString(dem.ToString(), labelFont).Height / 2);

                g.DrawString(dem.ToString(), labelFont, Brushes.White, labelX, labelY);

                dem++;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dem < 10)
            {
                if (sender is Control control)
                {
                    // Lay toa do cua diem trong pictureBox1
                    Point clientPoint = control.PointToClient(Cursor.Position);
                    CreateNode(clientPoint);
                    countMatrix.Text = dem.ToString();
                    LoadMatrix(dem);

                    // Luu dia chi cua tung nut
                    nodeLocations.Add(clientPoint);
                }
            }
            else
            {
                MessageBox.Show("Tối đa chỉ được 10 điểm");
            }
        }

        private void connectPath_Click(object sender, EventArgs e)
        {
            int radius = 25;
            if (dem >= 2 && nodeLocations.Count >= 2)
            {
                int weight;

                using (Dialog dialog = new Dialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        weight = dialog.Weight;
                        int point1 = dialog.Point1;
                        int point2 = dialog.Point2;
                        using (Graphics g = pictureBox1.CreateGraphics())
                        {
                            //Luu vi tri 2 diem can noi
                            Point center1 = nodeLocations[point1];
                            Point center2 = nodeLocations[point2];

                            // ve duong thang
                            g.DrawLine(new Pen(Color.Black, 2), center1, center2);

                            // Ve lai diem t1
                            Brush nodeBrush1 = Brushes.LightSkyBlue;
                            g.FillEllipse(nodeBrush1, center1.X - radius, center1.Y - radius, 2 * radius, 2 * radius);
                            Font labelFont1 = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);
                            int labelX1 = center1.X - (int)(g.MeasureString(point1.ToString(), labelFont1).Width / 2);
                            int labelY1 = center1.Y - (int)(g.MeasureString(point1.ToString(), labelFont1).Height / 2);
                            g.DrawString(point1.ToString(), labelFont1, Brushes.White, labelX1, labelY1);

                            // Ve lai diem t2
                            Brush nodeBrush2 = Brushes.LightSkyBlue;
                            g.FillEllipse(nodeBrush2, center2.X - radius, center2.Y - radius, 2 * radius, 2 * radius);
                            Font labelFont2 = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);
                            int labelX2 = center2.X - (int)(g.MeasureString(point2.ToString(), labelFont2).Width / 2);
                            int labelY2 = center2.Y - (int)(g.MeasureString(point2.ToString(), labelFont2).Height / 2);
                            g.DrawString(point2.ToString(), labelFont2, Brushes.White, labelX2, labelY2);

                            textBoxMatrix[point1, point2].Text = weight.ToString();
                            textBoxMatrix[point2, point1].Text = weight.ToString();

                            // Ve trong so
                            Point labelLocation = new Point((center1.X + center2.X) / 2, (center1.Y + center2.Y) / 2);
                            Font weightFont = new Font(DefaultFont.FontFamily, 14, FontStyle.Regular);
                            g.DrawString(weight.ToString(), weightFont, Brushes.Black, labelLocation);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Cần ít nhất 2 điểm để nối", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}