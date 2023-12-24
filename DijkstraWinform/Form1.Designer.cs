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
            panel6 = new Panel();
            panel2 = new Panel();
            algorithm = new Label();
            find = new Button();
            floydAlgorithm = new RadioButton();
            dijkstraAlgorithm = new RadioButton();
            panel8 = new Panel();
            endNode = new TextBox();
            startNode = new TextBox();
            endNodeLabel = new Label();
            startNodeLabel = new Label();
            panel4 = new Panel();
            graphBtn = new Button();
            createGraph = new Label();
            panel1 = new Panel();
            confirmBtn = new Button();
            countMatrix = new TextBox();
            nodeCount = new Label();
            panel3 = new Panel();
            cost = new Label();
            CostLabel = new Label();
            result = new Label();
            resultLabel = new Label();
            panel5 = new Panel();
            pictureBox1 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            panel7 = new Panel();
            importFile = new Button();
            showText = new TextBox();
            ptnMatrix.SuspendLayout();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // ptnMatrix
            // 
            ptnMatrix.BackColor = SystemColors.Control;
            ptnMatrix.BorderStyle = BorderStyle.FixedSingle;
            ptnMatrix.Controls.Add(panel6);
            ptnMatrix.Location = new Point(12, 12);
            ptnMatrix.Name = "ptnMatrix";
            ptnMatrix.Size = new Size(525, 552);
            ptnMatrix.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Location = new Point(0, 654);
            panel6.Name = "panel6";
            panel6.Size = new Size(525, 49);
            panel6.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(algorithm);
            panel2.Controls.Add(find);
            panel2.Controls.Add(floydAlgorithm);
            panel2.Controls.Add(dijkstraAlgorithm);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(543, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 552);
            panel2.TabIndex = 1;
            // 
            // algorithm
            // 
            algorithm.AutoSize = true;
            algorithm.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            algorithm.Location = new Point(9, 328);
            algorithm.Name = "algorithm";
            algorithm.Size = new Size(129, 31);
            algorithm.TabIndex = 6;
            algorithm.Text = "Thuật toán:";
            // 
            // find
            // 
            find.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            find.Location = new Point(87, 437);
            find.Name = "find";
            find.Size = new Size(149, 67);
            find.TabIndex = 5;
            find.Text = "Tìm";
            find.UseVisualStyleBackColor = true;
            find.Click += find_Click;
            // 
            // floydAlgorithm
            // 
            floydAlgorithm.AutoSize = true;
            floydAlgorithm.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            floydAlgorithm.Location = new Point(121, 374);
            floydAlgorithm.Name = "floydAlgorithm";
            floydAlgorithm.Size = new Size(186, 35);
            floydAlgorithm.TabIndex = 4;
            floydAlgorithm.TabStop = true;
            floydAlgorithm.Text = "Floyd-Warshall";
            floydAlgorithm.UseVisualStyleBackColor = true;
            // 
            // dijkstraAlgorithm
            // 
            dijkstraAlgorithm.AutoSize = true;
            dijkstraAlgorithm.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            dijkstraAlgorithm.Location = new Point(9, 374);
            dijkstraAlgorithm.Name = "dijkstraAlgorithm";
            dijkstraAlgorithm.Size = new Size(112, 35);
            dijkstraAlgorithm.TabIndex = 3;
            dijkstraAlgorithm.TabStop = true;
            dijkstraAlgorithm.Text = "Dijkstra";
            dijkstraAlgorithm.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(endNode);
            panel8.Controls.Add(startNode);
            panel8.Controls.Add(endNodeLabel);
            panel8.Controls.Add(startNodeLabel);
            panel8.Location = new Point(-1, 178);
            panel8.Name = "panel8";
            panel8.Size = new Size(311, 139);
            panel8.TabIndex = 2;
            // 
            // endNode
            // 
            endNode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            endNode.Location = new Point(180, 77);
            endNode.Name = "endNode";
            endNode.Size = new Size(56, 34);
            endNode.TabIndex = 7;
            // 
            // startNode
            // 
            startNode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            startNode.Location = new Point(180, 16);
            startNode.Name = "startNode";
            startNode.Size = new Size(56, 34);
            startNode.TabIndex = 6;
            // 
            // endNodeLabel
            // 
            endNodeLabel.AutoSize = true;
            endNodeLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            endNodeLabel.Location = new Point(3, 77);
            endNodeLabel.Name = "endNodeLabel";
            endNodeLabel.Size = new Size(161, 31);
            endNodeLabel.TabIndex = 5;
            endNodeLabel.Text = "Điểm kết thúc:";
            // 
            // startNodeLabel
            // 
            startNodeLabel.AutoSize = true;
            startNodeLabel.BackColor = Color.Transparent;
            startNodeLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            startNodeLabel.Location = new Point(6, 17);
            startNodeLabel.Name = "startNodeLabel";
            startNodeLabel.Size = new Size(158, 31);
            startNodeLabel.TabIndex = 4;
            startNodeLabel.Text = "Điểm bắt đầu:";
            // 
            // panel4
            // 
            panel4.Controls.Add(graphBtn);
            panel4.Controls.Add(createGraph);
            panel4.Location = new Point(-1, 89);
            panel4.Name = "panel4";
            panel4.Size = new Size(312, 83);
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
            createGraph.Location = new Point(4, 27);
            createGraph.Name = "createGraph";
            createGraph.Size = new Size(117, 31);
            createGraph.TabIndex = 0;
            createGraph.Text = "Tạo đồ thị";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(confirmBtn);
            panel1.Controls.Add(countMatrix);
            panel1.Controls.Add(nodeCount);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 84);
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
            nodeCount.Location = new Point(6, 22);
            nodeCount.Name = "nodeCount";
            nodeCount.Size = new Size(151, 31);
            nodeCount.TabIndex = 0;
            nodeCount.Text = "Số lượng nút:";
            nodeCount.Click += nodeCount_Click;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(cost);
            panel3.Controls.Add(CostLabel);
            panel3.Controls.Add(result);
            panel3.Controls.Add(resultLabel);
            panel3.Location = new Point(543, 586);
            panel3.Name = "panel3";
            panel3.Size = new Size(939, 105);
            panel3.TabIndex = 2;
            // 
            // cost
            // 
            cost.AutoSize = true;
            cost.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            cost.Location = new Point(121, 12);
            cost.Name = "cost";
            cost.Size = new Size(0, 38);
            cost.TabIndex = 10;
            // 
            // CostLabel
            // 
            CostLabel.AutoSize = true;
            CostLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            CostLabel.Location = new Point(10, 12);
            CostLabel.Name = "CostLabel";
            CostLabel.Size = new Size(110, 38);
            CostLabel.TabIndex = 9;
            CostLabel.Text = "Chi phí:";
            // 
            // result
            // 
            result.AutoSize = true;
            result.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            result.Location = new Point(308, 50);
            result.Name = "result";
            result.Size = new Size(0, 38);
            result.TabIndex = 8;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            resultLabel.Location = new Point(10, 50);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(301, 38);
            resultLabel.TabIndex = 7;
            resultLabel.Text = "Đường đi ngắn nhất là:";
            // 
            // panel5
            // 
            panel5.Controls.Add(pictureBox1);
            panel5.Location = new Point(861, 12);
            panel5.Name = "panel5";
            panel5.Size = new Size(621, 552);
            panel5.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(615, 549);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(importFile);
            panel7.Controls.Add(showText);
            panel7.Location = new Point(12, 586);
            panel7.Name = "panel7";
            panel7.Size = new Size(525, 105);
            panel7.TabIndex = 4;
            // 
            // importFile
            // 
            importFile.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            importFile.Location = new Point(360, 36);
            importFile.Name = "importFile";
            importFile.Size = new Size(137, 38);
            importFile.TabIndex = 1;
            importFile.Text = "Tải tệp lên";
            importFile.UseVisualStyleBackColor = true;
            importFile.Click += importFile_Click;
            // 
            // showText
            // 
            showText.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            showText.Location = new Point(16, 36);
            showText.Name = "showText";
            showText.Size = new Size(299, 27);
            showText.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1517, 727);
            Controls.Add(panel7);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(ptnMatrix);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ptnMatrix.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
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
        private Panel panel5;
        private PictureBox pictureBox1;
        private Panel panel6;
        private OpenFileDialog openFileDialog1;
        private Panel panel7;
        private Button importFile;
        private TextBox showText;
        private Panel panel8;
        private Label startNodeLabel;
        private Label endNodeLabel;
        private TextBox endNode;
        private TextBox startNode;
        private RadioButton floydAlgorithm;
        private RadioButton dijkstraAlgorithm;
        private Button find;
        private Label algorithm;
        private Label result;
        private Label resultLabel;
        private Label CostLabel;
        private Label cost;
    }
}