namespace DijkstraWinform
{
    partial class Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            weightBtn = new Button();
            cancel = new Button();
            label1 = new Label();
            weightTxt = new TextBox();
            point1 = new Label();
            point2 = new Label();
            point2Txt = new TextBox();
            point1Txt = new TextBox();
            SuspendLayout();
            // 
            // weightBtn
            // 
            weightBtn.Location = new Point(58, 197);
            weightBtn.Name = "weightBtn";
            weightBtn.Size = new Size(118, 62);
            weightBtn.TabIndex = 0;
            weightBtn.Text = "OK";
            weightBtn.UseVisualStyleBackColor = true;
            weightBtn.Click += weightBtn_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(230, 197);
            cancel.Name = "cancel";
            cancel.Size = new Size(118, 62);
            cancel.TabIndex = 1;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            cancel.Click += cancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(58, 134);
            label1.Name = "label1";
            label1.Size = new Size(166, 31);
            label1.TabIndex = 2;
            label1.Text = "Nhập trọng số:";
            // 
            // weightTxt
            // 
            weightTxt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            weightTxt.Location = new Point(257, 131);
            weightTxt.Name = "weightTxt";
            weightTxt.Size = new Size(91, 38);
            weightTxt.TabIndex = 3;
            // 
            // point1
            // 
            point1.AutoSize = true;
            point1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            point1.Location = new Point(58, 31);
            point1.Name = "point1";
            point1.Size = new Size(151, 31);
            point1.TabIndex = 4;
            point1.Text = "Nhập điểm 1:";
            // 
            // point2
            // 
            point2.AutoSize = true;
            point2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            point2.Location = new Point(58, 84);
            point2.Name = "point2";
            point2.Size = new Size(151, 31);
            point2.TabIndex = 5;
            point2.Text = "Nhập điểm 2:";
            // 
            // point2Txt
            // 
            point2Txt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            point2Txt.Location = new Point(257, 77);
            point2Txt.Name = "point2Txt";
            point2Txt.Size = new Size(91, 38);
            point2Txt.TabIndex = 6;
            // 
            // point1Txt
            // 
            point1Txt.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            point1Txt.Location = new Point(257, 24);
            point1Txt.Name = "point1Txt";
            point1Txt.Size = new Size(91, 38);
            point1Txt.TabIndex = 7;
            // 
            // Dialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 294);
            Controls.Add(point1Txt);
            Controls.Add(point2Txt);
            Controls.Add(point2);
            Controls.Add(point1);
            Controls.Add(weightTxt);
            Controls.Add(label1);
            Controls.Add(cancel);
            Controls.Add(weightBtn);
            Name = "Dialog";
            Text = "Dialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button weightBtn;
        private Button cancel;
        private Label label1;
        public TextBox weightTxt;
        private Label point1;
        private Label point2;
        public TextBox point2Txt;
        public TextBox point1Txt;
    }
}