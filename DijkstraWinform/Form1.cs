using System.ComponentModel;
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
                    if (i == j)
                    {
                        textBox.Text = "0";
                    }
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
            }
        }
    }
}