using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace DijkstraWinform
{
    public partial class Form1 : Form
    {
        private TextBox[,] textBoxMatrix; // Matrix to hold TextBox controls
        private Dijkstra dijkstra;
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
        }
        public void LoadMatrix(int n)
        {
            ptnMatrix.Controls.Clear();
            textBoxMatrix = new TextBox[10, 10]; // Initialize the matrix

            Control oldControl = new Control() { Width = 0, Height = 0, Location = new Point(0, 0) };

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TextBox textBox = new TextBox() { Width = 50, Height = 50 };
                    textBox.Location = new Point(oldControl.Location.X + oldControl.Width, oldControl.Location.Y);
                    // Set the value to 0 for the main diagonal
                    textBox.Text = "0";

                    ptnMatrix.Controls.Add(textBox);
                    textBoxMatrix[i, j] = textBox; // Store the TextBox in the matrix
                    oldControl = textBox; // Use TextBox as the reference for the next iteration
                }
                oldControl = new Control() { Width = 0, Height = 0, Location = new Point(0, oldControl.Location.Y + 50) };
            }
        }

        // Example method to retrieve values from TextBox controls
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

        private void countMatrix_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the value from textbox1
            int n = int.Parse(countMatrix.Text);
            // Initialize the dijkstra object
            dijkstra = new Dijkstra(n);
            // Set the matrix values using the entered value
            LoadMatrix(n);
        }

        private void nodeCount_Click(object sender, EventArgs e)
        {

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
            Console.WriteLine("Validating event triggered"); // Check if this line is printed
            int n;
            if (!int.TryParse(countMatrix.Text, out n) || n < 1 || n > 10)
            {
                countMatrix.Text = "10";
            }
        }

        private void graphBtn_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(countMatrix.Text, out n) && n > 0 && n <= 10)
            {

                if (textBoxMatrix == null)
                {
                    LoadMatrix(n);
                }

                GetMatrixValues(n);
                var graph = dijkstra.GetGraph();

                // Draw the graph
                DrawGraph(graph);
            }
            else
            {
                MessageBox.Show("Invalid node count. Please enter a valid node count (1-10).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawGraph(Dictionary<int, List<Tuple<int, int>>> graph)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);

                int radius = 25;
                int padding = 10; // Adjust the padding between circles
                Random random = new Random();
                Dictionary<int, Point> vertexPositions = new Dictionary<int, Point>();
                HashSet<Tuple<int, int>> processedEdges = new HashSet<Tuple<int, int>>();

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

                    g.FillEllipse(Brushes.LightSkyBlue, x - radius, y - radius, 2 * radius, 2 * radius);

                    // Increase the font size for vertex labels
                    Font labelFont = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);

                    // Center the label within the circle
                    int labelX = x - (int)(g.MeasureString(kvp.Key.ToString(), labelFont).Width / 2);
                    int labelY = y - (int)(g.MeasureString(kvp.Key.ToString(), labelFont).Height / 2);

                    g.DrawString(kvp.Key.ToString(), labelFont, Brushes.White, labelX, labelY);

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

                        // Ensure that we only process each undirected edge once
                        if (sourceVertex < targetVertex)
                        {
                            Point targetPoint = vertexPositions[targetVertex];
                            int weight = edge.Item2;

                            Tuple<int, int> edgeTuple = new Tuple<int, int>(sourceVertex, targetVertex);

                            if (processedEdges.Contains(edgeTuple))
                                continue;

                            processedEdges.Add(edgeTuple);

                            // Increase the line width for undirected edges
                            Pen edgePen = new Pen(Color.Black, 2);

                            // Calculate the position of the label
                            int labelX = (sourcePoint.X + targetPoint.X) / 2;
                            int labelY = (sourcePoint.Y + targetPoint.Y) / 2;

                            // Calculate the slope of the line
                            double slope = (double)(targetPoint.Y - sourcePoint.Y) / (targetPoint.X - sourcePoint.X);

                            // Draw a line for undirected edges
                            g.DrawLine(edgePen, sourcePoint, targetPoint);

                            // Increase the font size for edge weights
                            Font weightFont = new Font(DefaultFont.FontFamily, 14, FontStyle.Regular); // Adjust the font size here

                            // Introduce an offset to increase the distance
                            int offset = 20;

                            // Adjust the label position based on the slope and offset
                            if (slope >= -1 && slope <= 1)
                            {
                                // Horizontal or near-horizontal line
                                labelY -= (int)(g.MeasureString(weight.ToString(), weightFont).Height / 2) + offset;
                            }
                            else
                            {
                                // Vertical or near-vertical line
                                labelX -= (int)(g.MeasureString(weight.ToString(), weightFont).Width / 2) + offset;
                            }

                            g.DrawString(weight.ToString(), weightFont, Brushes.Black, labelX, labelY);
                        }
                    }
                }

                // Bring the circles and labels to the front
                foreach (var kvp in graph)
                {
                    double angle = i * angleIncrement;
                    int x = (int)(centerX + Math.Cos(angle) * (pictureBox1.Width / 3));
                    int y = (int)(centerY + Math.Sin(angle) * (pictureBox1.Height / 3));

                    g.FillEllipse(Brushes.LightSkyBlue, x - radius, y - radius, 2 * radius, 2 * radius);

                    // Increase the font size for vertex labels
                    Font labelFont = new Font(DefaultFont.FontFamily, 12, FontStyle.Regular);

                    // Center the label within the circle
                    int labelX = x - (int)(g.MeasureString(kvp.Key.ToString(), labelFont).Width / 2);
                    int labelY = y - (int)(g.MeasureString(kvp.Key.ToString(), labelFont).Height / 2);

                    g.DrawString(kvp.Key.ToString(), labelFont, Brushes.White, labelX, labelY);

                    i++;
                }
            }
        }




        private void importFile_Click(object sender, EventArgs e)
        {
            // Show the OpenFileDialog to select a file
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
                    MessageBox.Show($"Error loading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length >= 1 && int.TryParse(lines[0], out int n))
            {
                countMatrix.Text = n.ToString();
                dijkstra = new Dijkstra(n);
                LoadMatrix(n);
                for (int i = 1; i <= n && i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(' ');
                    for (int j = 0; j < n && j < values.Length; j++)
                    {
                        if (int.TryParse(values[j], out int weight))
                        {
                            dijkstra.createEdge(i - 1, j, weight);
                            textBoxMatrix[i - 1, j].Text = weight.ToString();
                        }
                    }
                }

                // Set the text of showText to the file path
                showText.Text = filePath;
            }
            else
            {
                MessageBox.Show("Invalid file format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void find_Click(object sender, EventArgs e)
        {

        }


    }
}