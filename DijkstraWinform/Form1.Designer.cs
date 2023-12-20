namespace DijkstraWinform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ptnMatrix = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            graphBtn = new Button();
            createGraph = new Label();
            panel1 = new Panel();
            confirmBtn = new Button();
            countMatrix = new TextBox();
            nodeCount = new Label();
            panel3 = new Panel();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // ptnMatrix
            // 
            ptnMatrix.Location = new Point(12, 12);
            ptnMatrix.Name = "ptnMatrix";
            ptnMatrix.Size = new Size(525, 703);
            ptnMatrix.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(543, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(962, 441);
            panel2.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(graphBtn);
            panel4.Controls.Add(createGraph);
            panel4.Location = new Point(3, 89);
            panel4.Name = "panel4";
            panel4.Size = new Size(233, 83);
            panel4.TabIndex = 1;
            // 
            // graphBtn
            // 
            graphBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            graphBtn.Location = new Point(151, 27);
            graphBtn.Name = "graphBtn";
            graphBtn.Size = new Size(60, 33);
            graphBtn.TabIndex = 3;
            graphBtn.Text = "OK";
            graphBtn.UseVisualStyleBackColor = true;
            graphBtn.Click += graphBtn_Click;
            // 
            // createGraph
            // 
            createGraph.AutoSize = true;
            createGraph.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            createGraph.Location = new Point(3, 27);
            createGraph.Name = "createGraph";
            createGraph.Size = new Size(117, 31);
            createGraph.TabIndex = 0;
            createGraph.Text = "Tạo đồ thị";
            // 
            // panel1
            // 
            panel1.Controls.Add(confirmBtn);
            panel1.Controls.Add(countMatrix);
            panel1.Controls.Add(nodeCount);
            panel1.Location = new Point(3, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(303, 71);
            panel1.TabIndex = 0;
            // 
            // confirmBtn
            // 
            confirmBtn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            confirmBtn.Location = new Point(227, 19);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(60, 33);
            confirmBtn.TabIndex = 2;
            confirmBtn.Text = "OK";
            confirmBtn.UseVisualStyleBackColor = true;
            confirmBtn.Click += button1_Click;
            // 
            // countMatrix
            // 
            countMatrix.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            countMatrix.Location = new Point(155, 19);
            countMatrix.Name = "countMatrix";
            countMatrix.Size = new Size(56, 34);
            countMatrix.TabIndex = 1;
            countMatrix.TextChanged += countMatrix_TextChanged;
            // 
            // nodeCount
            // 
            nodeCount.AutoSize = true;
            nodeCount.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            nodeCount.Location = new Point(3, 22);
            nodeCount.Name = "nodeCount";
            nodeCount.Size = new Size(146, 31);
            nodeCount.TabIndex = 0;
            nodeCount.Text = "Số lượng nút";
            nodeCount.Click += nodeCount_Click;
            // 
            // panel3
            // 
            panel3.Location = new Point(543, 459);
            panel3.Name = "panel3";
            panel3.Size = new Size(482, 256);
            panel3.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1517, 727);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(ptnMatrix);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel ptnMatrix;
        private Panel panel2;
        private Panel panel3;
        private Panel panel1;
        private Label nodeCount;
        private TextBox countMatrix;
        private Button confirmBtn;
        private Panel panel4;
        private Label createGraph;
        private Button graphBtn;
    }
}