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
            // 
            // cancel
            // 
            cancel.Location = new Point(241, 197);
            cancel.Name = "cancel";
            cancel.Size = new Size(118, 62);
            cancel.TabIndex = 1;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(118, 35);
            label1.Name = "label1";
            label1.Size = new Size(201, 38);
            label1.TabIndex = 2;
            label1.Text = "Nhập trọng số:";
            // 
            // weightTxt
            // 
            weightTxt.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            weightTxt.Location = new Point(154, 102);
            weightTxt.Name = "weightTxt";
            weightTxt.Size = new Size(125, 43);
            weightTxt.TabIndex = 3;
            // 
            // Dialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 294);
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
    }
}