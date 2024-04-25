namespace TestWinform.Properties
{
    partial class Form1
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
            Add_Book_DB = new Button();
            Book_AddNormal = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Person_AddDB = new Button();
            panel1 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            panel3 = new Panel();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // Add_Book_DB
            // 
            Add_Book_DB.Location = new Point(19, 18);
            Add_Book_DB.Name = "Add_Book_DB";
            Add_Book_DB.Size = new Size(141, 46);
            Add_Book_DB.TabIndex = 0;
            Add_Book_DB.Text = "Nhập sách từ CSDL";
            Add_Book_DB.UseVisualStyleBackColor = true;
            Add_Book_DB.Click += button1_Click;
            // 
            // Book_AddNormal
            // 
            Book_AddNormal.Location = new Point(192, 18);
            Book_AddNormal.Name = "Book_AddNormal";
            Book_AddNormal.Size = new Size(144, 46);
            Book_AddNormal.TabIndex = 1;
            Book_AddNormal.Text = "Thêm sách thủ công";
            Book_AddNormal.UseVisualStyleBackColor = true;
            Book_AddNormal.Click += Book_AddNormal_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(275, 330);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(602, 317);
            dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Column5";
            Column5.Name = "Column5";
            // 
            // Person_AddDB
            // 
            Person_AddDB.Location = new Point(20, 18);
            Person_AddDB.Name = "Person_AddDB";
            Person_AddDB.Size = new Size(144, 46);
            Person_AddDB.TabIndex = 3;
            Person_AddDB.Text = "Nhập độc giả từ CSDL";
            Person_AddDB.UseVisualStyleBackColor = true;
            Person_AddDB.Click += Person_AddDB_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(Book_AddNormal);
            panel1.Controls.Add(Add_Book_DB);
            panel1.Location = new Point(11, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(364, 257);
            panel1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(192, 119);
            button2.Name = "button2";
            button2.Size = new Size(144, 46);
            button2.TabIndex = 3;
            button2.Text = "Xóa sách";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(19, 119);
            button1.Name = "button1";
            button1.Size = new Size(141, 46);
            button1.TabIndex = 2;
            button1.Text = "Chỉnh sửa thông tin ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(Person_AddDB);
            panel2.Location = new Point(381, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(376, 257);
            panel2.TabIndex = 5;
            // 
            // button5
            // 
            button5.Location = new Point(194, 119);
            button5.Name = "button5";
            button5.Size = new Size(156, 46);
            button5.TabIndex = 6;
            button5.Text = "Xóa độc giả";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.Location = new Point(20, 119);
            button4.Name = "button4";
            button4.Size = new Size(144, 46);
            button4.TabIndex = 5;
            button4.Text = "Chỉnh sửa thông tin";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(194, 18);
            button3.Name = "button3";
            button3.Size = new Size(156, 46);
            button3.TabIndex = 4;
            button3.Text = "Thêm độc giả thủ công";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.GradientActiveCaption;
            panel3.Controls.Add(button10);
            panel3.Controls.Add(button9);
            panel3.Controls.Add(button8);
            panel3.Controls.Add(button7);
            panel3.Controls.Add(button6);
            panel3.Location = new Point(763, 67);
            panel3.Name = "panel3";
            panel3.Size = new Size(367, 257);
            panel3.TabIndex = 6;
            // 
            // button10
            // 
            button10.Location = new Point(205, 18);
            button10.Name = "button10";
            button10.Size = new Size(138, 46);
            button10.TabIndex = 4;
            button10.Text = "Thêm thẻ";
            button10.UseVisualStyleBackColor = true;
            button10.MouseClick += button10_MouseClick;
            // 
            // button9
            // 
            button9.Location = new Point(202, 119);
            button9.Name = "button9";
            button9.Size = new Size(141, 46);
            button9.TabIndex = 3;
            button9.Text = "Xóa thẻ";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.Location = new Point(19, 119);
            button8.Name = "button8";
            button8.Size = new Size(153, 25);
            button8.TabIndex = 2;
            button8.Text = "Mượn sách";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // button7
            // 
            button7.Location = new Point(19, 141);
            button7.Name = "button7";
            button7.Size = new Size(153, 24);
            button7.TabIndex = 1;
            button7.Text = "Trả sách";
            button7.UseVisualStyleBackColor = true;
            button7.MouseClick += button7_MouseClick;
            // 
            // button6
            // 
            button6.Location = new Point(19, 18);
            button6.Name = "button6";
            button6.Size = new Size(153, 46);
            button6.TabIndex = 0;
            button6.Text = "Nhập thẻ từ CSDL";
            button6.UseVisualStyleBackColor = true;
            button6.MouseClick += button6_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(99, 30);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 7;
            label1.Text = "QUẢN LÝ SÁCH";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(482, 30);
            label2.Name = "label2";
            label2.Size = new Size(177, 25);
            label2.TabIndex = 8;
            label2.Text = "QUẢN LÝ ĐỘC GIẢ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(886, 30);
            label3.Name = "label3";
            label3.Size = new Size(135, 25);
            label3.TabIndex = 9;
            label3.Text = "QUẢN LÝ THẺ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 659);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thư viện";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Add_Book_DB;
        private Button Book_AddNormal;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button Person_AddDB;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button6;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button10;
    }
}