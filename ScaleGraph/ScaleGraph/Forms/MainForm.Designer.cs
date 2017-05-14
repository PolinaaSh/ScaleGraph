namespace ScaleGraph
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphBox = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchRadioButton = new System.Windows.Forms.RadioButton();
            this.removeEdgeRadioButton = new System.Windows.Forms.RadioButton();
            this.removeNodeRadioButton = new System.Windows.Forms.RadioButton();
            this.addEdgeRadioButton = new System.Windows.Forms.RadioButton();
            this.addNodeRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.showRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphBox
            // 
            this.graphBox.Location = new System.Drawing.Point(3, 5);
            this.graphBox.Name = "graphBox";
            this.graphBox.Size = new System.Drawing.Size(1026, 579);
            this.graphBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.graphBox.TabIndex = 3;
            this.graphBox.TabStop = false;
            this.graphBox.Click += new System.EventHandler(this.graphBox_Click);
            this.graphBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphBox_MouseMove);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(2, 268);
            this.trackBar.Maximum = 8;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(145, 45);
            this.trackBar.TabIndex = 4;
            this.trackBar.Value = 1;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showRadioButton);
            this.groupBox1.Controls.Add(this.searchRadioButton);
            this.groupBox1.Controls.Add(this.removeEdgeRadioButton);
            this.groupBox1.Controls.Add(this.removeNodeRadioButton);
            this.groupBox1.Controls.Add(this.addEdgeRadioButton);
            this.groupBox1.Controls.Add(this.addNodeRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(2, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 208);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit";
            // 
            // searchRadioButton
            // 
            this.searchRadioButton.AutoSize = true;
            this.searchRadioButton.Location = new System.Drawing.Point(6, 155);
            this.searchRadioButton.Name = "searchRadioButton";
            this.searchRadioButton.Size = new System.Drawing.Size(82, 17);
            this.searchRadioButton.TabIndex = 4;
            this.searchRadioButton.TabStop = true;
            this.searchRadioButton.Text = "Поиск пути";
            this.searchRadioButton.UseVisualStyleBackColor = true;
            this.searchRadioButton.CheckedChanged += new System.EventHandler(this.searchRadioButton_CheckedChanged);
            // 
            // removeEdgeRadioButton
            // 
            this.removeEdgeRadioButton.AutoSize = true;
            this.removeEdgeRadioButton.Location = new System.Drawing.Point(6, 115);
            this.removeEdgeRadioButton.Name = "removeEdgeRadioButton";
            this.removeEdgeRadioButton.Size = new System.Drawing.Size(101, 17);
            this.removeEdgeRadioButton.TabIndex = 3;
            this.removeEdgeRadioButton.TabStop = true;
            this.removeEdgeRadioButton.Text = "Удалить ребро";
            this.removeEdgeRadioButton.UseVisualStyleBackColor = true;
            // 
            // removeNodeRadioButton
            // 
            this.removeNodeRadioButton.AutoSize = true;
            this.removeNodeRadioButton.Location = new System.Drawing.Point(6, 92);
            this.removeNodeRadioButton.Name = "removeNodeRadioButton";
            this.removeNodeRadioButton.Size = new System.Drawing.Size(114, 17);
            this.removeNodeRadioButton.TabIndex = 2;
            this.removeNodeRadioButton.TabStop = true;
            this.removeNodeRadioButton.Text = "Удалить вершину";
            this.removeNodeRadioButton.UseVisualStyleBackColor = true;
            // 
            // addEdgeRadioButton
            // 
            this.addEdgeRadioButton.AutoSize = true;
            this.addEdgeRadioButton.Location = new System.Drawing.Point(6, 51);
            this.addEdgeRadioButton.Name = "addEdgeRadioButton";
            this.addEdgeRadioButton.Size = new System.Drawing.Size(108, 17);
            this.addEdgeRadioButton.TabIndex = 1;
            this.addEdgeRadioButton.TabStop = true;
            this.addEdgeRadioButton.Text = "Добавить ребро";
            this.addEdgeRadioButton.UseVisualStyleBackColor = true;
            // 
            // addNodeRadioButton
            // 
            this.addNodeRadioButton.AutoSize = true;
            this.addNodeRadioButton.Location = new System.Drawing.Point(6, 28);
            this.addNodeRadioButton.Name = "addNodeRadioButton";
            this.addNodeRadioButton.Size = new System.Drawing.Size(121, 17);
            this.addNodeRadioButton.TabIndex = 0;
            this.addNodeRadioButton.TabStop = true;
            this.addNodeRadioButton.Text = "Добавить вершину";
            this.addNodeRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Масштабирование";
            // 
            // showRadioButton
            // 
            this.showRadioButton.AutoSize = true;
            this.showRadioButton.Location = new System.Drawing.Point(6, 185);
            this.showRadioButton.Name = "showRadioButton";
            this.showRadioButton.Size = new System.Drawing.Size(76, 17);
            this.showRadioButton.TabIndex = 5;
            this.showRadioButton.TabStop = true;
            this.showRadioButton.Text = "Просмотр";
            this.showRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.graphBox);
            this.panel1.Location = new System.Drawing.Point(148, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 584);
            this.panel1.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1185, 607);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "ScaleGraph";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddNodeButton;
        private System.Windows.Forms.Button AddEdgeButton;
        private System.Windows.Forms.PictureBox graphBox;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button RemoveNodeButton;
        private System.Windows.Forms.Button removeEdgeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton searchRadioButton;
        private System.Windows.Forms.RadioButton removeEdgeRadioButton;
        private System.Windows.Forms.RadioButton removeNodeRadioButton;
        private System.Windows.Forms.RadioButton addEdgeRadioButton;
        private System.Windows.Forms.RadioButton addNodeRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton showRadioButton;
        private System.Windows.Forms.Panel panel1;
    }
}

