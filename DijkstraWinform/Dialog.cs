using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DijkstraWinform
{
    public partial class Dialog : Form
    {
        public int Weight { get; set; }
        public int Point1 { get; set; }
        public int Point2 { get; set; }

        public Dialog()
        {
            InitializeComponent();
        }

        private void weightBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(weightTxt.Text, out int weight) && int.TryParse(point1Txt.Text, out int point1) &&int.TryParse(point2Txt.Text, out int point2))  
            {
                Weight = weight;
                Point1 = point1;
                Point2 = point2;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Hãy nhập giá trị số nguyên", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
