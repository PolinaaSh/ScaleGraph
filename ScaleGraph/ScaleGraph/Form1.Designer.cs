namespace ScaleGraph
{
    partial class Form1
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
            this.AddNodeButton = new System.Windows.Forms.Button();
            this.AddEdgeButton = new System.Windows.Forms.Button();
            this.graphBox = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.RemoveNodeButton = new System.Windows.Forms.Button();
            this.removeEdgeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddNodeButton
            // 
            this.AddNodeButton.Location = new System.Drawing.Point(10, 30);
            this.AddNodeButton.Name = "AddNodeButton";
            this.AddNodeButton.Size = new System.Drawing.Size(75, 23);
            this.AddNodeButton.TabIndex = 1;
            this.AddNodeButton.Text = "AddNode";
            this.AddNodeButton.UseVisualStyleBackColor = true;
            this.AddNodeButton.Click += new System.EventHandler(this.AddNodeButton_Click);
            // 
            // AddEdgeButton
            // 
            this.AddEdgeButton.Location = new System.Drawing.Point(10, 70);
            this.AddEdgeButton.Name = "AddEdgeButton";
            this.AddEdgeButton.Size = new System.Drawing.Size(75, 23);
            this.AddEdgeButton.TabIndex = 2;
            this.AddEdgeButton.Text = "AddEdge";
            this.AddEdgeButton.UseVisualStyleBackColor = true;
            this.AddEdgeButton.Click += new System.EventHandler(this.AddEdgeButton_Click);
            // 
            // graphBox
            // 
            this.graphBox.Location = new System.Drawing.Point(147, 12);
            this.graphBox.Name = "graphBox";
            this.graphBox.Size = new System.Drawing.Size(1026, 579);
            this.graphBox.TabIndex = 3;
            this.graphBox.TabStop = false;
            this.graphBox.Click += new System.EventHandler(this.graphBox_Click);
            this.graphBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphBox_MouseMove);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(2, 261);
            this.trackBar.Maximum = 8;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(145, 45);
            this.trackBar.TabIndex = 4;
            this.trackBar.Value = 1;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // RemoveNodeButton
            // 
            this.RemoveNodeButton.Location = new System.Drawing.Point(10, 110);
            this.RemoveNodeButton.Name = "RemoveNodeButton";
            this.RemoveNodeButton.Size = new System.Drawing.Size(88, 23);
            this.RemoveNodeButton.TabIndex = 5;
            this.RemoveNodeButton.Text = "Remove Node";
            this.RemoveNodeButton.UseVisualStyleBackColor = true;
            this.RemoveNodeButton.Click += new System.EventHandler(this.RemoveNodeButton_Click);
            // 
            // removeEdgeButton
            // 
            this.removeEdgeButton.Location = new System.Drawing.Point(10, 151);
            this.removeEdgeButton.Name = "removeEdgeButton";
            this.removeEdgeButton.Size = new System.Drawing.Size(88, 23);
            this.removeEdgeButton.TabIndex = 6;
            this.removeEdgeButton.Text = "Remove Edge";
            this.removeEdgeButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeEdgeButton);
            this.groupBox1.Controls.Add(this.AddNodeButton);
            this.groupBox1.Controls.Add(this.RemoveNodeButton);
            this.groupBox1.Controls.Add(this.AddEdgeButton);
            this.groupBox1.Location = new System.Drawing.Point(2, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 187);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 607);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.graphBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
    }
}

