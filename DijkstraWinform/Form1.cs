using System.ComponentModel;
using System.Windows.Forms;

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
                GetMatrixValues(n);
                // Now, the matrix values are stored in the dijkstra object or perform any other action as needed
                // Assuming dijkstra has a method to get graph information
                var graph = dijkstra.GetGraph(); // Replace with the appropriate method

                // Draw the graph
                DrawGraph(graph);
            }
        }
        private void DrawGraph(Dictionary<int, List<Tuple<int, int>>> graph)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);

                int radius = 20;
                Random random = new Random();
                Dictionary<int, Point> vertexPositions = new Dictionary<int, Point>();

                foreach (var kvp in graph)
                {
                    int x = random.Next(20, pictureBox1.Width - 20);
                    int y = random.Next(20, pictureBox1.Height - 20);

                    g.FillEllipse(Brushes.LightSkyBlue, x - radius, y - radius, 2 * radius, 2 * radius);
                    g.DrawString(kvp.Key.ToString(), DefaultFont, Brushes.White, x - 6, y - 6);

                    vertexPositions.Add(kvp.Key, new Point(x, y));
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

                        if (weight == 0)
                            continue;

                        // Check if the edge is undirected (0-2)
                        if ((sourceVertex == 0 && targetVertex == 2) || (sourceVertex == 2 && targetVertex == 0))
                        {
                            g.DrawLine(Pens.Black, sourcePoint, targetPoint);
                        }
                        else
                        {
                            // Draw an arrow for directed edges
                            DrawArrow(g, Pens.Black, sourcePoint, targetPoint, weight);
                        }

                        int labelX = (sourcePoint.X + targetPoint.X) / 2;
                        int labelY = (sourcePoint.Y + targetPoint.Y) / 2;

                        labelX -= (int)(g.MeasureString(weight.ToString(), DefaultFont).Width / 2);
                        labelY -= (int)(g.MeasureString(weight.ToString(), DefaultFont).Height / 2);

                        g.DrawString(weight.ToString(), DefaultFont, Brushes.Black, labelX, labelY);
                    }
                }
            }
        }







        private void DrawArrow(Graphics g, Pen pen, Point source, Point target, int weight)
        {
            // Draw a line
            g.DrawLine(pen, source, target);

            // Calculate the angle of the arrow
            double angle = Math.Atan2(target.Y - source.Y, target.X - source.X);

            // Set the arrowhead size
            int arrowSize = 15;

            // Calculate the position of the arrowhead
            double arrowX = target.X - arrowSize * Math.Cos(angle);
            double arrowY = target.Y - arrowSize * Math.Sin(angle);

            // Calculate points for the arrowhead
            double angle1 = angle + Math.PI + 0.3; // 0.3 is an arbitrary angle for the arrowhead
            double angle2 = angle + Math.PI - 0.3;
            int x1 = (int)(arrowX + arrowSize * Math.Cos(angle1));
            int y1 = (int)(arrowY + arrowSize * Math.Sin(angle1));
            int x2 = (int)(arrowX + arrowSize * Math.Cos(angle2));
            int y2 = (int)(arrowY + arrowSize * Math.Sin(angle2));

            // Draw the arrowhead
            g.DrawLine(pen, target, new Point(x1, y1));
            g.DrawLine(pen, target, new Point(x2, y2));

            // Draw the weight of the edge
            int labelX = (source.X + target.X) / 2;
            int labelY = (source.Y + target.Y) / 2;

            // Adjust the position of the weight label
            labelX -= (int)(g.MeasureString(weight.ToString(), DefaultFont).Width / 2);
            labelY -= (int)(g.MeasureString(weight.ToString(), DefaultFont).Height / 2);

            g.DrawString(weight.ToString(), DefaultFont, Brushes.Black, labelX, labelY);
        }

    }
}